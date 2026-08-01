using MiniAutomationToolkit.Core;
using MiniAutomationToolkit.Core.Models;
using MiniAutomationToolkit.Core.Helpers;
// 1 задание
var test = new PrintReference();
Console.WriteLine(test.Hello());
// 2 задание
Console.WriteLine(test.Discount(ClientType.Vip, 500));
Console.WriteLine(test.Discount(ClientType.Vip, 2000));
Console.WriteLine(test.Discount(ClientType.Premium, 800));
Console.WriteLine(test.Discount(ClientType.Premium, 1000));
Console.WriteLine(test.Discount(ClientType.Premium, 1500));
Console.WriteLine(test.Discount(ClientType.Regular, 500));
Console.WriteLine(test.Discount(ClientType.Regular, 1500));
Console.WriteLine(test.Discount(ClientType.Regular, 1000));
// 3 задание
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
Console.WriteLine(FileSearcher.FindFirstScreenshot(fileNamesWithoutScreenshots));