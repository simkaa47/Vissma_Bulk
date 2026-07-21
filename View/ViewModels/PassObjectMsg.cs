using CommunityToolkit.Mvvm.Messaging.Messages;

namespace View.ViewModels
{
    public class PassObjectMsg : ValueChangedMessage<object>
    {
        public PassObjectMsg(object value) : base(value)
        {
        }
    }
}
