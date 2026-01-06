using Study_ToDoList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Study_ToDoList.Repositories
{
    internal interface ITaskRepository
    {

        void CreateTask(TaskManager task);
        TaskManager SearchTask(Guid id);
        List<TaskManager> ListTask();
        void UpdateTask(TaskManager task);
    }
}
