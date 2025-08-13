using System.Reflection.Metadata.Ecma335;

bool userExit = false;
List<string> todoList = new List<string>();

do
{
    Menu();
    Console.Write("Select: ");
    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "S":
        case "s":
            ListAllTodo(todoList);
            break;

        case "A":
        case "a":

            AddTodo();

            break;

        case "R":
        case "r":
            break;

        case "E":
        case "e":
            userExit = true;
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}
while (!userExit);

Console.ReadKey();

void Menu()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}

void ListAllTodo()
{
    if (todoList.Any())
    {
        for(int i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todoList[i]}");
        }
    }
    else
    {
        Console.WriteLine("No TODOs have been added yet");
    }
}

void AddTodo()
{
    bool isValidDescription = false;
    while(!isValidDescription)
    {
        Console.Write("Enter the TODO description: ");
        string todo = Console.ReadLine();

        if (todo == "")
        {
            Console.WriteLine("The description cannot be empty");

        }
        else if (todoList.Contains(todo))
        {
            Console.WriteLine("The description must be unique.");
        }
        else
        {
            isValidDescription = true;
            todoList.Add(todo);
        }
    }
}

void RemoveTodo()
{
    if(todoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return;
    }

    Console.WriteLine("Select the index of the TODO you want to remove");
    ListAllTodo();

    var userChoice = Console.ReadLine();
    if(userChoice == "")
    {
        Console.WriteLine("Selected index cannot be empty");
        continue;
    }
}