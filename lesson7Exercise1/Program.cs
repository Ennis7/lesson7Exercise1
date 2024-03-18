using System;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace lesson7Exercise1;
internal class Program
{
    static void Main(string[] args)
    {
        //a.)
        Console.WriteLine("A.)");
        //Creates Food queue
        Queue<string> food = new Queue<string>();

        //adding foods
        food.Enqueue("pizza");
        food.Enqueue("burger");
        food.Enqueue("sandwich");
        food.Enqueue("ice cream");
        food.Enqueue("brownie");
        Console.WriteLine($"There are {food.Count()} items");
        Console.ReadLine();

        //display item in queue
        Console.WriteLine("Enter the name of the food you would like to search for");
        string foodName = Console.ReadLine();
        if (food.Contains(foodName))
        {
            Console.WriteLine("That item is on the list.");
        }
        else
        {
            Console.WriteLine("That item is not in the list.");
        }
        Console.ReadLine();

        //remove item
        string firstfo = food.Peek();
        Console.WriteLine($"Remove {firstfo} from the beginning of the queue by typing yes.");
        string answer = Console.ReadLine();
        while (answer == "yes")
        {
            food.Dequeue(); // removes item from the top of the queue
            firstfo = food.Peek();
            answer = Console.ReadLine();
            Console.WriteLine($"There are now {food.Count()} items");
            Console.ReadLine();
            foreach (var f in food)
            {
                Console.WriteLine(f);
            }
            Console.ReadLine();


        //b.)
        Console.WriteLine("B.)");
        PriorityQueue<string, int> toDoList = new PriorityQueue<string, int>();
        toDoList.Enqueue("Groceries", 1);
        toDoList.Enqueue("Laundry", 3);
        toDoList.Enqueue("MealPrep", 2);
        toDoList.Enqueue("Vacuum", 4);
        toDoList.Enqueue("Mop", 5);


        Console.WriteLine($"There are {toDoList.Count} items in the queue");


        while (toDoList.TryDequeue(out string item, out int priority))
        {
            Console.WriteLine($"Dequeued Item : {item} Priority Was: {priority}");
            Console.ReadLine();
        }
        Console.WriteLine($"There are {toDoList.Count} items in the queue");
        Console.ReadLine();


        }

        //c.)
        Console.WriteLine("C.)");
        // Creates the members Stack
        Stack<string> foodie = new Stack<string>();
        //adding members
        foodie.Push("pizza");
        foodie.Push("hotdog");
        foodie.Push("ice cream");
        foodie.Push("cookie");
        foodie.Push("pineapple");

        Console.WriteLine("Enter the food item you would like to search for");
        string fooditem = Console.ReadLine();
        if (foodie.Contains(fooditem))
        {
            Console.WriteLine("That is in the Stack.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("I am sorry, that is not on the list");
            Console.ReadLine();
        }
        Console.WriteLine($"There are {foodie.Count} items in the Stack");
        Console.WriteLine("Pineapple is being removed from the Stack");
        Console.ReadLine();
        foodie.Pop();
        Console.WriteLine($"There are {foodie.Count} items in the Stack now");
        Console.ReadLine();

        foreach (var f in foodie)
        {
            Console.WriteLine(f);
        }
        Console.ReadLine();

        //d.)
        Console.WriteLine("D.)");
        // Create the link list.
        string[] foods =
            { "Pizza", "Hotdog", "Sandwich", "Ice Cream", "Brownie" };

        LinkedList<string> foodList = new LinkedList<string>(foods);
        Console.WriteLine("Original food list");
        foreach (string Food in foodList)
        {
            Console.WriteLine(Food);
        }
        Console.WriteLine();

        //Retrieving and displaying the First and Last
        Console.WriteLine($"The first item on the list is {foodList.First.Value}.");
        Console.WriteLine($"The last item on the list is {foodList.Last.Value}.");



        //Adding 6th 
        LinkedListNode<string> targetLocation = foodList.Find("Ice Cream");
        Console.WriteLine();

        foodList.AddBefore(targetLocation, "Key lime Pie");

        //Remove first
        foodList.RemoveFirst();
        Console.WriteLine("Pizza has been removed and key lime pie has been added.");
        Console.WriteLine();

        //Count
        Console.WriteLine($"There are {foodList.Count} items on the list.");
        Console.WriteLine();

        //Display all
        foreach (string Food in foodList)
        {
            Console.WriteLine(Food);
        }
        Console.ReadLine();

        //e.)
        Console.WriteLine("E.)");
        Dictionary<string, string> PetsList = new Dictionary<string, string>();
        Dictionary<string, Int16> TypeList = new Dictionary<string, Int16>();
        Dictionary<string, float> AgeList = new Dictionary<string, float>(5);

        //Adding Pets
        PetsList.Add("Luna", "Siamese");
        PetsList.Add("Gizmo", "Shi Tzu");
        PetsList.Add("Mozart", "German Shepard");
        PetsList.Add("Lola", "Blue Heeler");
        PetsList.Add("Tyrus", "Boxer");

        //display keys
        Console.WriteLine("PetsList Keys");
        Dictionary<string, string>.KeyCollection keys = PetsList.Keys;
        foreach (string k in keys)
        {
            Console.WriteLine("Key: {0}", k);
        }
        Console.WriteLine();

        //display values
        Console.WriteLine("PetsList Values");
        Dictionary<string, string>.ValueCollection values = PetsList.Values;
        foreach (string v in values)
        {
            Console.WriteLine("Value: {0}", v);
        }
        Console.WriteLine();
    
        //Keys & Values
        Console.WriteLine("PetsList Key/Value Pairs");
        foreach (KeyValuePair<string, string> kvp in PetsList)
        {
            Console.WriteLine($"Key: {kvp.Key}  Value: {kvp.Value}");
        }
        Console.WriteLine();

        //Remove
        PetsList.Remove("Lola");
        Console.WriteLine("Lola has been removed from the list");
        Console.WriteLine();

        //Count
        Console.WriteLine($"There are {PetsList.Count} pets in the list now");
        Console.ReadLine();


        //f.)
        Console.WriteLine("f) Use the SortedList<TKey,TValue> collection");
        Console.WriteLine();
        SortedList<string, string> PetsLists = new SortedList<string, string>();
        //add the elements in sortedlist
        PetsLists.Add("Siamese", "Luna");
        PetsLists.Add("Shi Tzu", "Gizmo");
        PetsLists.Add("German Shepard", "Mozart");
        PetsLists.Add("Blue Heeler", "Lola");
        PetsLists.Add("Boxer", "Tyrus");

        //add value and key
        Console.WriteLine("What is the name of your pet?");
        string name = Console.ReadLine();
        Console.WriteLine("What is the breed of your pet?");
        string breed = Console.ReadLine();

        //check for value in list & remove if duplicate
        if (PetsLists.ContainsValue(name))
            Console.WriteLine($"{name} There is a pet with that breed already.");
        else
        {
            // check for country key in list (can't have dups)
            if (PetsLists.ContainsKey(breed))
            {
                Console.WriteLine($"There can only be one {breed} on the list.");
                PetsLists.Remove(breed);
                PetsLists.Add(breed, name);
                Console.WriteLine($"The current {breed} has been removed and {name} has been added");
            }
            else
            {
                PetsLists.Add(breed, name);
                Console.WriteLine($"{name}, {breed} was added to your list");
            }

            Console.WriteLine();
            Console.WriteLine("The pets on the list are:");
            foreach (KeyValuePair<string, string> pl in PetsLists)
            {
                Console.WriteLine($"Key = {pl.Key}  Value={pl.Value}");
            }
            Console.ReadLine();

        //g.)
        Console.WriteLine("g) Use the HashSet<T> collection");
        Console.WriteLine();

        HashSet<string> Subjects = new HashSet<string>();
        Subjects.Add("math");
        Subjects.Add("english");
        Subjects.Add("history");
        Subjects.Add("science");
        Subjects.Add("art");

        HashSet<string> languageSubjects = new HashSet<string>();
        languageSubjects.Add("French");
        languageSubjects.Add("Spanish");
        languageSubjects.Add("German");
        languageSubjects.Add("Chinese");
        languageSubjects.Add("Sign Language");

        HashSet<string> semesterSubjects = new HashSet<string>();
        semesterSubjects.Add("math");
        semesterSubjects.Add("Sign Language");
        semesterSubjects.Add("Gym");
        semesterSubjects.Add("Resouce");
        semesterSubjects.Add("Music");

        Console.WriteLine("Combined list of Subjects and language Subject");
        Console.WriteLine();
        Subjects.UnionWith(languageSubjects);
        foreach (string subject in Subjects)
        {
            Console.WriteLine(subject);
        }

        Console.WriteLine();
        Console.WriteLine("Subjects that are in both lists");
        HashSet<string> bothLists = new HashSet<string>();
        bothLists = Subjects;
        bothLists.IntersectWith(semesterSubjects);
        foreach (string subject in bothLists)
        {
            Console.WriteLine(subject);
        }

        Console.ReadLine();
        Console.WriteLine();


        //h.)
        Console.WriteLine(" h) Use the List<T> collection");
        Console.WriteLine();

        List<string> characters = new List<string> { "Harry", "Hermione", "Ron", "Lord Voldemort", "Albus"};

        Console.WriteLine($"The original list has {characters.Count()} members");
        Console.WriteLine();
        string[] characterArr = new string[] { "Dobby", "Draco", "Hagrid" };
        characters.AddRange(characterArr);
        Console.WriteLine($"The new list now has {characters.Count()} members");

        characters.Sort();
        Console.WriteLine("-------Sorted List--------");
        foreach (string c in characters)
            Console.WriteLine(c);
        Console.WriteLine();

        characters.Remove(characters[6]);
        Console.WriteLine("Charater #7 was removed from the list.");
        Console.WriteLine();

        characters.Reverse();
        Console.WriteLine("-------Reverse Sorted List--------");
        foreach (string c in characters)
            Console.WriteLine(c);
        Console.ReadLine();
    }
}
}