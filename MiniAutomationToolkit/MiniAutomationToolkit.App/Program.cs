using MiniAutomationToolkit.Core;
using MiniAutomationToolkit.Core.Configuration;
using MiniAutomationToolkit.Core.Extensions;
using MiniAutomationToolkit.Core.Helpers;
using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Pages;
using MiniAutomationToolkit.Core.Repositories;
using MiniAutomationToolkit.Core.Services;
using MiniAutomationToolkit.Core.Simulations;
using MiniAutomationToolkit.Core.Validation;
using System.Diagnostics;
// 1 задание
Console.WriteLine("Task 1");
var test = new PrintReference();
Console.WriteLine(test.Hello());
// 2 задание
Console.WriteLine("Task 2");
Console.WriteLine(test.Discount(ClientType.Vip, 500));
Console.WriteLine(test.Discount(ClientType.Vip, 2000));
Console.WriteLine(test.Discount(ClientType.Premium, 800));
Console.WriteLine(test.Discount(ClientType.Premium, 1000));
Console.WriteLine(test.Discount(ClientType.Premium, 1500));
Console.WriteLine(test.Discount(ClientType.Regular, 500));
Console.WriteLine(test.Discount(ClientType.Regular, 1500));
Console.WriteLine(test.Discount(ClientType.Regular, 1000));
// 3 задание
Console.WriteLine("Task 3");
var fileNames = new List<string>
{
    "debug_742.txt",
    "screen_019.png",
    "error_2242.log",
    "trace_007.txt",
    "screen_003.png",
    "warning_842.log",
    "debug_015.txt",
    "screen_021.png",
    "crash_422.log",
    "report_009.txt",
    "screen_014.png",
    "error_731.log",
    "dump_242.txt",
    "screen_006.png",
    "debug_328.log",
    "trace_011.txt",
    "screen_018.png",
    "fatal_542.log",
    "screen_025.png",
    "session_902.txt"
};
var fileNamesWithoutScreenshots = new List<string>
{
    "debug_742.txt",
    "error_2242.log",
    "trace_007.txt",
    "warning_842.log",
    "debug_015.txt",
    "crash_422.log",
    "report_009.txt",
    "error_731.log",
    "dump_242.txt",
    "debug_328.log",
    "trace_011.txt",
    "fatal_542.log",
    "session_902.txt"
};
Console.WriteLine(FileSearcher.FindFirstScreenshot(fileNames));
try
{
    Console.WriteLine(FileSearcher.FindFirstScreenshot(fileNamesWithoutScreenshots));
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
// 4 задание, также поправил ошибку что бы не ломалась консоль из за задания 3
Console.WriteLine("Task 4");
var alexRecordOne = new UserDto("AlexSmith", "alex@email.com");
var alexRecordTwo = new UserDto("AlexSmith", "alex@email.com");
Console.WriteLine(alexRecordOne == alexRecordTwo);
// alexRecordOne.name = "JohnSmith" Тут можно проверить что будет ошибка если убрать коммент 
try
{
    var alexRecordErrorFirst = new UserDto("", "alex@email.com");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    var alexRecordErrorSecond = new UserDto("AlexSmith", "");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    var alexRecordErrorThird = new UserDto("AlexSmith", "alexemail.com");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    var alexRecordErrorFourth = new UserDto("AlexSmith", "alex@ema il.com");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
// Задание 5. «Базовая страница»
Console.WriteLine("Task 5");
List<BasePage> pages = new(){ new LoginPage(),new HomePage()};
foreach (var page in pages)
{
    page.Load();
}
List<string> urls = new();
foreach (var page in pages)
{
    urls.Add(page.Url);
}
try
{
    if (urls.Count() != urls.Distinct().Count())
    {
        throw new InvalidOperationException("Duplicate page URLs found.");
    }
    else
    {
        Console.WriteLine("All page URLs are unique.");
    }
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
//Задание 6
Console.WriteLine("Task 6");
var configPath = "data/appsettings.txt";
AppConfig config = new AppConfig(configPath);

var baseUrl = config.GetSetting<string>("baseUrl");
var  timeout = config.GetSetting<int>("timeout");
var headless = config.GetSetting<bool>("headless");
var retryCount = config.GetSetting<int>("retryCount");
Console.WriteLine($"base URL: {baseUrl}");
Console.WriteLine($"timeout: {timeout}");
Console.WriteLine($"headless: {headless}");
Console.WriteLine($"retry Count: {retryCount}");
try
{
    int wrongKey = config.GetSetting<int>("wrongKey");
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
//Задание 7
Console.WriteLine("Task 7");
string?[] inputsTaskSeven =
{
    "https://google.com",
    "http://example.org",
    "ftp://files.example.com",
    null,
    "HTTPS://SITE.EXAMPLE.COM"
};

foreach (string? input in inputsTaskSeven)
{
    Console.WriteLine($"'{input}' -> {input.HasHttpScheme()}");
}
// Задание 8 
Console.WriteLine("Task 8");
var simulator = new LongOperationSimulator();
var stopwatch = Stopwatch.StartNew();
string result = await simulator.LongOperationAsync();
stopwatch.Stop();
Console.WriteLine($"Answer from funcion is '{result}' Duration: {stopwatch.ElapsedMilliseconds} ms");
//Задание 9
Console.WriteLine("Task 9");
var logger = new ErrorLogger();
string inputPath = "data/input.txt";
string missingPath = "data/missing.txt";
string logPath = "data/errors.log";
string? content = logger.TryReadFile(inputPath, logPath);
if (content != null)
{
    Console.WriteLine(content);
}
string? missingContent = logger.TryReadFile(missingPath, logPath);
Console.WriteLine(File.ReadAllText(logPath));
// Задание 10
Console.WriteLine("Task 9");
var number1 = 5;
var number2 = -5;
var number3 = 0;
try
{
    Guard.EnsurePositive(number1);
    Console.WriteLine($"{number1} is valid");
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    Guard.EnsurePositive(number2);
    Console.WriteLine($"{number2} is valid");
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    Guard.EnsurePositive(0);
    Console.WriteLine($"{number3} is valid");
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}
//Задание 10
Console.WriteLine("Task 10");
var products = ProductRepository.LoadFromCsv(@"data\products.csv");

Console.WriteLine("Food cheaper and not equal to 1");

var resultTask10 = ProductRepository.GetAffordableProducts(products,ProductCategory.Food, 10);

if (resultTask10.Count == 0)
{
    Console.WriteLine("No products found");
}
else
{
    foreach (var product in resultTask10)
    {
        Console.WriteLine(product);
    }
}

Console.WriteLine("Food cheaper and not equal to 1");

resultTask10 = ProductRepository.GetAffordableProducts(products,ProductCategory.Food,1);

if (resultTask10.Count == 0)
{
    Console.WriteLine("No products found");
}
else
{
    foreach (var product in resultTask10)
    {
        Console.WriteLine(product);
    }
}