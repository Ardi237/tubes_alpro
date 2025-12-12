namespace FrontEnd.Common
{
    public static class AppData
    {
        public static bool KIsWeb = false;

        public static string Version = "1.0.2";

        public static bool UseSSL = false;

        public static string ApiDomain = "http://localhost:5000";

        public static string HttpAuthority = "/api";

        public static string BaseApiUrl => $"{ApiDomain}{HttpAuthority}";
    }
}
