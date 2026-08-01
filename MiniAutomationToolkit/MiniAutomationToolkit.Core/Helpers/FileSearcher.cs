namespace MiniAutomationToolkit.Core.Helpers
{
    public static class FileSearcher
    {
        public static string FindFirstScreenshot(List<string> fileNames)
        {
            var pngFiles = fileNames.Where(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase));

            if (pngFiles.Any())
            {
                return pngFiles.FirstOrDefault()!;
            }
            else
            {
                throw new FileNotFoundException("No screenshots found in the provided list.");
            }
        }
    }

}