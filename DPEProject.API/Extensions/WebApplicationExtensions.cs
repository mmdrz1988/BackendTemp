namespace DPEProject.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureApplication(this WebApplication app) 
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();




            app.UseStaticFiles();



            return app;
        }
    }
}
