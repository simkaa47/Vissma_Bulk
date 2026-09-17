using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using Core.ViewModels;
using Core.Services.Activity;
using CommunityToolkit.Mvvm.Input;
using Avalonia;
using System.IO;
using Core.Models.JsonData;

namespace View.ViewModels
{
    public partial class ActivityLogViewModel : ViewModelBase
    {
        private readonly IActivityLogService _logService;

        [ObservableProperty]
        private ObservableCollection<ActivityLogEntry> _logs = new();

        [ObservableProperty]
        private ObservableCollection<ActivityLogEntry> _archiveLogs = new();

        [ObservableProperty]
        private string _loadFilePath = String.Empty;

        public const string FolderName = "Activity log data";

        #region Коллекция наборов
        /// <summary>
        /// Коллекция наборов
        /// </summary>
        private List<JsonData> _jsonDataCollection;
        /// <summary>
        /// Коллекция наборов
        /// </summary>
        public List<JsonData> JsonDataCollection
        {
            get => _jsonDataCollection;
            set => SetProperty(ref _jsonDataCollection, value);
        }
        #endregion

        #region Выбранный набор
        /// <summary>
        /// Выбранный набор
        /// </summary>
        private JsonData _selectedFileInfo;
        /// <summary>
        /// Выбранный набор
        /// </summary>
        public JsonData SelectedFileInfo
        {
            get => _selectedFileInfo;
            set
            {
                if (SetProperty(ref _selectedFileInfo, value))
                {
                    if (value is not null)
                    {
                        Load();
                    }
                }
            }
        }
        #endregion

        public ActivityLogViewModel(IActivityLogService logService)
        {
            _logService = logService;
            if (!Directory.Exists(FolderName))
            {
                Directory.CreateDirectory(FolderName);
            }
            Init();
            var history = _logService.GetHistory();
            foreach (var entry in history)
            {
                Logs.Add(entry);
            }
            _logService.EntryAdded += OnLogEntryAdded;
        }

        private void OnLogEntryAdded(object? sender, ActivityLogEntry entry)
        {

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Logs.Add(entry);

                if (Logs.Count > 500)
                {
                    Logs.RemoveAt(0);
                }
            });
        }

        public static List<JsonData> GetFilesInfo()
        {
            if (Directory.Exists(FolderName))
            {
                return new DirectoryInfo(FolderName).EnumerateFiles()
                   .Where(fi => fi.Extension.ToLower() == ".json")
                   .Select(fi => new JsonData { Name = fi.Name.Split(new char[] { '.' }).FirstOrDefault(), ChangeTime = fi.LastWriteTime }).ToList();
            }
            return new List<JsonData>();
        }



        [RelayCommand]
        public async Task ArchiveLogDownload()
        {


            LoadFilePath = Path.Combine(FolderName, SelectedFileInfo.Name + ".json");
            var entries = await _logService.LoadLogsFromFileAsync(LoadFilePath);
            ArchiveLogs.Clear();
            foreach (var entry in entries)
            {
                ArchiveLogs.Add(entry);
            }

        }

        public async Task Load()
        {
            ArchiveLogs.Clear();
            LoadFilePath = Path.Combine(FolderName, SelectedFileInfo.Name + ".json");
            var entries = await _logService.LoadLogsFromFileAsync(LoadFilePath);
            foreach (var entry in entries)
            {
                ArchiveLogs.Add(entry);
            }
        }

        void Init()
        {
            JsonDataCollection = GetFilesInfo();
        }

    }
}
