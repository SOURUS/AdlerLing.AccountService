namespace AdlerLing.AccountService.Core.Transfering
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {
        }

        public ErrorMessage(string errorMessage)
        {
            Text = errorMessage;
        }

        public string Text { get; set; }
    }
}
