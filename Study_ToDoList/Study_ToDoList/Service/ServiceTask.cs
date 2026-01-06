using Study_ToDoList.Domain;


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


            TaskManager taskManager = new TaskManager
            (
                Guid.NewGuid(),
                "Minha tarefa",
                "Descrição qualquer",
                TaskManager.TaskPriority.Medium
                
            );

            int amount = 2;
            string reason = "test block";
            user.CheckMaxTasks(amount);
            taskManager.Start();
            taskManager.Block(reason);
            taskManager.Complete();
        }
    }
}
