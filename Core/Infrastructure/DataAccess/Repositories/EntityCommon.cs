using CommunityToolkit.Mvvm.ComponentModel;
using Core.Models;

namespace Core.Infrastructure.DataAccess.Repositories;

public abstract partial  class EntityCommon:AutoValidationObserver
{
    public int Id { get; set; }
    [ObservableProperty]
    public string? _createdBy;
    [ObservableProperty]
    public DateTime _createdDate;
    [ObservableProperty]
    public string? _lastModifiedBy;
    [ObservableProperty]
    public DateTime? _lastModifiedDate;
}
