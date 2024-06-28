using Daily_Diary_Manager;

namespace TestDailyDiary
{
    public class UnitTest1
    {
        [Fact]
        public void TestReadFile()
        {
            //Arrange
            string filePath = Path.Combine(Environment.CurrentDirectory, "mydiary.txt");

            //Act
            string TestText = DailyDiary.ReadingContent(filePath);

            //Assert
            string content = File.ReadAllText(filePath);
            Assert.Equal(TestText, content);
        }

        [Fact]
        public void TestAddNewContent()
        {
            // Arrange
            string filePath = Path.Combine(Environment.CurrentDirectory, "mydiary.txt");
            Entry newContent = new Entry
            {
                Date = "2024-06-01",
                Content = "New Content From Test"
            };

            // Clean up any existing file before the test
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Act
            DailyDiary.AddingEntries(filePath, newContent);

            // Assert
            string expectedContent = "2024-06-01\nNew Content From Test\n";
            string actualContent = File.ReadAllText(filePath);
            Assert.Equal(expectedContent, actualContent);

        }
    }
}