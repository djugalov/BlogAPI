namespace Blog.BL.Helpers
{
    public class AppSettings
    {
        public const string Settings = "AppSettings";

        public string AuthSecret { get; set; } = string.Empty;
    }
}
