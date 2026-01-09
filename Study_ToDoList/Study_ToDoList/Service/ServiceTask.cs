using Microsoft.Win32.SafeHandles;
using Study_ToDoList.Domain;
using Study_ToDoList.Repositories;

namespace Study_ToDoList.Service
{
    internal class ServiceTask
    {

        public TaskManager CreateUsersTask()
        {

            User user = new User();
            TaskManager taskManager = new TaskManager();
            
            int amount = 2;
            string reason = "test block";
            user.CheckMaxTasks(amount);
            taskManager.Start();
            taskManager.Block(reason);
            taskManager.Complete();

            return taskManager;
        }
    }
}
