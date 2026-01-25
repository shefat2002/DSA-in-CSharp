# C# Collection Data Structures:

---

## 📚 Table of Contents
1. [List Collections](#list-collections)
2. [Dictionary Collections](#dictionary-collections)
3. [Set Collections](#set-collections)
4. [Stack Collections](#stack-collections)
5. [Queue Collections](#queue-collections)
6. [Concurrent Collections](#concurrent-collections)
7. [Practice Problems](#practice-problems)

---

## List Collections

### 1. List&lt;T&gt; - The Magic Growing Box 📦

**What is it?**
Imagine you have a box where you can put items in order. When the box gets full, it magically becomes bigger! That's what a List is.

**Real-life example:** A playlist of songs, a shopping list, or your class attendance sheet.

**When to use it:**
- When you need to store items in order
- When you don't know how many items you'll have
- When you need fast access to any item by its position

**Basic Operations:**

```csharp
// Creating a list
List<string> fruits = new List<string>();

// Adding items
fruits.Add("Apple");        // ["Apple"]
fruits.Add("Banana");       // ["Apple", "Banana"]
fruits.Add("Cherry");       // ["Apple", "Banana", "Cherry"]

// Accessing items by index (position starts at 0)
string firstFruit = fruits[0];  // "Apple"
string secondFruit = fruits[1]; // "Banana"

// Removing items
fruits.Remove("Banana");    // ["Apple", "Cherry"]

// Checking if item exists
bool hasApple = fruits.Contains("Apple"); // true

// Getting the count
int count = fruits.Count;   // 2

// Inserting at specific position
fruits.Insert(1, "Mango");  // ["Apple", "Mango", "Cherry"]
```

**Example 1: Student Grades Tracker**

This example shows how to manage student grades and perform calculations.

```csharp
List<int> grades = new List<int>();

// Adding grades - imagine a teacher entering test scores
grades.Add(85);  // First test
grades.Add(92);  // Second test
grades.Add(78);  // Third test
grades.Add(95);  // Fourth test

// Calculate average
// We need to add all grades together, then divide by how many there are
double sum = 0;
foreach (int grade in grades)
{
    sum += grade;  // sum = sum + grade
}
double average = sum / grades.Count;
Console.WriteLine($"Average: {average}"); // 87.5

// Find highest grade
// Start by assuming the first grade is the highest
int highest = grades[0];
foreach (int grade in grades)
{
    if (grade > highest)
        highest = grade;  // Found a new highest!
}
Console.WriteLine($"Highest: {highest}"); // 95

// Find lowest grade
int lowest = grades[0];
foreach (int grade in grades)
{
    if (grade < lowest)
        lowest = grade;
}
Console.WriteLine($"Lowest: {lowest}"); // 78

// Count how many grades are above 85
int countAbove85 = 0;
foreach (int grade in grades)
{
    if (grade > 85)
        countAbove85++;
}
Console.WriteLine($"Grades above 85: {countAbove85}"); // 2 grades
```

**Why this works:**
- We use a List because we don't know how many grades we'll have
- Lists allow us to easily loop through all items
- The Count property tells us how many grades there are
- We can access any grade by its position using grades[0], grades[1], etc.

---

**Example 2: To-Do List Application**

A practical task manager that shows adding, removing, and displaying items.

```csharp
List<string> todoList = new List<string>();

// Adding tasks for the day
todoList.Add("Wake up at 6 AM");
todoList.Add("Brush teeth");
todoList.Add("Eat breakfast");
todoList.Add("Go to school");

Console.WriteLine($"Total tasks: {todoList.Count}"); // 4

// Mark task as complete (remove it)
// RemoveAt(0) removes the item at position 0 (first item)
todoList.RemoveAt(0); // Removes "Wake up at 6 AM"

// Display remaining tasks with numbers
Console.WriteLine("\nRemaining tasks:");
for (int i = 0; i < todoList.Count; i++)
{
    // i starts at 0, but we want to show 1, 2, 3... so we use i + 1
    Console.WriteLine($"{i + 1}. {todoList[i]}");
}
/* Output:
Remaining tasks:
1. Brush teeth
2. Eat breakfast
3. Go to school
*/

// Add a new urgent task at the beginning
todoList.Insert(0, "Take medicine");
// Now "Take medicine" is first in the list

// Check if a specific task exists
bool needsSchool = todoList.Contains("Go to school");
Console.WriteLine($"Need to go to school? {needsSchool}"); // true
```

**Why Lists are perfect for To-Do apps:**
- Tasks have a natural order (do this, then that)
- We can easily add new tasks
- We can remove completed tasks
- We can insert urgent tasks at any position
- We can see how many tasks are left with Count

---

**Example 3: Advanced - Student Performance Analyzer**

This advanced example combines multiple List operations to analyze student performance.

```csharp
// Store student names and their corresponding grades
List<string> studentNames = new List<string> 
{ 
    "Alice", "Bob", "Charlie", "Diana", "Eve" 
};

List<int> studentGrades = new List<int> 
{ 
    92, 78, 85, 95, 88 
};

// Find the top performer
// We'll track the index of the best student
int topStudentIndex = 0;
int highestGrade = studentGrades[0];

for (int i = 1; i < studentGrades.Count; i++)
{
    if (studentGrades[i] > highestGrade)
    {
        highestGrade = studentGrades[i];
        topStudentIndex = i;
    }
}

Console.WriteLine($"Top Student: {studentNames[topStudentIndex]}");
Console.WriteLine($"Score: {highestGrade}");
// Output: Top Student: Diana, Score: 95

// Create a report card - pair each student with their grade
Console.WriteLine("\n=== CLASS REPORT CARD ===");
for (int i = 0; i < studentNames.Count; i++)
{
    string name = studentNames[i];
    int grade = studentGrades[i];
    
    // Determine letter grade
    string letterGrade;
    if (grade >= 90) letterGrade = "A";
    else if (grade >= 80) letterGrade = "B";
    else if (grade >= 70) letterGrade = "C";
    else letterGrade = "F";
    
    Console.WriteLine($"{name}: {grade} ({letterGrade})");
}

// Calculate class statistics
double classAverage = 0;
foreach (int grade in studentGrades)
{
    classAverage += grade;
}
classAverage /= studentGrades.Count;

Console.WriteLine($"\nClass Average: {classAverage:F2}"); // F2 means 2 decimal places

// Find students below average
Console.WriteLine("\nStudents below average:");
for (int i = 0; i < studentGrades.Count; i++)
{
    if (studentGrades[i] < classAverage)
    {
        Console.WriteLine($"- {studentNames[i]} ({studentGrades[i]})");
    }
}
```

**What makes this advanced:**
- We use **two parallel lists** (names and grades at matching positions)
- We track both a value (highest grade) and its position (index)
- We convert numeric grades to letter grades using conditionals
- We calculate statistics and filter data based on conditions
- We format output nicely with string interpolation

**Key concept:** When you have related data in separate lists, make sure they stay synchronized (same order, same count).

---

### 2. LinkedList&lt;T&gt; - The Chain of Items ⛓️

**What is it?**
Imagine a train where each car is connected to the next one. You can easily add or remove cars from anywhere in the train. That's a LinkedList!

**Real-life example:** A chain of people holding hands, a train with carriages, or browser history (back/forward buttons).

**When to use it:**
- When you frequently add or remove items from the middle
- When you don't need fast access by position
- When you want to move through items one by one

**Basic Operations:**

```csharp
LinkedList<string> playlist = new LinkedList<string>();

// Adding items
playlist.AddLast("Song 1");   // Add at end
playlist.AddLast("Song 2");
playlist.AddFirst("Intro");   // Add at beginning

// Current playlist: "Intro" -> "Song 1" -> "Song 2"

// Getting first and last
LinkedListNode<string> first = playlist.First;  // "Intro"
LinkedListNode<string> last = playlist.Last;    // "Song 2"

// Moving through the chain
LinkedListNode<string> current = playlist.First;
while (current != null)
{
    Console.WriteLine(current.Value);
    current = current.Next; // Move to next song
}

// Adding after a specific item
LinkedListNode<string> song1 = playlist.Find("Song 1");
playlist.AddAfter(song1, "Song 1.5");
```

**Example 1: Browser History (Back/Forward Navigation)**

This example shows how LinkedList is perfect for browser-like navigation.

```csharp
LinkedList<string> browserHistory = new LinkedList<string>();

// User visits websites
browserHistory.AddLast("google.com");
browserHistory.AddLast("youtube.com");
browserHistory.AddLast("github.com");

// The linked list looks like:
// google.com <-> youtube.com <-> github.com
//                                      ↑ (we're here)

// Going back in history
LinkedListNode<string> currentPage = browserHistory.Last;
Console.WriteLine($"Current page: {currentPage.Value}"); // github.com

// Click the back button
currentPage = currentPage.Previous; // Move to previous node
Console.WriteLine($"After clicking back: {currentPage.Value}"); // youtube.com

// Click back again
currentPage = currentPage.Previous;
Console.WriteLine($"After clicking back again: {currentPage.Value}"); // google.com

// Now let's go forward
currentPage = currentPage.Next;
Console.WriteLine($"After clicking forward: {currentPage.Value}"); // youtube.com
```

**Why LinkedList works great here:**
- Each page knows about the previous page and the next page
- Moving back and forward is just moving to Previous or Next
- We can traverse history in both directions easily
- It's like a chain of pages connected together

---

**Example 2: Music Playlist with Current Song Tracking**

A more complex example showing insertion and deletion in the middle.

```csharp
LinkedList<string> playlist = new LinkedList<string>();

// Creating a playlist
playlist.AddLast("Song A - Intro");
playlist.AddLast("Song B - Main Theme");
playlist.AddLast("Song C - Ending");

Console.WriteLine("Original Playlist:");
foreach (string song in playlist)
{
    Console.WriteLine($"♪ {song}");
}

// Now playing: Song B
LinkedListNode<string> currentSong = playlist.Find("Song B - Main Theme");
Console.WriteLine($"\n🎵 Now playing: {currentSong.Value}");

// User wants to add a song after the current song
string newSong = "Song B.5 - Bonus Track";
playlist.AddAfter(currentSong, newSong);

Console.WriteLine("\nPlaylist after adding bonus track:");
foreach (string song in playlist)
{
    Console.WriteLine($"♪ {song}");
}
/* Output:
♪ Song A - Intro
♪ Song B - Main Theme
♪ Song B.5 - Bonus Track  ← newly added!
♪ Song C - Ending
*/

// Skip to next song
currentSong = currentSong.Next;
Console.WriteLine($"\n🎵 Now playing: {currentSong.Value}"); // Song B.5 - Bonus Track

// Skip to next song again
currentSong = currentSong.Next;
Console.WriteLine($"🎵 Now playing: {currentSong.Value}"); // Song C - Ending

// Remove current song from playlist
LinkedListNode<string> nextSong = currentSong.Next; // Save where to go next
playlist.Remove(currentSong); // Remove Song C

Console.WriteLine("\nPlaylist after removing current song:");
foreach (string song in playlist)
{
    Console.WriteLine($"♪ {song}");
}
```

**Key LinkedList Features Demonstrated:**
- **AddAfter/AddBefore**: Insert songs anywhere in the playlist
- **Find**: Locate a specific song
- **Remove**: Delete any song without shifting other songs
- **Next/Previous**: Navigate through the playlist
- Unlike a List, removing items from middle is very fast!

---

**Example 3: Advanced - Train Car Management System**

This advanced example shows a real-world scenario of managing train cars.

```csharp
LinkedList<string> train = new LinkedList<string>();

// Build the train
train.AddLast("Locomotive");    // Engine at front
train.AddLast("Passenger-A");
train.AddLast("Passenger-B");
train.AddLast("Dining Car");
train.AddLast("Passenger-C");
train.AddLast("Caboose");       // Last car

Console.WriteLine("=== INITIAL TRAIN CONFIGURATION ===");
DisplayTrain(train);

// Emergency: Need to add a medical car right after the locomotive
LinkedListNode<string> locomotive = train.First;
train.AddAfter(locomotive, "Medical Car");
Console.WriteLine("\n=== AFTER ADDING MEDICAL CAR ===");
DisplayTrain(train);

// Dining car needs maintenance - disconnect it
LinkedListNode<string> diningCar = train.Find("Dining Car");
LinkedListNode<string> carBeforeDining = diningCar.Previous;
LinkedListNode<string> carAfterDining = diningCar.Next;

train.Remove(diningCar); // Disconnect dining car
Console.WriteLine("\n=== AFTER REMOVING DINING CAR ===");
DisplayTrain(train);

// Count total cars
int totalCars = 0;
LinkedListNode<string> current = train.First;
while (current != null)
{
    totalCars++;
    current = current.Next;
}
Console.WriteLine($"\nTotal cars in train: {totalCars}");

// Find all passenger cars
Console.WriteLine("\nPassenger cars:");
current = train.First;
while (current != null)
{
    if (current.Value.StartsWith("Passenger"))
    {
        Console.WriteLine($"  - {current.Value}");
    }
    current = current.Next;
}

// Helper method to display the train
static void DisplayTrain(LinkedList<string> train)
{
    LinkedListNode<string> car = train.First;
    while (car != null)
    {
        Console.Write($"[{car.Value}]");
        if (car.Next != null)
            Console.Write(" <-> ");
        car = car.Next;
    }
    Console.WriteLine();
}
```

**Advanced Concepts Here:**
- **Dynamic restructuring**: Adding and removing from middle
- **Node navigation**: Moving through the list using while loops
- **Reference tracking**: Keeping track of nodes before/after operations
- **Custom iteration**: Manually walking through nodes for filtering
- **Real-world modeling**: LinkedList perfectly represents connected train cars!

**When to use LinkedList vs List:**
- Use LinkedList when you frequently insert/remove from the middle
- Use List when you mostly access items by index
- LinkedList excels at: playlists, browser history, undo/redo chains
- List excels at: ordered collections, random access, simple iterations

---

### 3. ObservableCollection&lt;T&gt; - The Alert System 🔔

**What is it?**
It's like a List, but it tells everyone when something changes! Like a teacher who announces when a student is added or removed from class.

**When to use it:**
- In applications with user interfaces (like Windows apps)
- When you want the screen to automatically update when data changes

**Example: Live Shopping Cart**

```csharp
using System.Collections.ObjectModel;

ObservableCollection<string> shoppingCart = new ObservableCollection<string>();

// Listen for changes
shoppingCart.CollectionChanged += (sender, e) =>
{
    if (e.Action == NotifyCollectionChangedAction.Add)
        Console.WriteLine($"Added: {e.NewItems[0]}");
    if (e.Action == NotifyCollectionChangedAction.Remove)
        Console.WriteLine($"Removed: {e.OldItems[0]}");
};

shoppingCart.Add("Laptop");    // Console: "Added: Laptop"
shoppingCart.Add("Mouse");     // Console: "Added: Mouse"
shoppingCart.Remove("Laptop"); // Console: "Removed: Laptop"
```

---

## Dictionary Collections

### 4. Dictionary&lt;TKey, TValue&gt; - The Super-Fast Phone Book 📞

**What is it?**
Imagine a phone book where you can instantly find someone's number by their name. A Dictionary stores pairs: a key (like a name) and a value (like a phone number).

**Real-life example:** A real phone book, a translation dictionary (English word → Spanish word), or a student ID system (ID → Student Name).

**When to use it:**
- When you need to look up values using a unique key
- When you want super-fast search
- When each key must be unique

**Basic Operations:**

```csharp
Dictionary<string, int> studentAges = new Dictionary<string, int>();

// Adding key-value pairs
studentAges.Add("Alice", 10);
studentAges.Add("Bob", 11);
studentAges.Add("Charlie", 10);

// Or using initializer
var studentAges2 = new Dictionary<string, int>
{
    { "Alice", 10 },
    { "Bob", 11 },
    { "Charlie", 10 }
};

// Getting values by key
int aliceAge = studentAges["Alice"]; // 10

// Safe way to get values
if (studentAges.TryGetValue("David", out int davidAge))
{
    Console.WriteLine($"David is {davidAge} years old");
}
else
{
    Console.WriteLine("David not found");
}

// Updating values
studentAges["Alice"] = 11; // Alice had a birthday!

// Checking if key exists
bool hasBob = studentAges.ContainsKey("Bob"); // true

// Removing an entry
studentAges.Remove("Charlie");

// Looping through dictionary
foreach (KeyValuePair<string, int> entry in studentAges)
{
    Console.WriteLine($"{entry.Key} is {entry.Value} years old");
}
```

**Example 1: Word Counter (Frequency Analysis)**

This example shows how Dictionary makes counting easy and fast.

```csharp
// A sample sentence - notice "hello" and "world" repeat
string text = "hello world hello everyone hello world";
string[] words = text.Split(' '); // Split into individual words

Dictionary<string, int> wordCount = new Dictionary<string, int>();

// Count each word
foreach (string word in words)
{
    // Check if we've seen this word before
    if (wordCount.ContainsKey(word))
    {
        wordCount[word]++; // Increase count by 1
        // If "hello" was 2, now it's 3
    }
    else
    {
        wordCount[word] = 1; // First time seeing this word
    }
}

// Display results
Console.WriteLine("=== WORD FREQUENCY ===");
foreach (var entry in wordCount)
{
    Console.WriteLine($"{entry.Key}: {entry.Value} times");
}
/* Output:
hello: 3 times
world: 2 times
everyone: 1 times
*/

// Find the most common word
string mostCommonWord = "";
int highestCount = 0;

foreach (var entry in wordCount)
{
    if (entry.Value > highestCount)
    {
        highestCount = entry.Value;
        mostCommonWord = entry.Key;
    }
}

Console.WriteLine($"\nMost common word: '{mostCommonWord}' appears {highestCount} times");
```

**Why Dictionary is perfect here:**
- **Fast lookup**: Checking if a word exists is instant, even with thousands of words
- **Key-value storage**: Word (key) maps to its count (value)
- **No duplicates**: Each word appears only once as a key
- **Easy updates**: We can quickly increment the count

---

**Example 2: English to Spanish Translator**

A simple translation system showing safe value retrieval.

```csharp
// Build our translation dictionary
Dictionary<string, string> translator = new Dictionary<string, string>
{
    { "hello", "hola" },
    { "goodbye", "adiós" },
    { "thank you", "gracias" },
    { "friend", "amigo" },
    { "water", "agua" },
    { "food", "comida" }
};

// Method 1: Direct access (might throw error if key doesn't exist!)
string englishWord = "hello";
string spanish = translator[englishWord]; // Works! Returns "hola"
Console.WriteLine($"{englishWord} → {spanish}");

// Method 2: Safe way using TryGetValue (RECOMMENDED!)
string wordToTranslate = "hello";
if (translator.TryGetValue(wordToTranslate, out string translation))
{
    Console.WriteLine($"'{wordToTranslate}' in Spanish is '{translation}'");
}
else
{
    Console.WriteLine($"Sorry, '{wordToTranslate}' not found in dictionary");
}

// Try a word that doesn't exist
wordToTranslate = "computer";
if (translator.TryGetValue(wordToTranslate, out translation))
{
    Console.WriteLine($"'{wordToTranslate}' in Spanish is '{translation}'");
}
else
{
    Console.WriteLine($"Sorry, '{wordToTranslate}' not found in dictionary");
    // Output: Sorry, 'computer' not found in dictionary
}

// Add new words to the dictionary
translator.Add("computer", "computadora");
Console.WriteLine($"Dictionary now has {translator.Count} words");

// Update an existing translation
translator["friend"] = "amiga"; // Changed from "amigo" to "amiga"
```

**Important Dictionary Concepts:**
- **TryGetValue is safer**: Won't crash if key doesn't exist
- **Keys must be unique**: Can't have two "hello" entries
- **Updating**: Use dictionary[key] = newValue
- **Adding**: Use Add() method or dictionary[key] = value if key doesn't exist

---

**Example 3: Advanced - Student Database System**

A comprehensive example showing complex Dictionary usage.

```csharp
// Store student information: ID → Name
Dictionary<int, string> students = new Dictionary<int, string>
{
    { 101, "Alice Johnson" },
    { 102, "Bob Smith" },
    { 103, "Charlie Brown" },
    { 104, "Diana Prince" }
};

// Store grades: ID → List of test scores
Dictionary<int, List<int>> studentGrades = new Dictionary<int, List<int>>
{
    { 101, new List<int> { 85, 92, 88, 90 } },
    { 102, new List<int> { 78, 82, 75, 80 } },
    { 103, new List<int> { 95, 98, 92, 96 } },
    { 104, new List<int> { 88, 85, 90, 87 } }
};

// Store email addresses: ID → Email
Dictionary<int, string> studentEmails = new Dictionary<int, string>
{
    { 101, "alice@school.com" },
    { 102, "bob@school.com" },
    { 103, "charlie@school.com" },
    { 104, "diana@school.com" }
};

Console.WriteLine("=== STUDENT MANAGEMENT SYSTEM ===\n");

// Function to calculate average grade for a student
double CalculateAverage(List<int> grades)
{
    double sum = 0;
    foreach (int grade in grades)
    {
        sum += grade;
    }
    return sum / grades.Count;
}

// Display complete student information
foreach (var studentId in students.Keys)
{
    string name = students[studentId];
    List<int> grades = studentGrades[studentId];
    string email = studentEmails[studentId];
    double average = CalculateAverage(grades);
    
    Console.WriteLine($"ID: {studentId}");
    Console.WriteLine($"Name: {name}");
    Console.WriteLine($"Email: {email}");
    Console.Write($"Grades: ");
    foreach (int grade in grades)
    {
        Console.Write($"{grade} ");
    }
    Console.WriteLine($"\nAverage: {average:F2}");
    Console.WriteLine("---");
}

// Find student with highest average
int topStudentId = 0;
double highestAverage = 0;

foreach (var studentId in students.Keys)
{
    double average = CalculateAverage(studentGrades[studentId]);
    if (average > highestAverage)
    {
        highestAverage = average;
        topStudentId = studentId;
    }
}

Console.WriteLine($"\n🏆 TOP STUDENT: {students[topStudentId]}");
Console.WriteLine($"   Average: {highestAverage:F2}");

// Add a new student (add to all dictionaries)
int newId = 105;
students.Add(newId, "Eve Martinez");
studentGrades.Add(newId, new List<int> { 90, 93, 89 });
studentEmails.Add(newId, "eve@school.com");

Console.WriteLine($"\n✅ New student added: {students[newId]}");
Console.WriteLine($"   Total students: {students.Count}");

// Search for a student by name
string searchName = "Bob Smith";
int foundId = -1;

foreach (var entry in students)
{
    if (entry.Value == searchName)
    {
        foundId = entry.Key;
        break;
    }
}

if (foundId != -1)
{
    Console.WriteLine($"\n🔍 Found {searchName}");
    Console.WriteLine($"   ID: {foundId}");
    Console.WriteLine($"   Email: {studentEmails[foundId]}");
    Console.WriteLine($"   Average: {CalculateAverage(studentGrades[foundId]):F2}");
}

// Get all students with average above 90
Console.WriteLine("\n⭐ HONOR ROLL (Average > 90):");
foreach (var studentId in students.Keys)
{
    double average = CalculateAverage(studentGrades[studentId]);
    if (average > 90)
    {
        Console.WriteLine($"   • {students[studentId]}: {average:F2}");
    }
}
```

**Advanced Dictionary Patterns:**
1. **Multiple related dictionaries**: All use the same key (student ID)
2. **Dictionary of collections**: studentGrades stores a List for each student
3. **Searching by value**: Loop through entries to find by name (not key)
4. **Synchronized operations**: When adding a student, update all dictionaries
5. **Complex queries**: Filter students based on calculated values

**Real-world Applications:**
- User management systems (ID → User data)
- Product catalogs (SKU → Product info)
- Configuration settings (Setting name → Value)
- Caching systems (Key → Cached result)
- Phone books (Name → Phone number)

---

### 5. SortedDictionary&lt;TKey, TValue&gt; - The Organized Phone Book 📖

**What is it?**
Like a regular Dictionary, but it always keeps the keys in alphabetical (or numerical) order!

**When to use it:**
- When you need data sorted by keys
- When you frequently need items in order

```csharp
SortedDictionary<string, int> scores = new SortedDictionary<string, int>
{
    { "Charlie", 85 },
    { "Alice", 95 },
    { "Bob", 90 }
};

foreach (var entry in scores)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}
// Output (notice alphabetical order):
// Alice: 95
// Bob: 90
// Charlie: 85
```

---

## Set Collections

### 6. HashSet&lt;T&gt; - The Unique Items Club 🎭

**What is it?**
Imagine a club where each member must be unique - no duplicates allowed! A HashSet only stores unique values.

**Real-life example:** A collection of unique student IDs, unique tags on a blog post, or a set of distinct colors.

**When to use it:**
- When you only want unique items
- When you need fast checking if an item exists
- When order doesn't matter

**Basic Operations:**

```csharp
HashSet<string> uniqueNames = new HashSet<string>();

// Adding items
uniqueNames.Add("Alice");   // true (added successfully)
uniqueNames.Add("Bob");     // true
uniqueNames.Add("Alice");   // false (already exists!)

Console.WriteLine(uniqueNames.Count); // 2 (only unique items)

// Checking membership (very fast!)
bool hasAlice = uniqueNames.Contains("Alice"); // true

// Set operations
HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4 };
HashSet<int> setB = new HashSet<int> { 3, 4, 5, 6 };

// Union (all items from both)
HashSet<int> union = new HashSet<int>(setA);
union.UnionWith(setB); // { 1, 2, 3, 4, 5, 6 }

// Intersection (items in both)
HashSet<int> intersection = new HashSet<int>(setA);
intersection.IntersectWith(setB); // { 3, 4 }

// Difference (items in A but not in B)
HashSet<int> difference = new HashSet<int>(setA);
difference.ExceptWith(setB); // { 1, 2 }
```

**Example 1: Remove Duplicates from List**

This shows the most common use of HashSet - ensuring uniqueness.

```csharp
// A list with many duplicate numbers
List<int> numbersWithDuplicates = new List<int> 
{ 
    1, 2, 2, 3, 4, 4, 4, 5, 1, 2, 5, 6, 6 
};

Console.WriteLine("Original list:");
foreach (int num in numbersWithDuplicates)
{
    Console.Write(num + " "); // 1 2 2 3 4 4 4 5 1 2 5 6 6
}
Console.WriteLine($"\nTotal items: {numbersWithDuplicates.Count}"); // 13

// Convert to HashSet - automatically removes duplicates!
HashSet<int> uniqueNumbers = new HashSet<int>(numbersWithDuplicates);

Console.WriteLine("\nUnique numbers:");
foreach (int num in uniqueNumbers)
{
    Console.Write(num + " "); // 1 2 3 4 5 6 (order may vary)
}
Console.WriteLine($"\nTotal unique items: {uniqueNumbers.Count}"); // 6

// Convert back to List if needed
List<int> cleanList = new List<int>(uniqueNumbers);
```

**Why this works:**
- HashSet only stores unique values - duplicates are automatically ignored
- When you pass a List to HashSet's constructor, it processes all items and keeps only unique ones
- This is much faster than manually checking for duplicates!

---

**Example 2: Find Common Friends (Set Intersection)**

This demonstrates powerful set operations.

```csharp
// Alice's friends
HashSet<string> aliceFriends = new HashSet<string> 
{ 
    "Bob", "Charlie", "David", "Eve", "Frank"
};

// Bob's friends
HashSet<string> bobFriends = new HashSet<string> 
{ 
    "Alice", "Charlie", "George", "Eve", "Hannah"
};

Console.WriteLine("Alice's friends:");
foreach (string friend in aliceFriends)
{
    Console.WriteLine($"  • {friend}");
}

Console.WriteLine("\nBob's friends:");
foreach (string friend in bobFriends)
{
    Console.WriteLine($"  • {friend}");
}

// INTERSECTION: Friends they have in common
HashSet<string> commonFriends = new HashSet<string>(aliceFriends);
commonFriends.IntersectWith(bobFriends);

Console.WriteLine("\n🤝 Friends in common:");
foreach (string friend in commonFriends)
{
    Console.WriteLine($"  • {friend}"); // Charlie, Eve
}

// UNION: All unique friends between both
HashSet<string> allFriends = new HashSet<string>(aliceFriends);
allFriends.UnionWith(bobFriends);

Console.WriteLine("\n👥 All friends (combined):");
foreach (string friend in allFriends)
{
    Console.WriteLine($"  • {friend}");
}
Console.WriteLine($"Total: {allFriends.Count} unique friends");

// DIFFERENCE: Friends Alice has but Bob doesn't
HashSet<string> onlyAliceFriends = new HashSet<string>(aliceFriends);
onlyAliceFriends.ExceptWith(bobFriends);

Console.WriteLine("\n📌 Only Alice's friends (not Bob's):");
foreach (string friend in onlyAliceFriends)
{
    Console.WriteLine($"  • {friend}"); // Bob, David, Frank
}

// SYMMETRIC DIFFERENCE: Friends of either but not both
HashSet<string> exclusiveFriends = new HashSet<string>(aliceFriends);
exclusiveFriends.SymmetricExceptWith(bobFriends);

Console.WriteLine("\n🔀 Friends of one but not both:");
foreach (string friend in exclusiveFriends)
{
    Console.WriteLine($"  • {friend}");
}
```

**Set Operations Explained:**
1. **IntersectWith**: Items in BOTH sets (common friends)
2. **UnionWith**: Items in EITHER set (all friends combined)
3. **ExceptWith**: Items in first set but NOT in second
4. **SymmetricExceptWith**: Items in one set OR the other, but not both

**Visual Example:**
```
Alice: {Bob, Charlie, David, Eve, Frank}
Bob:   {Alice, Charlie, George, Eve, Hannah}

Intersection: {Charlie, Eve}        ← in both
Union: {Alice, Bob, Charlie, David, Eve, Frank, George, Hannah} ← all
Except: {Bob, David, Frank}         ← only in Alice
SymmetricExcept: {Alice, Bob, David, Frank, George, Hannah} ← not in both
```

---

**Example 3: Advanced - Unique Visitor Tracking System**

A realistic web analytics scenario.

```csharp
// Track all visits (including repeat visitors)
List<string> allVisits = new List<string>();

// Track unique visitors (no duplicates)
HashSet<string> uniqueVisitors = new HashSet<string>();

// Simulate 20 website visits
string[] visitors = 
{
    "user123", "user456", "user789", "user123", // user123 visited twice
    "user456", "user111", "user222", "user123", // user456 and user123 again
    "user333", "user444", "user555", "user456", // user456 again
    "user666", "user777", "user888", "user999",
    "user123", "user456", "user111", "user222"  // more repeats
};

Console.WriteLine("=== WEBSITE VISITOR TRACKING ===\n");

// Process each visit
foreach (string visitor in visitors)
{
    allVisits.Add(visitor); // Record every visit
    
    bool isNewVisitor = uniqueVisitors.Add(visitor);
    // Add() returns true if item was added (new visitor)
    // returns false if item already existed (returning visitor)
    
    if (isNewVisitor)
    {
        Console.WriteLine($"👋 NEW visitor: {visitor}");
    }
    else
    {
        Console.WriteLine($"🔁 Returning visitor: {visitor}");
    }
}

// Calculate statistics
Console.WriteLine("\n=== ANALYTICS ===");
Console.WriteLine($"Total visits: {allVisits.Count}");
Console.WriteLine($"Unique visitors: {uniqueVisitors.Count}");

double uniquePercentage = (double)uniqueVisitors.Count / allVisits.Count * 100;
Console.WriteLine($"Unique visitor rate: {uniquePercentage:F1}%");

// Find how many times each visitor came
Dictionary<string, int> visitCount = new Dictionary<string, int>();

foreach (string visitor in allVisits)
{
    if (visitCount.ContainsKey(visitor))
        visitCount[visitor]++;
    else
        visitCount[visitor] = 1;
}

// Find most frequent visitor
string mostFrequent = "";
int maxVisits = 0;

foreach (var entry in visitCount)
{
    if (entry.Value > maxVisits)
    {
        maxVisits = entry.Value;
        mostFrequent = entry.Key;
    }
}

Console.WriteLine($"\n🏆 Most frequent visitor: {mostFrequent}");
Console.WriteLine($"   Visited {maxVisits} times");

// Show visitors who came more than once
Console.WriteLine("\n🔁 Repeat visitors:");
foreach (var entry in visitCount)
{
    if (entry.Value > 1)
    {
        Console.WriteLine($"   • {entry.Key}: {entry.Value} visits");
    }
}

// Show one-time visitors
Console.WriteLine("\n👤 One-time visitors:");
foreach (var entry in visitCount)
{
    if (entry.Value == 1)
    {
        Console.WriteLine($"   • {entry.Key}");
    }
}
```

**Advanced HashSet Features:**
1. **Add() return value**: Returns true/false to indicate if item was new
2. **Fast membership testing**: Contains() is super fast even with millions of items
3. **Combining with Dictionary**: HashSet for uniqueness, Dictionary for counting
4. **Real-time analytics**: Track unique vs total in real-time

**Performance Benefits:**
- Checking if a visitor exists: O(1) - instant!
- With a List, you'd need to check every item: O(n) - slow!
- For 1 million visits, HashSet is thousands of times faster!

**Real-World Uses:**
- Tracking unique users, IPs, emails
- Removing duplicate records
- Finding unique tags, categories, keywords
- Membership testing (is user banned? is email registered?)

---

### 7. SortedSet&lt;T&gt; - The Organized Unique Club 🎪

**What is it?**
Like a HashSet, but it keeps items sorted!

```csharp
SortedSet<int> scores = new SortedSet<int> { 85, 92, 78, 92, 88 };

// Automatically sorted and no duplicates
foreach (int score in scores)
{
    Console.Write(score + " "); // 78 85 88 92
}
```

---

## Stack Collections

### 8. Stack&lt;T&gt; - The Plate Stack 🥞

**What is it?**
Think of a stack of plates. You can only add a plate on top (Push) and take a plate from the top (Pop). The last plate you put on is the first one you take off - this is called LIFO (Last In, First Out).

**Real-life example:** A stack of books, browser back button, undo feature in apps, or a stack of pancakes!

**When to use it:**
- Undo/Redo operations
- Going back in browser history
- Checking balanced parentheses in code

**Basic Operations:**

```csharp
Stack<string> books = new Stack<string>();

// Push (add to top)
books.Push("Harry Potter");
books.Push("Lord of the Rings");
books.Push("The Hobbit");

// Stack looks like (top to bottom):
// "The Hobbit" <- top
// "Lord of the Rings"
// "Harry Potter"

// Peek (look at top without removing)
string topBook = books.Peek(); // "The Hobbit"

// Pop (remove from top)
string removed = books.Pop(); // Removes "The Hobbit"

Console.WriteLine(books.Count); // 2

// Pop again
string removed2 = books.Pop(); // Removes "Lord of the Rings"
```

**Example 1: Simple Undo Feature**

Understanding Stack through a basic undo system.

```csharp
Stack<string> actions = new Stack<string>();

// User performs actions in a text editor
Console.WriteLine("=== TEXT EDITOR ACTIONS ===\n");

actions.Push("Typed 'Hello'");
Console.WriteLine("Action: Typed 'Hello'");
Console.WriteLine($"Actions in history: {actions.Count}");

actions.Push("Changed font to Bold");
Console.WriteLine("Action: Changed font to Bold");
Console.WriteLine($"Actions in history: {actions.Count}");

actions.Push("Changed color to Red");
Console.WriteLine("Action: Changed color to Red");
Console.WriteLine($"Actions in history: {actions.Count}");

// Stack looks like (top to bottom):
// "Changed color to Red"    ← top (most recent)
// "Changed font to Bold"
// "Typed 'Hello'"           ← bottom (oldest)

Console.WriteLine("\n=== UNDO OPERATIONS ===\n");

// User clicks Undo (Ctrl+Z)
if (actions.Count > 0)
{
    string undone = actions.Pop(); // Remove and return top item
    Console.WriteLine($"Undoing: {undone}");
    Console.WriteLine($"Remaining actions: {actions.Count}");
}

// Undo again
if (actions.Count > 0)
{
    string undone = actions.Pop();
    Console.WriteLine($"Undoing: {undone}");
    Console.WriteLine($"Remaining actions: {actions.Count}");
}

// Peek at what would be undone next (without removing it)
if (actions.Count > 0)
{
    string nextUndo = actions.Peek();
    Console.WriteLine($"\nNext undo would be: {nextUndo}");
    Console.WriteLine($"Still {actions.Count} action(s) in history");
}
```

**Key Stack Concepts:**
- **Push**: Add to top (like placing a plate on a stack)
- **Pop**: Remove from top (like taking the top plate)
- **Peek**: Look at top without removing (like looking at top plate)
- **LIFO**: Last In, First Out - newest item is accessed first

---

**Example 2: Reverse a String**

A classic Stack application - reversing order.

```csharp
string originalWord = "HELLO";
Console.WriteLine($"Original word: {originalWord}");

// Create a stack and push each character
Stack<char> charStack = new Stack<char>();

foreach (char c in originalWord)
{
    charStack.Push(c);
    Console.WriteLine($"Pushed: {c} | Stack now has {charStack.Count} items");
}

// Stack looks like (top to bottom):
// 'O' ← top (last letter pushed)
// 'L'
// 'L'
// 'E'
// 'H' ← bottom (first letter pushed)

// Pop all characters to build reversed string
string reversedWord = "";
Console.WriteLine("\nPopping characters:");

while (charStack.Count > 0)
{
    char c = charStack.Pop();
    reversedWord += c;
    Console.WriteLine($"Popped: {c} | Reversed so far: {reversedWord}");
}

Console.WriteLine($"\nOriginal: {originalWord}");
Console.WriteLine($"Reversed: {reversedWord}"); // "OLLEH"
```

**Why this works:**
- When we push H-E-L-L-O, the stack becomes (bottom→top): H,E,L,L,O
- When we pop, we get O-L-L-E-H (exactly reversed!)
- Stack automatically reverses the order!

---

**Example 3: Check Balanced Parentheses**

A more complex Stack usage - matching opening and closing brackets.

```csharp
string[] testExpressions = 
{
    "((2 + 3) * 4)",           // Balanced ✓
    "((2 + 3) * (4 - 1))",     // Balanced ✓
    "((2 + 3)",                // NOT balanced - missing )
    "(2 + 3))",                // NOT balanced - extra )
    "({[2 + 3] * 4})",         // Balanced ✓
    "({[2 + 3)} * 4]",         // NOT balanced - wrong order
};

foreach (string expression in testExpressions)
{
    bool isBalanced = CheckBalancedParentheses(expression);
    string status = isBalanced ? "✓ BALANCED" : "✗ NOT BALANCED";
    Console.WriteLine($"{expression,-25} → {status}");
}

// Function to check if parentheses/brackets/braces are balanced
static bool CheckBalancedParentheses(string expression)
{
    Stack<char> stack = new Stack<char>();
    
    // Define matching pairs
    Dictionary<char, char> matchingBrackets = new Dictionary<char, char>
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' }
    };
    
    foreach (char c in expression)
    {
        // If it's an opening bracket, push it
        if (c == '(' || c == '[' || c == '{')
        {
            stack.Push(c);
            Console.WriteLine($"  Pushed opening: {c}");
        }
        // If it's a closing bracket
        else if (c == ')' || c == ']' || c == '}')
        {
            // Check if there's a matching opening bracket
            if (stack.Count == 0)
            {
                Console.WriteLine($"  ✗ Found closing {c} but no opening bracket!");
                return false; // No matching opening bracket
            }
            
            char opening = stack.Pop();
            char expectedOpening = matchingBrackets[c];
            
            if (opening != expectedOpening)
            {
                Console.WriteLine($"  ✗ Mismatched: found {c} but top was {opening}");
                return false; // Wrong type of bracket
            }
            
            Console.WriteLine($"  Matched {opening} with {c} ✓");
        }
    }
    
    // If stack is empty, all brackets were matched
    bool balanced = stack.Count == 0;
    
    if (!balanced)
    {
        Console.WriteLine($"  ✗ {stack.Count} unclosed bracket(s) remaining");
    }
    
    return balanced;
}
```

**How the Algorithm Works:**

1. **Opening bracket** (, [, { → Push onto stack
2. **Closing bracket** ), ], } → Pop from stack and check if they match
3. **At the end** → Stack should be empty (all opened brackets were closed)

**Example walkthrough for "((2+3))":**
```
Character '(': Push → Stack: ['(']
Character '(': Push → Stack: ['(', '(']
Character ')': Pop → Match! Stack: ['(']
Character ')': Pop → Match! Stack: []
Result: Balanced ✓ (stack is empty)
```

**Example walkthrough for "((2+3)":**
```
Character '(': Push → Stack: ['(']
Character '(': Push → Stack: ['(', '(']
Character ')': Pop → Match! Stack: ['(']
End of string → Stack still has '(' 
Result: NOT Balanced ✗ (unclosed bracket)
```

---

**Example 4: Advanced - Expression Evaluator with Undo/Redo**

A sophisticated Stack application combining multiple concepts.

```csharp
class CalculatorWithHistory
{
    private Stack<double> undoStack = new Stack<double>(); // Previous results
    private Stack<double> redoStack = new Stack<double>(); // Undone results
    private double currentResult = 0;
    
    public void PerformCalculation(string operation, double number)
    {
        // Save current state before making changes
        undoStack.Push(currentResult);
        
        // Clear redo stack when new operation is performed
        redoStack.Clear();
        
        // Perform the operation
        switch (operation)
        {
            case "add":
                currentResult += number;
                break;
            case "subtract":
                currentResult -= number;
                break;
            case "multiply":
                currentResult *= number;
                break;
            case "divide":
                if (number != 0)
                    currentResult /= number;
                break;
        }
        
        Console.WriteLine($"Performed: {operation} {number} → Result: {currentResult}");
    }
    
    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            // Save current state to redo stack
            redoStack.Push(currentResult);
            
            // Restore previous state
            currentResult = undoStack.Pop();
            
            Console.WriteLine($"Undo → Result restored to: {currentResult}");
        }
        else
        {
            Console.WriteLine("Nothing to undo!");
        }
    }
    
    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            // Save current state to undo stack
            undoStack.Push(currentResult);
            
            // Restore redone state
            currentResult = redoStack.Pop();
            
            Console.WriteLine($"Redo → Result restored to: {currentResult}");
        }
        else
        {
            Console.WriteLine("Nothing to redo!");
        }
    }
    
    public void ShowHistory()
    {
        Console.WriteLine("\n=== HISTORY ===");
        Console.WriteLine($"Current Result: {currentResult}");
        Console.WriteLine($"Undo stack: {undoStack.Count} item(s)");
        Console.WriteLine($"Redo stack: {redoStack.Count} item(s)");
    }
}

// Using the calculator
var calc = new CalculatorWithHistory();

calc.PerformCalculation("add", 10);       // 0 + 10 = 10
calc.PerformCalculation("add", 5);        // 10 + 5 = 15
calc.PerformCalculation("multiply", 2);   // 15 * 2 = 30
calc.ShowHistory();

calc.Undo();  // Back to 15
calc.Undo();  // Back to 10
calc.ShowHistory();

calc.Redo();  // Forward to 15
calc.ShowHistory();

calc.PerformCalculation("subtract", 3);   // 15 - 3 = 12
calc.ShowHistory();  // Redo stack is now empty!
```

**Advanced Stack Patterns Here:**
1. **Dual stacks**: One for undo, one for redo
2. **State management**: Saving complete state before changes
3. **Stack clearing**: New actions clear redo stack
4. **Stack synchronization**: Moving data between stacks

**Real-World Applications:**
- Text editors (Word, VS Code)
- Image editors (Photoshop, GIMP)
- IDEs (Visual Studio)
- Browsers (back/forward navigation)
- Games (replay systems)

---

## Queue Collections

### 9. Queue&lt;T&gt; - The Fair Line 👥

**What is it?**
Think of a line at a cafeteria. The first person to join the line is the first person to get served. This is called FIFO (First In, First Out).

**Real-life example:** A line at a ticket counter, print queue, customer service line, or waiting in line for a ride.

**When to use it:**
- Processing tasks in order
- Managing requests
- Breadth-first search in games/algorithms

**Basic Operations:**

```csharp
Queue<string> customerLine = new Queue<string>();

// Enqueue (join the line at the back)
customerLine.Enqueue("Alice");
customerLine.Enqueue("Bob");
customerLine.Enqueue("Charlie");

// Line looks like:
// Alice (front) -> Bob -> Charlie (back)

// Peek (see who's first without removing)
string first = customerLine.Peek(); // "Alice"

// Dequeue (serve the first person and remove them)
string served = customerLine.Dequeue(); // "Alice" is served
served = customerLine.Dequeue();        // "Bob" is served

Console.WriteLine(customerLine.Count); // 1 (only Charlie left)
```

**Example 1: Print Queue**

Understanding Queue through a printer system.

```csharp
Queue<string> printQueue = new Queue<string>();

Console.WriteLine("=== PRINTER QUEUE SYSTEM ===\n");

// Users send documents to print
printQueue.Enqueue("Document1.pdf");
Console.WriteLine("Added to queue: Document1.pdf");
Console.WriteLine($"Queue length: {printQueue.Count}");

printQueue.Enqueue("Photo.jpg");
Console.WriteLine("Added to queue: Photo.jpg");
Console.WriteLine($"Queue length: {printQueue.Count}");

printQueue.Enqueue("Report.docx");
Console.WriteLine("Added to queue: Report.docx");
Console.WriteLine($"Queue length: {printQueue.Count}");

printQueue.Enqueue("Presentation.pptx");
Console.WriteLine("Added to queue: Presentation.pptx");
Console.WriteLine($"Queue length: {printQueue.Count}");

// Queue looks like (front → back):
// Document1.pdf (front) → Photo.jpg → Report.docx → Presentation.pptx (back)

Console.WriteLine("\n=== PROCESSING PRINT JOBS ===\n");

// Peek at what's next without removing
string nextJob = printQueue.Peek();
Console.WriteLine($"Next job to print: {nextJob}");
Console.WriteLine($"Queue still has: {printQueue.Count} jobs\n");

// Process the queue (print documents in order)
int jobNumber = 1;
while (printQueue.Count > 0)
{
    string document = printQueue.Dequeue(); // Remove and return first item
    Console.WriteLine($"[{jobNumber}] Printing: {document}");
    Console.WriteLine($"    Remaining in queue: {printQueue.Count}");
    
    // Simulate printing time
    System.Threading.Thread.Sleep(500); // Wait half a second
    Console.WriteLine($"    ✓ Completed!\n");
    
    jobNumber++;
}

Console.WriteLine("All print jobs completed!");
```

**Key Queue Concepts:**
- **Enqueue**: Add to back of line (like joining a queue)
- **Dequeue**: Remove from front of line (like being served)
- **Peek**: See who's first without removing them
- **FIFO**: First In, First Out - earliest item is processed first

**Real-world analogy:**
Think of a line at McDonald's:
- New customers join at the BACK (Enqueue)
- Cashier serves from the FRONT (Dequeue)
- First person in line gets served first (FIFO)

---

**Example 2: Customer Service System**

A more detailed Queue example with priority information.

```csharp
// Simple customer class to hold information
class Customer
{
    public string Name { get; set; }
    public string Issue { get; set; }
    public DateTime ArrivalTime { get; set; }
    
    public Customer(string name, string issue)
    {
        Name = name;
        Issue = issue;
        ArrivalTime = DateTime.Now;
    }
}

Queue<Customer> waitingLine = new Queue<Customer>();

Console.WriteLine("=== CUSTOMER SERVICE CENTER ===\n");

// Customers arrive and join the queue
var customer1 = new Customer("Alice", "Product return");
waitingLine.Enqueue(customer1);
Console.WriteLine($"Customer joined: {customer1.Name} - {customer1.Issue}");
Console.WriteLine($"Queue position: {waitingLine.Count}\n");
System.Threading.Thread.Sleep(100);

var customer2 = new Customer("Bob", "Technical support");
waitingLine.Enqueue(customer2);
Console.WriteLine($"Customer joined: {customer2.Name} - {customer2.Issue}");
Console.WriteLine($"Queue position: {waitingLine.Count}\n");
System.Threading.Thread.Sleep(100);

var customer3 = new Customer("Charlie", "General inquiry");
waitingLine.Enqueue(customer3);
Console.WriteLine($"Customer joined: {customer3.Name} - {customer3.Issue}");
Console.WriteLine($"Queue position: {waitingLine.Count}\n");
System.Threading.Thread.Sleep(100);

var customer4 = new Customer("Diana", "Billing question");
waitingLine.Enqueue(customer4);
Console.WriteLine($"Customer joined: {customer4.Name} - {customer4.Issue}");
Console.WriteLine($"Queue position: {waitingLine.Count}\n");

Console.WriteLine("=== SERVICE DESK IS NOW OPEN ===\n");

// Process customers in order (FIFO)
int ticketNumber = 1;
while (waitingLine.Count > 0)
{
    // Peek at next customer
    Customer nextCustomer = waitingLine.Peek();
    Console.WriteLine($"Now calling ticket #{ticketNumber}: {nextCustomer.Name}");
    Console.WriteLine($"Customers still waiting: {waitingLine.Count - 1}");
    
    // Serve the customer (remove from queue)
    Customer currentCustomer = waitingLine.Dequeue();
    
    // Calculate wait time
    TimeSpan waitTime = DateTime.Now - currentCustomer.ArrivalTime;
    
    Console.WriteLine($"Issue: {currentCustomer.Issue}");
    Console.WriteLine($"Wait time: {waitTime.TotalSeconds:F1} seconds");
    Console.WriteLine($"✓ Service completed\n");
    
    ticketNumber++;
    System.Threading.Thread.Sleep(300);
}

Console.WriteLine("All customers have been served!");
```

**Important Queue Patterns:**
1. **Object storage**: Queue can hold complex objects, not just strings/numbers
2. **FIFO guarantee**: Fair system - first to arrive is first served
3. **Queue monitoring**: Check Count to see how many are waiting
4. **Peek before process**: Look at next item without removing it

---

**Example 3: Advanced - Multi-Level Task Processing System**

A sophisticated Queue example showing real-world task management.

```csharp
// Task class with priority
class Task
{
    public string Name { get; set; }
    public string Priority { get; set; }
    public int EstimatedMinutes { get; set; }
    
    public Task(string name, string priority, int minutes)
    {
        Name = name;
        Priority = priority;
        EstimatedMinutes = minutes;
    }
    
    public override string ToString()
    {
        return $"{Name} [Priority: {Priority}, Time: {EstimatedMinutes}min]";
    }
}

// Separate queues for different priorities
Queue<Task> highPriorityQueue = new Queue<Task>();
Queue<Task> normalPriorityQueue = new Queue<Task>();
Queue<Task> lowPriorityQueue = new Queue<Task>();

// Track completed tasks
List<Task> completedTasks = new List<Task>();

Console.WriteLine("=== TASK MANAGEMENT SYSTEM ===\n");

// Add tasks to appropriate queues
void AddTask(Task task)
{
    switch (task.Priority.ToLower())
    {
        case "high":
            highPriorityQueue.Enqueue(task);
            Console.WriteLine($"✓ Added to HIGH priority: {task.Name}");
            break;
        case "normal":
            normalPriorityQueue.Enqueue(task);
            Console.WriteLine($"✓ Added to NORMAL priority: {task.Name}");
            break;
        case "low":
            lowPriorityQueue.Enqueue(task);
            Console.WriteLine($"✓ Added to LOW priority: {task.Name}");
            break;
    }
}

// Adding tasks
AddTask(new Task("Fix critical bug", "high", 30));
AddTask(new Task("Update documentation", "low", 15));
AddTask(new Task("Code review PR #123", "normal", 20));
AddTask(new Task("Security patch", "high", 45));
AddTask(new Task("Refactor old code", "low", 60));
AddTask(new Task("Write unit tests", "normal", 25));
AddTask(new Task("Database backup", "high", 10));

Console.WriteLine("\n=== QUEUE STATUS ===");
Console.WriteLine($"High Priority: {highPriorityQueue.Count} tasks");
Console.WriteLine($"Normal Priority: {normalPriorityQueue.Count} tasks");
Console.WriteLine($"Low Priority: {lowPriorityQueue.Count} tasks");

Console.WriteLine("\n=== PROCESSING TASKS ===\n");

// Process tasks (high priority first, then normal, then low)
int totalMinutes = 0;

// Helper function to process a queue
void ProcessQueue(Queue<Task> queue, string priorityName)
{
    while (queue.Count > 0)
    {
        Task currentTask = queue.Dequeue();
        Console.WriteLine($"[{priorityName}] Processing: {currentTask.Name}");
        Console.WriteLine($"           Estimated time: {currentTask.EstimatedMinutes} minutes");
        
        totalMinutes += currentTask.EstimatedMinutes;
        completedTasks.Add(currentTask);
        
        Console.WriteLine($"           ✓ Completed!");
        Console.WriteLine($"           Remaining in {priorityName}: {queue.Count}");
        Console.WriteLine();
    }
}

// Process all queues in priority order
ProcessQueue(highPriorityQueue, "HIGH");
ProcessQueue(normalPriorityQueue, "NORMAL");
ProcessQueue(lowPriorityQueue, "LOW");

// Show summary
Console.WriteLine("=== COMPLETION SUMMARY ===");
Console.WriteLine($"Total tasks completed: {completedTasks.Count}");
Console.WriteLine($"Total time spent: {totalMinutes} minutes ({totalMinutes / 60.0:F1} hours)");

Console.WriteLine("\nCompleted tasks in order:");
for (int i = 0; i < completedTasks.Count; i++)
{
    Console.WriteLine($"{i + 1}. {completedTasks[i]}");
}
```

**Advanced Queue Concepts Demonstrated:**
1. **Multiple queues**: Different queues for different priorities
2. **Priority-based processing**: Process high priority before normal before low
3. **Queue delegation**: Helper functions to process entire queues
4. **Statistics tracking**: Monitor total time, completion rates
5. **Complex objects**: Queues holding custom Task objects

**Real-World Applications:**

**1. Operating Systems:**
- Process scheduling (CPU gives time to processes in queue)
- Print spooling (documents wait in queue)

**2. Web Servers:**
- Request handling (requests processed in order received)
- Message queues (RabbitMQ, Amazon SQS)

**3. Games:**
- Matchmaking (players wait in queue for a game)
- Animation systems (play animations in sequence)

**4. Call Centers:**
- Caller waiting line
- Ticket systems

**Why FIFO matters:**
- **Fairness**: Everyone gets served in order
- **Predictability**: You know when you'll be served
- **No starvation**: Even low priority eventually gets processed
- **Simple logic**: Easy to understand and implement

**Queue vs Stack comparison:**
```
Stack (LIFO):     Queue (FIFO):
Last In           First In
  ↓                 ↓
[3] ← Pop         [1] → Dequeue
[2]               [2]
[1]               [3]
  ↑                 ↑
Push            Enqueue
```

---

## Concurrent Collections

### 10. Thread-Safe Collections 🔒

**What are they?**
Imagine multiple people trying to add items to the same box at the same time. They might bump into each other! Concurrent collections make sure this doesn't cause problems - they're safe for multiple people (or threads) to use at once.

**When to use them:**
- In applications that do multiple things at the same time
- When different parts of your program share the same data

**ConcurrentDictionary Example:**

```csharp
using System.Collections.Concurrent;

ConcurrentDictionary<string, int> onlineUsers = new ConcurrentDictionary<string, int>();

// Multiple threads can safely add users
onlineUsers.TryAdd("Alice", 1);
onlineUsers.TryAdd("Bob", 2);

// Update value safely
onlineUsers.AddOrUpdate("Alice", 1, (key, oldValue) => oldValue + 1);
```

**ConcurrentQueue Example:**

```csharp
ConcurrentQueue<string> tasks = new ConcurrentQueue<string>();

// Multiple threads can add tasks
tasks.Enqueue("Task 1");
tasks.Enqueue("Task 2");

// Multiple threads can process tasks
if (tasks.TryDequeue(out string task))
{
    Console.WriteLine($"Processing: {task}");
}
```

---

## Practice Problems

### Beginner Level 🌱

**Problem 1: Favorite Movies List**
Create a program that manages your favorite movies.

**Requirements:**
- Create a `List<string>` to store your top 5 favorite movies
- Add all 5 movies to the list
- Print them with numbers (1. Movie Name, 2. Movie Name, etc.)
- Remove your least favorite movie
- Add a new movie at position 2 (index 1)
- Print the updated list

**Expected Output Example:**
```
Original List:
1. The Matrix
2. Inception
3. Interstellar
4. The Dark Knight
5. Pulp Fiction

After removing least favorite and adding new movie:
1. The Matrix
2. Avatar
3. Inception
4. Interstellar
5. The Dark Knight
```

**Skills Practiced:** List creation, Add(), Insert(), Remove(), iteration

---

**Problem 2: Grade Calculator**
Build a grade analysis system.

**Requirements:**
- Create a `List<int>` for student grades
- Add 10 grades (you can use random numbers between 60-100, or hardcode them)
- Calculate and print the average grade
- Count how many grades are above 80
- Find and print the highest and lowest grades
- Print all grades that are below the average

**Expected Output Example:**
```
Grades: 85, 92, 78, 95, 88, 72, 90, 84, 77, 91

Average: 85.2
Grades above 80: 7
Highest: 95
Lowest: 72

Grades below average:
- 78
- 72
- 84
- 77
```

**Skills Practiced:** List operations, loops, conditionals, calculations

---

**Problem 3: Word Counter**
Count how often each word appears in a sentence.

**Requirements:**
- Create a `Dictionary<string, int>` to store word counts
- Take a sentence from the user (or use a hardcoded sentence)
- Split the sentence into words
- Count how many times each word appears
- Print the results showing word → count

**Example Input:**
```
"the quick brown fox jumps over the lazy dog the fox"
```

**Expected Output:**
```
Word Frequencies:
the: 3
quick: 1
brown: 1
fox: 2
jumps: 1
over: 1
lazy: 1
dog: 1
```

**Bonus:** Find and print the most common word

**Skills Practiced:** Dictionary operations, string manipulation, ContainsKey(), iteration

---

**Problem 4: Remove Duplicates**
Clean up a list by removing duplicate values.

**Requirements:**
- Create a `List<int>` with these numbers: {1, 2, 2, 3, 4, 4, 5, 3, 6, 7, 7, 8}
- Use a `HashSet<int>` to remove duplicates
- Print the original list
- Print the unique numbers
- Print how many duplicates were removed

**Expected Output:**
```
Original list (12 numbers):
1, 2, 2, 3, 4, 4, 5, 3, 6, 7, 7, 8

Unique numbers (8 numbers):
1, 2, 3, 4, 5, 6, 7, 8

Removed 4 duplicates
```

**Skills Practiced:** HashSet usage, List to HashSet conversion, uniqueness

---

**Problem 5: Simple Calculator History**
Track calculator operations with undo functionality.

**Requirements:**
- Use a `Stack<string>` to track calculator operations
- Perform 5 calculations (e.g., "5 + 3 = 8", "8 * 2 = 16", etc.)
- Push each operation onto the stack as a string
- Display all operations in history
- Implement undo: pop the last 2 operations and show them
- Show remaining history

**Expected Output:**
```
Calculation History:
1. 5 + 3 = 8
2. 8 * 2 = 16
3. 16 - 4 = 12
4. 12 / 2 = 6
5. 6 + 10 = 16

Undoing last operation: 6 + 10 = 16
Undoing last operation: 12 / 2 = 6

Remaining History:
1. 5 + 3 = 8
2. 8 * 2 = 16
3. 16 - 4 = 12
```

**Skills Practiced:** Stack operations (Push, Pop), LIFO concept

---

### Intermediate Level 🌿

**Problem 6: Student Management System**
Build a comprehensive student database.

**Requirements:**
Create three data structures:
- `Dictionary<int, string>` for studentID → Name
- `Dictionary<int, List<int>>` for studentID → List of grades
- `Dictionary<int, string>` for studentID → Email

Implement these features:
1. Add 5 students with their information
2. Add 3-5 grades for each student
3. Calculate average grade for each student
4. Find the student with the highest average
5. Find all students with average above 85
6. Print a complete report card for all students

**Expected Output Example:**
```
=== STUDENT MANAGEMENT SYSTEM ===

Student ID: 101
Name: Alice Johnson
Email: alice@school.com
Grades: 85, 92, 88, 90
Average: 88.75
---
Student ID: 102
Name: Bob Smith
Email: bob@school.com
Grades: 78, 82, 75, 80
Average: 78.75
---
[... more students ...]

Top Student: Alice Johnson (Average: 88.75)

Honor Roll (Average > 85):
- Alice Johnson: 88.75
- Charlie Brown: 92.50
```

**Skills Practiced:** Multiple dictionaries, Dictionary of Lists, complex queries, calculations

---

**Problem 7: Music Playlist Manager**
Create a navigable music playlist.

**Requirements:**
- Use `LinkedList<string>` to create a music playlist
- Add at least 7 songs
- Implement these features:
  1. Display the playlist
  2. Add a song at the beginning
  3. Add a song at the end
  4. Navigate forward and backward through songs
  5. Remove current song
  6. Insert a song after the current song
  7. Find and display a specific song

**Expected Output Example:**
```
Initial Playlist:
♪ Song A
♪ Song B
♪ Song C
♪ Song D

Now playing: Song A
Press 'n' for next, 'p' for previous, 'r' to remove

After user interactions...
Updated Playlist:
♪ New Song
♪ Song B
♪ Song C
♪ Song E (inserted)
♪ Song D
```

**Skills Practiced:** LinkedList navigation, AddAfter, AddBefore, Find, Remove

---

**Problem 8: Task Scheduler with Undo**
Build a task manager with undo/redo capability.

**Requirements:**
- Use `Queue<string>` for pending tasks
- Use `Stack<string>` for completed tasks
- Use another `Stack<string>` for redo functionality

Implement:
1. Add 10 tasks to pending queue
2. Process tasks (move from queue to completed stack)
3. Undo last 3 completed tasks (move back to pending)
4. Redo 2 tasks
5. Show status of all three collections at each step

**Expected Output Example:**
```
Pending Tasks (10): Task1, Task2, ... Task10
Completed Tasks (0): 
Redo Stack (0): 

Processing...
Pending Tasks (7): Task4, Task5, ... Task10
Completed Tasks (3): Task3, Task2, Task1

Undoing 3 tasks...
Pending Tasks (10): Task3, Task2, Task1, Task4, ... Task10
Completed Tasks (0): 
Redo Stack (3): Task1, Task2, Task3

Redoing 2 tasks...
Pending Tasks (8): Task4, Task5, ... Task10
Completed Tasks (2): Task2, Task1
Redo Stack (1): Task3
```

**Skills Practiced:** Queue + Stack combination, undo/redo pattern, state management

---

**Problem 9: Unique Visitor Analytics**
Track website visitors and analyze patterns.

**Requirements:**
- Use `HashSet<string>` to track unique visitors
- Use `List<string>` to track all visits (including repeats)
- Simulate 50 visits using 20 different usernames (some will repeat)

Calculate and display:
1. Total visits
2. Unique visitors
3. Percentage of unique visitors
4. Most frequent visitor (hint: use a Dictionary to count)
5. List of visitors who came only once
6. List of visitors who came more than 3 times

**Expected Output Example:**
```
=== VISITOR ANALYTICS ===

Total Visits: 50
Unique Visitors: 20
Unique Rate: 40.0%

Most Frequent Visitor: user123 (8 visits)

One-time Visitors (5):
- user456
- user789
- user111
- user222
- user333

Frequent Visitors (3+ visits):
- user123: 8 visits
- user444: 5 visits
- user555: 4 visits
```

**Skills Practiced:** HashSet uniqueness, List vs HashSet, Dictionary counting, analysis

---

**Problem 10: Balanced Expression Checker**
Check if brackets/parentheses are properly balanced.

**Requirements:**
- Use `Stack<char>` to check balanced parentheses, brackets, and braces
- Test these expressions:
  - "((2 + 3) * 4)" → Balanced
  - "((2 + 3)" → Not Balanced
  - "{[()()]}" → Balanced
  - "{[(])}" → Not Balanced (wrong order)
  - "()[]{}()" → Balanced

For each test:
1. Show if balanced or not
2. Show which bracket caused the problem (if any)
3. Show the step-by-step process of pushing/popping

**Expected Output Example:**
```
Testing: ((2 + 3) * 4)
  Push: (
  Push: (
  Match: ( with )
  Match: ( with )
✓ BALANCED

Testing: ((2 + 3)
  Push: (
  Push: (
  Match: ( with )
✗ NOT BALANCED - 1 unclosed bracket

Testing: {[(])}
  Push: {
  Push: [
  Push: (
  Error: Expected ) but found ]
✗ NOT BALANCED - Mismatched brackets
```

**Skills Practiced:** Stack algorithm, matching pairs, error detection

---

### Advanced Level 🌳

**Problem 11: Complete Library Management System**
Build a full-featured library system.

**Requirements:**
Create these data structures:
- `Dictionary<string, Book>` where Book is a class with (ISBN, Title, Author, Pages)
- `Dictionary<string, List<string>>` for Author → List of ISBNs
- `Dictionary<string, bool>` for ISBN → IsAvailable
- `Queue<string>` for reservation waitlist per book
- `HashSet<string>` for borrowed book ISBNs
- `Dictionary<string, DateTime>` for ISBN → Due date

Implement:
1. Add 20 books (at least 3 books per author for some authors)
2. Search books by author
3. Borrow a book (mark unavailable, add to borrowed set, set due date)
4. Return a book (mark available, remove from borrowed)
5. Reserve a book (add to waitlist if unavailable)
6. Show all overdue books (compare due date to today)
7. Show available books
8. Show most popular author (most books borrowed)

**Sample Implementation Structure:**
```csharp
class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
}
```

**Expected Features:**
```
=== LIBRARY SYSTEM ===

1. Add Book
2. Search by Author
3. Borrow Book
4. Return Book
5. Reserve Book
6. Show Overdue Books
7. Show Available Books
8. Library Statistics
```

**Skills Practiced:** Multiple data structure coordination, class objects, date handling, complex queries

---

**Problem 12: Social Network Friends System**
Create a social network friend management system.

**Requirements:**
- Use `Dictionary<string, HashSet<string>>` where key is person name and value is their friends
- Implement bidirectional friendships (if A is friends with B, then B is friends with A)

Features to implement:
1. Add person
2. Add friendship (must be bidirectional!)
3. Remove friendship (must remove from both sides)
4. Find mutual friends between two people
5. Suggest friends (friends of friends who aren't already friends)
6. Find person with most friends
7. Find shortest friendship path between two people (breadth-first search)
8. Find "friend circles" (groups of connected people)

**Expected Output Example:**
```
=== SOCIAL NETWORK ===

Adding friendship: Alice ↔ Bob
Adding friendship: Bob ↔ Charlie
Adding friendship: Alice ↔ Charlie
Adding friendship: Charlie ↔ David
Adding friendship: David ↔ Eve

Alice's friends: Bob, Charlie
Bob's friends: Alice, Charlie
Charlie's friends: Alice, Bob, David

Mutual friends of Alice and Charlie: Bob

Friend suggestions for Alice:
- David (friend of Charlie)

Person with most friends: Charlie (3 friends)

Friendship path from Alice to Eve:
Alice → Charlie → David → Eve
```

**Skills Practiced:** Graph algorithms, bidirectional relationships, BFS, set operations

---

**Problem 13: Browser History with Multiple Tabs**
Simulate a web browser with multiple tabs and history.

**Requirements:**
- Each tab has its own `Stack<string>` for back history
- Each tab has its own `Stack<string>` for forward history
- Use `List<int>` to track which tab is active
- Store all tab information in `Dictionary<int, TabInfo>`

Features:
1. Open new tab
2. Close tab
3. Navigate to URL (add to back stack, clear forward stack)
4. Go back (move from back to forward stack)
5. Go forward (move from forward to back stack)
6. Switch between tabs
7. Show all tabs and their current pages
8. Show history for current tab

**Sample TabInfo class:**
```csharp
class TabInfo
{
    public Stack<string> BackHistory { get; set; }
    public Stack<string> ForwardHistory { get; set; }
    public string CurrentPage { get; set; }
}
```

**Expected Interaction:**
```
Tab 1 - Current: google.com
  Back: (empty)
  Forward: (empty)

Navigate to: youtube.com
Tab 1 - Current: youtube.com
  Back: google.com
  Forward: (empty)

Navigate to: github.com
Tab 1 - Current: github.com
  Back: youtube.com, google.com
  Forward: (empty)

Go back
Tab 1 - Current: youtube.com
  Back: google.com
  Forward: github.com

Open new tab
Tab 2 - Current: about:blank

Switch to Tab 1
Tab 1 - Current: youtube.com
```

**Skills Practiced:** Multiple stacks, tab management, navigation logic

---

**Problem 14: E-Commerce Shopping Cart System**
Build a complete shopping cart with inventory management.

**Requirements:**
Data structures needed:
- `Dictionary<string, Product>` for productID → Product
- `Dictionary<string, int>` for productID → Stock quantity
- `Dictionary<string, int>` for cart (productID → Quantity)
- `Dictionary<string, decimal>` for product prices
- `List<string>` for discount codes
- `Stack<CartAction>` for undo functionality

Create a Product class with (ID, Name, Price, Category)
Create a CartAction class to store cart state for undo

Features to implement:
1. Add 30+ products across different categories
2. Add item to cart (check stock availability)
3. Remove item from cart
4. Update item quantity in cart
5. Apply discount code (10% off, 20% off, etc.)
6. Calculate total with tax (7% tax)
7. Checkout (decrease stock, clear cart, save to order history)
8. Undo last cart action
9. Search products by category
10. Show low stock items (stock < 5)
11. Show cart summary with subtotal, tax, discount, total

**Expected Output:**
```
=== SHOPPING CART ===

Available Products (showing Electronics):
1. Laptop - $999.99 (Stock: 15)
2. Mouse - $29.99 (Stock: 50)
3. Keyboard - $79.99 (Stock: 30)

Your Cart:
- Laptop x1: $999.99
- Mouse x2: $59.98

Subtotal: $1,059.97
Discount (SAVE10): -$106.00
Tax (7%): $66.78
Total: $1,020.75

Apply discount code SAVE20? (Y/N)

Checkout successful!
Stock updated:
- Laptop: 15 → 14
- Mouse: 50 → 48
```

**Skills Practiced:** Complex object management, financial calculations, inventory tracking, undo system

---

**Problem 15: Advanced Text Editor with Full Undo/Redo**
Create a text editor with complete undo/redo functionality.

**Requirements:**
Data structures:
- `StringBuilder` or `string` for current text content
- `Stack<EditorState>` for undo history
- `Stack<EditorState>` for redo history
- `List<string>` for clipboard (copy/paste)
- `Dictionary<string, int>` for word frequency analysis

Create an EditorState class that stores complete editor state

Features to implement:
1. Type text (save state to undo before typing)
2. Delete text
3. Copy text to clipboard
4. Paste from clipboard
5. Undo (move state from undo to redo)
6. Redo (move state from redo to undo)
7. Find and replace
8. Word count and frequency analysis
9. Save history (show all states)
10. Limit undo history to 50 states (use Queue for this)

**Expected Interaction:**
```
=== TEXT EDITOR ===

Current text: (empty)
Undo stack: 0 | Redo stack: 0

Type: Hello
Current text: Hello
Undo stack: 1 | Redo stack: 0

Type:  World
Current text: Hello World
Undo stack: 2 | Redo stack: 0

Undo
Current text: Hello
Undo stack: 1 | Redo stack: 1

Redo
Current text: Hello World
Undo stack: 2 | Redo stack: 0

Find and Replace: World → Universe
Current text: Hello Universe
Undo stack: 3 | Redo stack: 0

Word Frequency:
- Hello: 1
- Universe: 1

Total words: 2
```

**Skills Practiced:** State management, dual stack pattern, text manipulation, clipboard simulation

---

## Practice Problem Tips 💡

**For Beginners:**
- Start with Problem 1 and work your way up
- Don't skip problems - each teaches important concepts
- Write the code yourself, don't copy-paste
- Test with different inputs
- Break down big problems into smaller steps

**For Intermediate:**
- Try to solve without looking at hints
- Think about edge cases (empty lists, null values, etc.)
- Consider performance (is your solution efficient?)
- Can you make the code more readable?
- Add error handling

**For Advanced:**
- Design the system before coding
- Think about scalability
- Consider real-world constraints
- Write reusable functions/classes
- Add comprehensive testing
- Think about what could go wrong

**General Tips:**
1. **Read the problem twice** before coding
2. **Plan your data structures** - which one fits best?
3. **Start simple**, then add features
4. **Test frequently** - don't write everything then test
5. **Use meaningful variable names**
6. **Add comments** to explain complex logic
7. **Don't be afraid to start over** if design is wrong

Happy coding! 🚀

---

## Quick Reference Chart 📊

| Data Structure | Use When You Need | Speed (Access) | Speed (Add/Remove) |
|----------------|-------------------|----------------|-------------------|
| List&lt;T&gt; | Ordered items, fast access by index | Very Fast | Fast at end, Slow in middle |
| LinkedList&lt;T&gt; | Frequent add/remove in middle | Slow | Very Fast |
| Dictionary&lt;TKey,TValue&gt; | Fast lookup by unique key | Very Fast | Very Fast |
| HashSet&lt;T&gt; | Unique items only | Very Fast | Very Fast |
| Stack&lt;T&gt; | Last-in-first-out (LIFO) | Fast (top only) | Very Fast |
| Queue&lt;T&gt; | First-in-first-out (FIFO) | Fast (front only) | Very Fast |

---

## Tips for Choosing the Right Data Structure 💡

1. **Need items in order?** → Use `List<T>`
2. **Need fast lookup by a key?** → Use `Dictionary<TKey, TValue>`
3. **Need only unique items?** → Use `HashSet<T>`
4. **Need to undo actions?** → Use `Stack<T>`
5. **Need to process in order?** → Use `Queue<T>`
6. **Need to add/remove from middle often?** → Use `LinkedList<T>`
7. **Working with multiple threads?** → Use Concurrent collections

---

## Final Words 🎓

Congratulations! You've learned about the most important data structures in C#. Remember:

- **Practice makes perfect** - Try all the examples and problems
- **Start simple** - Master the basics before moving to complex problems
- **Think about real life** - Data structures are all around you!
- **Experiment** - Try mixing different data structures together

Happy coding! 🚀
