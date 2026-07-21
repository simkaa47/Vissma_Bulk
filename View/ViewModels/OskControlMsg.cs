using CommunityToolkit.Mvvm.Messaging.Messages;

namespace View.ViewModels
{
    public class OskControlMsg : ValueChangedMessage<bool>
    {
        public OskControlMsg(bool value) : base(value)
        {
        }
    }
}
