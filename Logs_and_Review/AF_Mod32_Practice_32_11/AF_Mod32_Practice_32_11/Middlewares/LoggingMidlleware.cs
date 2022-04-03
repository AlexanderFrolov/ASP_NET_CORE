using AF_Mod32_Practice_32_11.Models.Db;

namespace AF_Mod32_Practice_32_11.Middlewares
{
    public class LoggingMidlleware
    {
        private readonly RequestDelegate _next;
        private IRequestRepository _repo;

        /// <summary>
        ///  Middleware component must have a constructor that accepts RequestDelegate
        /// </summary>
        public LoggingMidlleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        ///  Invoke or InvokeAsync must be implemented
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            string logMessage = CreateLogMessage(context);

            LogConsole(logMessage);

            await LogFile(context, logMessage, env);

            await LogToDb(context);

            // send request further by pipeline
            await _next.Invoke(context);
        }

        /// <summary>
        ///   create string to write to log
        /// </summary>
        private string CreateLogMessage(HttpContext context)
        {
            return $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path} ";
        }

        /// <summary>
        /// logging to console
        /// </summary>
        private void LogConsole(string logMessage)
        {
            Console.WriteLine(logMessage);
        }

        /// <summary>
        ///  write to log file 
        /// </summary>    
        private async Task LogFile(HttpContext context, string logMessage, IWebHostEnvironment env)
        {
            // Path to the log (again, we use the IWebHostEnvironment properties)
            string logFilePath = Path.Combine(env.ContentRootPath, "Logs", "RequestLog.txt");

            // use asynchronous write to file
            await File.AppendAllTextAsync(logFilePath, logMessage + $"{Environment.NewLine}");
        }

        /// <summary>
        ///  write to DB (table Requests)
        /// </summary>
        private async Task LogToDb(HttpContext context)
        {
            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await _repo.Add(newRequest);
        }

    }
}
