using Study_ToDoList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Study_ToDoList.Repositories
{
    internal class JsonTaskRepository : ITaskRepository
    {
        private List<TaskManager> Tasks { get; set; }

        private string jsonPath = @"Study_ToDoList\Study_ToDoList\Data\";
        private string jsonPathFile = @"task.json";

        public JsonTaskRepository()
        {
            Tasks = new List<TaskManager>();

            if (!Directory.Exists(jsonPath))
            {
                Directory.CreateDirectory(jsonPath);
            }
        }

        public void CreateTask(TaskManager task)
        {
            Tasks.Add(task);
            string teste = JsonSerializer.Serialize(Tasks);
            File.WriteAllText(jsonPathFile, teste);
        }

        public List<TaskManager> ListTask()
        {
            if (File.Exists(jsonPathFile))
            {
                string readContent = File.ReadAllText(jsonPathFile);
                var readList = JsonSerializer.Deserialize<List<TaskManager>>(readContent);
                Tasks = readList;
            }
            else
            {
                throw new Exception("File doesn't exist");
            }

            return Tasks;
        }

        public TaskManager SearchTask(Guid id)
        {
            var searchTasks = File.ReadAllText(jsonPathFile);
            var readList = JsonSerializer.Deserialize<List<TaskManager>>(searchTasks);
            Tasks = readList;

            foreach (var item in Tasks)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            throw new InvalidOperationException("This id not found, try again");
        }

        public void UpdateTask(TaskManager task)
        {
            var readFile = File.ReadAllText(jsonPathFile);
            var readUpdateFile = JsonSerializer.Deserialize<List<TaskManager>>(readFile);

            Tasks = readUpdateFile;

            bool teste = false;

            foreach (var item in Tasks)
            {
                if (item.Id == task.Id)
                {
                    item.Status = TaskManager.TaskStatus.InProgress;
                    teste = true;
                }
            }

            if(teste == true)
            {
                string updateFile = JsonSerializer.Serialize(Tasks);
                File.WriteAllText(jsonPathFile, updateFile);

            }
            else
            {
                throw new InvalidOperationException("This id not found, try again");
            }
        }
    }
}

