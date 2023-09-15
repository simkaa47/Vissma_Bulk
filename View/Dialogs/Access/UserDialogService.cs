using Avalonia.Controls.ApplicationLifetimes;
using Core.Contracts.Access;
using Core.Models.AccesControl;
using System.Threading.Tasks;

namespace View.Dialogs.Access;

public class UserDialogService : IAccessDialogService
{
    public async Task<bool> ShowDialog(User user)
    {
        if (!(App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop))
        {
            return false;
        }
        UserWindow userWindow = new UserWindow(user);
        await userWindow.ShowDialog(desktop.MainWindow);
        if (userWindow.DialogResult) return true;
        return false;

    }
}
