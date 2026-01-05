using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_ToDoList.Repositories
{
    internal interface ITaskRepository
    {

        void CreateTask(Task task);
       Task SearchTask(Guid id);
        List<Task> ListTask();
        void UpdateTask(Task task);
    }
}
