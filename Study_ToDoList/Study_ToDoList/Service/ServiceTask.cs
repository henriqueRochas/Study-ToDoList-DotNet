using Study_ToDoList.Domain;
using DomainTask = Study_ToDoList.Domain.Task;


namespace Study_ToDoList.Service
{
    internal class ServiceTask
    {

        public void CreateUsersTask()
        {
            User user = new User();
            DomainTask task = new DomainTask();

            int amount = 2;

            user.Id = Guid.NewGuid();
            user.Name = "Henrique";
            user.Email = "henrique@email.com.br";
            user.CheckMaxTasks(amount);
            task.Start();
        }
    }
}
