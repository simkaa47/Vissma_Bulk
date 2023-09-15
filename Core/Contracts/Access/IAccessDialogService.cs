using Core.Models.AccesControl;

namespace Core.Contracts.Access
{
    public interface IAccessDialogService
    {        
        Task<bool> ShowDialog(User user);
    }
}
