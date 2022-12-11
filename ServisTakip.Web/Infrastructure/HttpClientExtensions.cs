namespace ServisTakip.Web.Infrastructure
{
    public static class HttpClientExtensions
    {
        private static IHttpContextAccessor _context;
        public static void SetContext(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
        }
    }
}
