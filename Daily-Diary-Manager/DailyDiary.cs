using System;
using System.Globalization;
using System.IO;

namespace Daily_Diary_Manager
{
    public class DailyDiary
    {
        // Reading All file context
        public static string ReadingContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        // Add Entries to file With Its Date and Content
        public static void AddingEntries(string filePath, Entry entry)
        {
            if (DateTime.TryParseExact(entry.Date, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime parsedDate))
            {
                string formattedDate = parsedDate.ToString("yyyy-MM-dd");
                string addedContent = $"{formattedDate}\n{entry.Content}\n";
                File.AppendAllText(filePath, addedContent);
            }
        }

        // Deleting specific entries Accourding to user Input
        public static void DeleteEntry(string filePath, string content)
        {
            string text = File.ReadAllText(filePath);
            if (text.Contains(content))
            {
                text = text.Replace(content, "");
                File.WriteAllText(filePath, text);
            }
        }

        // Counting the total number of entries and Display it to the user 
        public static int CountEntries(string filePath)
        {
            string[] fileContent = File.ReadAllLines(filePath);
            return fileContent.Length;
        }

        // Read entries for a specific date
        public static string ReadEntries(string filePath, string date)
        {
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime parsedDate))
            {
                string formattedDate = parsedDate.ToString("yyyy-MM-dd");
                string[] fileContent = File.ReadAllLines(filePath);

                for (int i = 0; i < fileContent.Length; i++)
            {
                if (fileContent[i] == formattedDate)
                {
                    Console.WriteLine(fileContent[i + 1]);
                }
            }
            }
            return "No entry found for the given date.";
        }
    }
}
