namespace MiniAutomationToolkit.Core.Configuration
{
	public class AppConfig
	{
        private readonly Dictionary<string, string> _settings = new();
        public AppConfig(string filePath)
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (line.TrimStart().StartsWith("#"))
                {
                    continue;
                }
                string[] parts = line.Split('=', 2);
                if (parts.Length != 2)
                {
                    throw new InvalidDataException($"There is no '=' in '{line}'" );
                }

                string key = parts[0].Trim();
                string value = parts[1].Trim();

                // Проверяем ключ
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new InvalidDataException($"Key cant be empty'{line}'");
                }

                // Проверяем дубликаты
                if (_settings.ContainsKey(key))
                {
                    throw new InvalidDataException($"Key is a duplicate {line}");
                }

                _settings.Add(key, value);
            }
        }
        public T GetSetting<T>(string key)
        {

            if (!_settings.TryGetValue(key, out string? value))
            {
                throw new KeyNotFoundException($"Key not found {key}");
            }
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                throw new InvalidDataException(
                    $"'{value}' is incorrecyType awaiting is {typeof(T).Name}'.");
            }
        }
    }
}