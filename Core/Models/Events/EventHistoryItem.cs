using Core.Infrastructure.DataAccess.Repositories;
using Core.Models.AccesControl;

namespace Core.Models.Events
{
    public  class EventHistoryItem:EntityCommon
    { 
        public DateTime? Date { get; set; }
        public virtual User? User { get; set; } 
        public string? Message { get; set; }
        public bool IsActive { get; set; }
        public UserAccessLevel? AccessLevel { get; set; }
        public string? EventCode { get; set; }
        public EventType EventType { get; set; }
        
    }
}
