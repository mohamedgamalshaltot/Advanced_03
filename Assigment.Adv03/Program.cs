namespace Assigment.Adv03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 1: Student Grade Manager



          //  1.Create a Collection with these grades using Collection Expressions
            List<int> grades = [85, 92, 78, 95, 88, 70, 100, 65];

            // 2. Print the collection, Count, first and last grade
            Console.WriteLine($"All Grades: {string.Join(", ", grades)}");
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First Grade: {grades[0]}");
            Console.WriteLine($"Last Grade: {grades[^1]}");

            // 3. Sort the grades ascending, then print
            grades.Sort();
            Console.WriteLine($"Sorted Ascending: {string.Join(", ", grades)}");

            // 4. Get the first grade above 90
            int firstAbove90 = grades.First(g => g > 90);
            Console.WriteLine($"First grade above 90: {firstAbove90}");

            // 5. Get all grades below 75 (failing grades)
            var failingGrades = grades.Where(g => g < 75);
            Console.WriteLine($"Failing grades: {string.Join(", ", failingGrades)}");

            // 6. Remove all failing grades (below 75)
            grades.RemoveAll(g => g < 75);
            Console.WriteLine($"Grades after removing failing: {string.Join(", ", grades)}");

            // 7. Check if any grade equals 100
            bool has100 = grades.Contains(100);
            Console.WriteLine($"Is there any grade equal to 100? {has100}");

            // 8. Create a List<string> where each grade becomes "Grade: X"
            List<string> formattedGrades = grades.Select(g => $"Grade: {g}").ToList();
            foreach (string gradeStr in formattedGrades)
            {
                Console.WriteLine(gradeStr);
            }
            #endregion

        }
    }
}
