using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Services.Activity
{

    public interface IActivityLogService : IDisposable
    {
        void Log(LogLevel level, string source, string message);
        void LogError(string source, string message, Exception? ex = null);

        IReadOnlyList<ActivityLogEntry> GetHistory();

        event EventHandler<ActivityLogEntry>? EntryAdded;

        // Метод для принудительного сохранения (например, перед закрытием приложения)
        Task FlushAsync();
        Task<IReadOnlyList<ActivityLogEntry>> LoadLogsFromFileAsync(string filePath);
    }

    public class ActivityLogService : IActivityLogService
    {
        private readonly List<ActivityLogEntry> _entries = new();
        private readonly object _lock = new();

        private bool _isDirty; // Флаг: были ли изменения с последнего сохранения

        // Храним только последние 1000 записей
        private const int MaxCapacity = 1000;

        // Поля для автосохранения
        private readonly string _filePath;
        private readonly Timer _saveTimer;
        // Таймер и механизмы для фоновой записи
        private readonly PeriodicTimer _timer;
        private readonly CancellationTokenSource _cts = new();
        private readonly Task _backgroundSaveTask;

        public event EventHandler<ActivityLogEntry>? EntryAdded;

        public ActivityLogService(string logFilePath)
        {
            _filePath = logFilePath;

            // Гарантируем существование директории
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Запускаем фоновую задачу сохранения каждые 5 минут
            _timer = new PeriodicTimer(TimeSpan.FromSeconds(30));
            _backgroundSaveTask = SaveLoopAsync(_cts.Token);
        }

        public void Log(LogLevel level, string source, string message)
        {
            var entry = new ActivityLogEntry
            {
                Level = level,
                Source = source,
                Message = message
            };

            lock (_lock)
            {
                _entries.Add(entry);
                if (_entries.Count > MaxCapacity)
                {
                    _entries.RemoveAt(0);
                }
                _isDirty = true;
            }

            // Избежать deadlocks
            EntryAdded?.Invoke(this, entry);
        }

        public void LogError(string source, string message, Exception? ex = null)
        {
            var fullMessage = ex != null ? $"{message}\n{ex}" : message;
            Log(LogLevel.Error, source, fullMessage);
        }

        public IReadOnlyList<ActivityLogEntry> GetHistory()
        {
            lock (_lock)
            {
                // Возвращаем копию, чтобы избежать проблем при итерации в UI
                return _entries.ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Фоновый цикл, который срабатывает по таймеру и сохраняет данные, если они изменились.
        /// </summary>
        private async Task SaveLoopAsync(CancellationToken cancellationToken)
        {
            try
            {
                
                while (await _timer.WaitForNextTickAsync(cancellationToken))
                {
                    await SaveToFileAsync();
                }
            }
            catch (OperationCanceledException)
            {
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка фонового сохранения лога: {ex}");
            }
        }

        /// <summary>
        /// Асинхронная запись в файл. Выполняется вне блокировки, чтобы не тормозить метод Log().
        /// </summary>
        private async Task SaveToFileAsync()
        {
            List<ActivityLogEntry> snapshot;
            bool shouldSave;

            
            lock (_lock)
            {
                if (!_isDirty) return; 

                snapshot = _entries.ToList(); 
                _isDirty = false; 
                shouldSave = true;
            }

            
            if (shouldSave)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true, 
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
                };

                var json = JsonSerializer.Serialize(snapshot, options);
                await File.WriteAllTextAsync(_filePath, json, CancellationToken.None);
            }
        }


        /// <summary>
        /// Принудительное сохранение. Вызывайте при закрытии приложения, чтобы не потерять последние записи.
        /// </summary>
        public async Task FlushAsync()
        {
            await SaveToFileAsync();
        }

        public async Task<IReadOnlyList<ActivityLogEntry>> LoadLogsFromFileAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                return new List<ActivityLogEntry>();
            }

            try
            {

                using var fileStream = new FileStream(
                    filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read); 

                var jsonOptions = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true, 
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, 
                    ReadCommentHandling = JsonCommentHandling.Skip 
                };
                var entries = await JsonSerializer.DeserializeAsync<List<ActivityLogEntry>>(fileStream, jsonOptions);

                
                return entries ?? new List<ActivityLogEntry>();
            }
            catch (JsonException ex)
            {
                
                System.Diagnostics.Debug.WriteLine($"[LogService] Ошибка парсинга JSON в файле {filePath}: {ex.Message}");
                return new List<ActivityLogEntry>();
            }
            catch (IOException ex)
            {
                
                System.Diagnostics.Debug.WriteLine($"[LogService] Ошибка ввода-вывода при чтении {filePath}: {ex.Message}");
                return new List<ActivityLogEntry>();
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine($"[LogService] Неизвестная ошибка при чтении {filePath}: {ex.Message}");
                return new List<ActivityLogEntry>();
            }
        }


        public void Dispose()
        {
            
            _cts.Cancel();
            _timer.Dispose();

            // Делаем финальное сохранение перед уничтожением объекта
            
            try
            {
                SaveToFileAsync().GetAwaiter().GetResult();
            }
            catch
            {
                
            }
        }
    }
}
