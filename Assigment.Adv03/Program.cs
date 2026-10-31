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
            #region Exercise 2: Leaderboard
            SortedDictionary<int, string> leadboard = new SortedDictionary <int, string>()
            {
                {500,"Ahmed"},
                {200,"Sara"},
                {800,"Ali"},
                {350,"Mona"}

            };

            // 2. Print all entries (they should be sorted by score automatically)
            // بنطبع العناصر باستخدام foreach وبنستعرض الـ Key والـ Value
            foreach (KeyValuePair<int, string> player in leadboard)
            {
                Console.WriteLine($"Score: {player.Key} -> Player: {player.Value}");
            }
            // 3. Access the first key and first value

            var firstPlayer = leadboard.First();
            Console.WriteLine($"First Score (Key): {firstPlayer.Key}");
            Console.WriteLine($"First Player Name (Value): {firstPlayer.Value}");

         
            // 4. Check if score 500 exists
           
            int targetScore = 500;
            if (leadboard.ContainsKey(targetScore))
            {
                Console.WriteLine($"Yes, score {targetScore} exists and belongs to: {leadboard[targetScore]}");
            }
            else
            {
                Console.WriteLine($"No, score {targetScore} does not exist.");
            }

            Console.WriteLine("\n=== 5. Safely Get Player with Score 999 ===");
            // 5. Safely get the player with score 999
            // بنستخدم TryGetValue عشان نبحث بأمان من غير ما البرنامج يعمل Crash لو الـ Key مش موجود
            int missingScore = 999;
            if (leadboard.TryGetValue(missingScore, out string? playerName))
            {
                Console.WriteLine($"Player with score {missingScore}: {playerName}");
            }
            else
            {
                Console.WriteLine($"Score {missingScore} was not found in the leaderboard.");
            }

            Console.WriteLine("\n=== 6. Remove Player with Score 200 and Print Updated List ===");
            // 6. Remove the player with score 200 and print the updated list
            // بنحذف العنصر اللي الـ Key بتاعه 200 باستخدام Remove
            leadboard.Remove(200);
            Console.WriteLine("Leaderboard after removing score 200:");
            foreach (KeyValuePair<int, string> player in leadboard )
            {
                Console.WriteLine($"Score: {player.Key} -> Player: {player.Value}");
            }
            #endregion
            #region Exercise 3: Phone Book
            Dictionary<string, string> PhoneBook = new Dictionary<string, string>();
            // 2.Add a new contact using [] syntax (add or update)

            PhoneBook["Ahmed"] = "01012345678";
            // 3. Try adding a duplicate using .Add() — catch the exception and print the error
            try
            {
                PhoneBook.Add("Ahmed", "01087654321"); // محاولة إضافة نفس الاسم مرة تانية
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // هتطبع رسالة الخطأ
            }
            // 4. Try adding a duplicate using .TryAdd() — print whether it succeeded
            bool isAdded = PhoneBook.TryAdd("Ahmed", "01087654321"); // محاولة إضافة نفس الاسم مرة تانية
            Console.WriteLine($"TryAdd result for Ahmed: {isAdded}");

            // 5.Search for a contact that doesn’t exist
            if (PhoneBook.TryGetValue("Mohamed", out string? mohamedPhone))
            {
                Console.WriteLine($"Mohamed's phone number: {mohamedPhone}");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
            // 6. Get a contact with a fallback of "Not Found"
            string contactName = "Sara";
            string? phoneNumber;
            if (PhoneBook.TryGetValue(contactName, out string? saraPhone))
            {
                Console.WriteLine($"{contactName}'s phone number: {saraPhone}");
            }
            else
            {
                Console.WriteLine($"{contactName}'s phone number: Not Found");
            }
            // 7 . Print all Keys on one line, then all Values on another line

            Console.WriteLine("All Keys:");
            Console.WriteLine(string.Join(", ", PhoneBook.Keys));
            Console.WriteLine("All Values:");
            Console.WriteLine(string.Join(", ", PhoneBook.Values));

            #endregion
            #region Exercise 4: Unique Email Validator
            // 1. Create a HashSet<string> with a case-insensitive comparer: new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            // 2 Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com"
          
            {
                "ahmed@test.com", 
                "AHMED@test.com",
                "sara@test.com", 
                "Sara@Test.Com"

            };
            // 3 Print Count — how many are actually stored? Explain why.
                Console.WriteLine($"Count of unique emails: {emails.Count}"); // Count هتكون 2 بس عشان الـ HashSet مش بيسمح بتكرار العناصر وده بيحصل بسبب الـ case-insensitive comparer اللي استخدمناه
           
            //4 Create two sets: Set A = {1,2,3,4,5} and Set B = {4,5,6,7,8}
            HashSet <int> setA = [ 1, 2, 3, 4, 5 ];
            HashSet <int> setB = [4, 5, 6, 7, 8];

            // 5 Print the result of: UnionWith, IntersectWith, ExceptWith
            setA.UnionWith(setB);
            Console.WriteLine($"Union of A and B: {string.Join(", ", setA)}"); // هتطبع 1,2,3,4,5,6,7,8
            setA.IntersectWith(setB);
            Console.WriteLine($"Intersection of A and B: {string.Join(", ", setA)}"); // هتطبع 4,5
            setA.ExceptWith(setB);
            Console.WriteLine($"Difference of A and B: {string.Join(", ", setA)}"); // هتطبع 1,2,3
                                                                                    // 6 Use IsSubsetOf to check if {1,2} is a subset of Set A
            HashSet<int> subset = [1, 2];
            bool isSubset = subset.IsSubsetOf(setA);
            Console.WriteLine($"Is {{1,2}} a subset of A? {isSubset}");
            #endregion
            #region Exercise 6: Browser History (Undo)
            // 1. Create a Stack<string> for browser history and push 5 URLs
            Stack<string> history = new Stack<string>();

            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai"); // دي أحدث صفحة (هتبقي في وش الـ Stack من فوق)

            // 2. Use Peek to see the current page (top of stack)
            Console.WriteLine($"--- 2. Current Page (Peek) ---");
            Console.WriteLine($"Current active page: {history.Peek()}"); // هتطبع claude.ai من غير ما تحذفها

            // 3. Press "back" 3 times using Pop — print each page you leave
            Console.WriteLine($"\n--- 3. Pressing Back 3 Times ---");
            for (int i = 0; i < 3; i++)
            {
                string leftPage = history.Pop();
                Console.WriteLine($"You left: {leftPage}");
            }

            // 4. Print the current page after going back
            Console.WriteLine($"\n--- 4. Current Page After Going Back ---");
            Console.WriteLine($"Current active page now: {history.Peek()}"); // هتطبع github.com بعد ما رجعنا 3 خطوات

            // 5. Try TryPop on an empty stack — what happens?
            Console.WriteLine($"\n--- 5. Testing TryPop on Empty Stack ---");

            // خلينا نفضي الـ Stack للاخر عشان نجرب الـ TryPop
            history.Clear();

            // TryPop بتحاول تحذف وترجع القيمة، ولو الـ Stack فاضي بترجع false ومش بتضرب Exception
            bool isPopped = history.TryPop(out string? resultPage);

            if (isPopped)
            {
                Console.WriteLine($"Popped successfully: {resultPage}");
            }
            else
            {
                Console.WriteLine("Stack is empty! TryPop safely prevented an exception.");
            }

            #endregion

        }
    }
}
