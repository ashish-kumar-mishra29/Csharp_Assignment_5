using System;
using System.IO;
using System.Threading.Tasks;

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000);
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}

public class Program
{
    static async Task Main(string[] args)
    {
        BackgroundOperation backgroundOperation = new BackgroundOperation();

        while (true)
        {
            Console.WriteLine("Kiosk Menu:");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Enter your choice (1/2/3/4):");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Writing to file...");
                    await backgroundOperation.WriteToFileAsync("Hello World");
                    Console.WriteLine("Message written to file successfully.");
                    break;
                case "2":
                    Console.WriteLine("Writing to file...");
                    await backgroundOperation.WriteToFileAsync(DateTime.Now.ToString());
                    Console.WriteLine("Message written to file successfully.");
                    break;
                case "3":
                    Console.WriteLine("Writing to file...");
                    await backgroundOperation.WriteToFileAsync(Environment.OSVersion.VersionString);
                    Console.WriteLine("Message written to file successfully.");
                    break;
                case "4":
                    Console.WriteLine("Quiting");
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3 or 4.");
                    break;
            }
            if (choice == "4") break;
        }
    }
}
