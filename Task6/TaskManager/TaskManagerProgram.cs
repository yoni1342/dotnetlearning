using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
    
    public class TaskManager
    {
        public List<UserTasks> Tasks { get; set; } = new List<UserTasks>();

        public void AddTask(UserTasks task)
        {
            Tasks.Add(task);
        }

        //with lambda expression show all tasks
        public void ShowAllTasks()
        {
            Tasks.ForEach(task => Console.WriteLine($"Task Id: {task.TaskId}\nTask Name: {task.TaskName}\nTask Description: {task.TaskDescription}\nTask Category: {task.TaskCategory}\nTask Status: {task.IsCompleted}\n"));
        }

        // show all tasks in a category using bitwise operator
        public void ShowTasksByCategory(string[] categories)
        {
            TaskCategory category = TaskCategory.None;
            foreach (string categoryName in categories)
            {
                if (Enum.TryParse<TaskCategory>(categoryName, out TaskCategory cat))
                {
                    category |= cat;
                }
            }
            Tasks.ForEach(task =>
            {
                if ((task.TaskCategory & category) != 0)
                {
                    Console.WriteLine($"Task Id: {task.TaskId}\nTask Name: {task.TaskName}\nTask Description: {task.TaskDescription}\nTask Category: {task.TaskCategory}\nTask Status: {task.IsCompleted}\n");
                }
            });
        }

        // Delete a task by id
        public void DeleteTask(Guid id)
        {
            Tasks.RemoveAll(task => task.TaskId == id);
        }

        // Make the task as completed
        public void MarkAsCompleted(Guid id)
        {
            Tasks.Find(task => task.TaskId == id).IsCompleted = true;
        }


    public void Save()
    {
        using (var writer = new StreamWriter("tasks.csv"))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(Tasks);
        }
    }
    public async Task Load()
    {
        using StreamReader reader = new("tasks.csv");
        string line;
        
        try
        {
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] values = line.Split(',');
                UserTasks task = new UserTasks
                {
                    TaskId = Guid.Parse(values[0]),
                    TaskName = values[1],
                    TaskDescription = values[2],
                    IsCompleted = bool.Parse(values[4])
                };
                task.AddCategory(values[3].Split('|'));
                Tasks.Add(task);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
