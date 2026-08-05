namespace MiniAutomationToolkit.Core.Services
{
    public class ErrorLogger
    {
        public string? TryReadFile(string sourceFilePath, string logFilePath)
        {
            try
            {
                return File.ReadAllText(sourceFilePath);
            }
            catch (FileNotFoundException ex)
            {
                LogException(ex, logFilePath);
                return null;
            }
            catch (UnauthorizedAccessException ex)
            {
                LogException(ex, logFilePath);
                return null;
            }
        }

        private void LogException(Exception ex, string logFilePath)
        {
            string log = $"{DateTime.Now} | {ex.GetType().Name} | {ex.Message}\n";
            File.WriteAllText(logFilePath, log);
        }
    }
}