namespace Webmall.UI.ViewModel.Common
{
    public class MessageViewModel
    {
        public string ImageSrc { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public MessageViewModel()
        {
        }

        public MessageViewModel(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}