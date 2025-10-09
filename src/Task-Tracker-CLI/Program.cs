// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the CLI! Type 'task-cli' to see available commands.");

// Initialize the file with an empty array if it's empty
while (true)
{
    switch (Console.ReadLine().Trim())
    {
        case "task-cli":
            Console.WriteLine("Available commands: help, exit");
            break;
        case "task-cli add":
            
            break;
        case "task-cli update":
            break;
        case "task-cli delete":
            break;
        case "task-cli list":
            
            break;
        case "task-cli list done":
            break;
        case "task-cli list todo":
            break;
        case "task-cli list inprogress":
            break;
        default:
           Console.WriteLine("Unknown command. Type 'task-cli' to see available commands.");
            break;
    }
}