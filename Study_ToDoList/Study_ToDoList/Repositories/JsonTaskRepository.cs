using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Study_ToDoList.Repositories
{
    internal class JsonTaskRepository : ITaskRepository
    {
        private List<Task> Tasks { get; set; }

        private  string jsonPath = @"Study_ToDoList\Study_ToDoList\Data\";
        private string jsonPathFile = @"task.json";

        public JsonTaskRepository()
        {
            Tasks = new List<Task>();

            if (!Directory.Exists(jsonPath))
            {
                Directory.CreateDirectory(jsonPath);
            }
        }

        public void CreateTask(Task task)
        {
            Tasks.Add(task);
            string teste = JsonSerializer.Serialize(Tasks);
            File.WriteAllText(jsonPathFile, teste);
        }

        public List<Task> ListTask()
        {
            if (File.Exists(jsonPathFile))
            { 
                    string readContent = File.ReadAllText(jsonPathFile);
                    var readList = JsonSerializer.Deserialize<List<Task>>(readContent);
                    Tasks = readList;
            }
            else
            {
                throw new Exception("File doesn't exist");
            }

                return Tasks;
        }

        public Task SearchTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
