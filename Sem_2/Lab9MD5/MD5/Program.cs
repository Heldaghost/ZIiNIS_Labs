using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        Stopwatch stopWatch = new Stopwatch();
        Console.WriteLine("Ввод строки :");
        var md5 = MD5.Create();
        string text = Console.ReadLine();
        stopWatch.Start();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours,
            ts.Minutes,
            ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine( "Результат:\n" + Convert.ToBase64String(hash));
        Console.WriteLine("Время = {0}",elapsedTime);

        Console.WriteLine();        
       
        
    }
}


