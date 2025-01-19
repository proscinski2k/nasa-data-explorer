namespace web_api.Middlewares
{
    public class ClientTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _clientToken;

        public ClientTokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _clientToken = configuration["ClientToken"];
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Pomijamy sprawdzanie tokenu dla Swaggera
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("Client-Token", out var token) ||
                token != _clientToken)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { message = "Brak prawidłowego tokenu" });
                return;
            }

            await _next(context);
        }
    }

    // Klasa rozszerzająca do łatwiejszej rejestracji middleware
    public static class ClientTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseClientTokenValidation(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClientTokenMiddleware>();
        }
    }
}
