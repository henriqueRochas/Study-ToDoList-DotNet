using Study_ToDoList.Domain;
using DomainTask = Study_ToDoList.Domain.Task;


namespace Study_ToDoList.Service
{
    internal class ServiceTask
    {

        public void CreateUsersTask()
        {
            User user = new User
            (
               Guid.NewGuid(),
               "Henrique",
               "henrique@email.com.br",
               3
            );

            DomainTask task = new DomainTask
            (
                Guid.NewGuid(),
                "Minha tarefa",
                "Descrição qualquer",
                DomainTask.TaskPriority.Medium
                
            );

            int amount = 2;
            string reason = "test block";
            user.CheckMaxTasks(amount);
            task.Start();
            task.Block(reason);
            task.Complete();
        }
    }
}
