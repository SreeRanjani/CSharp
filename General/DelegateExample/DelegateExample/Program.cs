using DelegateExample;

Person[] people = new Person[] {
   new() { Name = "Charlie", Age = 30 },
   new() { Name = "Bob", Age = 25 },
   new() { Name = "Alice", Age = 35 }
};

// Sort by name alphabetically
Utilities.Sort(people, (p1, p2) => string.Compare(p1.Name, p2.Name));

// Print the sorted array
foreach (Person person in people)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}

// Sort by age in descending order
Utilities.Sort(people, (p1, p2) => p2.Age - p1.Age);

// Print the sorted array
foreach (Person person in people)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}