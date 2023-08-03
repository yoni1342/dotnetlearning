
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Task Manager");
        TaskManager taskManager = new TaskManager();

        bool isRunning = true;
        taskManager.Load().Wait();
        while (isRunning)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Show All Tasks");
            Console.WriteLine("3. Show Tasks By Category");
            Console.WriteLine("4. Save Tasks");
            Console.WriteLine("5. Exit");
        

        int.TryParse(Console.ReadLine(), out int choice);

        switch(choice){
            case 1:
                Console.WriteLine("Enter Task Name");
                string taskName = Console.ReadLine();
                Console.WriteLine("Enter Task Description");
                string taskDescription = Console.ReadLine();
                Console.WriteLine("Enter Task Category");
                Console.WriteLine("Available task categories:");
                foreach (TaskCategory singleCategory in Enum.GetValues(typeof(TaskCategory)))
                {
                    Console.WriteLine($"- {singleCategory}");
                }
                Console.WriteLine("Enter task categories (separated by commas):");
                string userInput = Console.ReadLine();
                
                string[] categoryNames = userInput.Split(',');
                UserTasks task = new UserTasks
                {
                    TaskName = taskName,
                    TaskDescription = taskDescription,
                };
                task.AddCategory(categoryNames);
                
                taskManager.AddTask(task);
                break;
            
            case 2:
                taskManager.ShowAllTasks();
                break;
            
            case 3:
                Console.WriteLine("Available task categories:");
                foreach (TaskCategory singleCategory in Enum.GetValues(typeof(TaskCategory)))
                {
                    Console.WriteLine($"- {singleCategory}");
                }
                Console.WriteLine("Enter task categories (separated by commas):");
                string input = Console.ReadLine();
                string[] categorys = input.Split(',');

                taskManager.ShowTasksByCategory(categorys);
                break;
            case 4:
                taskManager.Save();
                Console.WriteLine("Tasks saved to CSV file successfully.");
                break;
            case 5:
                isRunning = false;
                Console.WriteLine("Thank you for using Task Manager");
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
        }
    }
}