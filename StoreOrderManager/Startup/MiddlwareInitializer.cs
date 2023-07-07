namespace StoreOrderManager.Startup
{
    public static class MiddlewareInitializer
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            app.UseHttpsRedirection();

            return app;
        }
    }
}
