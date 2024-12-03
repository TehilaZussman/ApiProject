namespace EX2.services.Logger
using EX2.models
{
    public class Logger
    {
        //private readonly TasksDbContext _context;
        private readonly TasksDbContext _dBcontext;

        public LoggerFactory(TasksDbContext context)
        {
            _dBcontext = context;
        }

        public ILogger addLogger(string message)
        {
            try
            {
                if (message)
                {
                    logger l = new logger()
                    l.message = message;
                    _dBcontext.logger.add(l);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to log message: {ex.Message}");
            }
        }
    }
}
