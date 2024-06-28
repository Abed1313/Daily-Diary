using System;
using System.IO;

namespace Daily_Diary_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "mydiary.txt");
            int choose = 0;

            while (choose != 6)
            {
                Console.WriteLine("Please choose from the options:\n1. Read the entire diary.\n2. Add entries to your diary" +
                                  "\n3. Delete an entry.\n4. Count the number of entries.\n5. Read entries for a specific date." +
                                  "\n6. Exit");
                if (!int.TryParse(Console.ReadLine(), out choose) || choose < 1 || choose > 6)
                {
                    Console.WriteLine("Invalid choice. Please choose a number between 1 and 6.");
                    continue;
                }

                try
                {
                    switch (choose)
                {
                    case 1:
                        Console.WriteLine("File content:");
                        Console.WriteLine(DailyDiary.ReadingContent(filePath));
                        break;

                    case 2:
                        Console.WriteLine("Write the date for your entry (yyyy-MM-dd):");
                        string date = Console.ReadLine();
                        Console.WriteLine("Write your content:");
                        string content = Console.ReadLine();
                        DailyDiary.AddingEntries(filePath, new Entry { Date = date, Content = content });
                        Console.WriteLine(DailyDiary.ReadingContent(filePath));
                        break;

                    case 3:
                        Console.WriteLine("Write the content you want to delete:");
                        content = Console.ReadLine();
                        DailyDiary.DeleteEntry(filePath, content);
                        Console.WriteLine(DailyDiary.ReadingContent(filePath));
                        break;

                    case 4:
                        Console.WriteLine("The number of entries:");
                        Console.WriteLine(DailyDiary.CountEntries(filePath));
                        break;

                    case 5:
                        Console.WriteLine("Enter the date to get its entry (yyyy-MM-dd):");
                        date = Console.ReadLine();
                        Console.WriteLine(DailyDiary.ReadEntries(filePath, date));
                        Console.WriteLine(DailyDiary.ReadingContent(filePath));
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Choose only from 1-6");
                        break;
                }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The diary file was not found.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("You do not have permission to access the diary file.");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"An I/O error occurred: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}
