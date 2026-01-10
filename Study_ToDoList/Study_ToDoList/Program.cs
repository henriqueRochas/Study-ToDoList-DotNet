
using Study_ToDoList.Repositories;
using Study_ToDoList.Service;
using static Study_ToDoList.Program.TaskManager;

namespace Study_ToDoList
{
    internal class Program
    {
        public class TaskManager
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public StatusTask Status { get; set; }
            public List<string> HistoryTask { get; set; } = new List<string>();

            public TaskManager() { }

            public TaskManager(int id, string title, StatusTask status)
            {
                Id = id;
                Title = title;
                Status = status;
            }

            public enum StatusTask
            {
                Pending,
                Progress,
                Completed
            }
        }

        public class TaskService
        {
            private List<TaskManager> ListTasks { get; set; }

            public TaskService()
            {
                ListTasks = new List<TaskManager>();
            }

            public TaskService(List<TaskManager> listTasks)
            {
                ListTasks = listTasks;
            }
            public void CreatedTask()
            {
                ListTasks.AddRange(new List<TaskManager>
                {
                     new TaskManager() { Id = 1, Title = "Task 1", Status = StatusTask.Pending},
                     new TaskManager() { Id = 2, Title = "Task 2", Status = StatusTask.Pending},
                     new TaskManager() { Id = 3, Title = "Task 3", Status = StatusTask.Pending},
                     new TaskManager() { Id = 4, Title = "Task 4", Status = StatusTask.Completed},
                     new TaskManager() { Id = 5, Title = "Task 5", Status = StatusTask.Progress},
                     new TaskManager() { Id = 6, Title = "Task 6", Status = StatusTask.Pending},
                     new TaskManager() { Id = 7, Title = "Task 7", Status = StatusTask.Completed},
                     new TaskManager() { Id = 8, Title = "Task 8", Status = StatusTask.Completed},
                     new TaskManager() { Id = 9, Title = "Task 9", Status = StatusTask.Progress}
                });
            }
            public List<TaskManager> ListTask()
            {
                return ListTasks;
            }



            public TaskManager SearchTask(int id)
            {
                var search = ListTasks.FirstOrDefault(a => a.Id == id);

                if (search != null)
                {
                    return search;
                }
                else
                {
                    return null;
                }
            }

            public bool ChangeStatus(int id)
            {
                var resultSearch = SearchTask(id);

                if (resultSearch == null)
                {
                    return false;
                }
                else
                {
                    if (resultSearch.Status == StatusTask.Pending)
                    {
                        resultSearch.Status = StatusTask.Progress;
                        resultSearch.HistoryTask.Add("Task Progress");
                        return true;
                    }
                    else if (resultSearch.Status == StatusTask.Progress)
                    {
                        resultSearch.Status = StatusTask.Completed;
                        resultSearch.HistoryTask.Add("Task Completed");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public bool RemoveTasks(int id)
            {
                var resultSearch = SearchTask(id);

                if (resultSearch == null)
                {
                    return false;
                }
                else
                {
                    if (resultSearch.Status == StatusTask.Completed)
                    {
                        resultSearch.HistoryTask.Add("Task Progress");
                        ListTasks.Remove(resultSearch);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            public List<string> HistoryTask(int id)
            {
                var resultSearch = SearchTask(id);
                if (resultSearch != null)
                {
                    return resultSearch.HistoryTask;
                }
                else
                {
                    return new List<string>();
                }

            }

            public IEnumerable<TaskManager> FilterTask()
            {
                var filterStatusTask1 = ListTasks
                .Where(i => i.Status == StatusTask.Pending || i.Status == StatusTask.Completed || i.Status == StatusTask.Progress);

                return filterStatusTask1;

            }
        }

        static void Main(string[] args)
        {
            int _option;
            TaskService taskService = new TaskService();

            do
            {

                Console.WriteLine("Menu");
                Console.WriteLine();

                Console.WriteLine("1 - Create Task");
                Console.WriteLine("2 - List Task");
                Console.WriteLine("3 - Start Tasks");
                Console.WriteLine("4 - Complete Tasks ");
                Console.WriteLine("5 - Remove Tasks");
                Console.WriteLine("6 - History Tasks");
                Console.WriteLine("7 - Filter Tasks");

                while (!int.TryParse(Console.ReadLine(), out _option))
                {
                    Console.WriteLine("Opção invalida, tente novamente");
                }

                switch (_option)
                {
                    case 1:
                        Console.WriteLine("Create Tasl");
                        Console.WriteLine();

                        taskService.CreatedTask();

                        break;
                    case 2:
                        Console.WriteLine("List Task");
                        Console.WriteLine();

                        var list = taskService.ListTask();

                        foreach (var item in list)
                        {
                            Console.WriteLine($" Id{item.Id} Title {item.Title} Status {item.Status}");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Start Task");
                        Console.WriteLine();

                        int id = int.Parse(Console.ReadLine());

                        var checkTask = taskService.ChangeStatus(id);

                        if (checkTask != true)
                        {
                            Console.WriteLine("Id not found and status not compatible");
                        }

                        break;
                    case 4:
                        Console.WriteLine("Completed Task");
                        Console.WriteLine();

                        int ids = int.Parse(Console.ReadLine());

                        var checkTask2 = taskService.ChangeStatus(ids);

                        if (checkTask2 != true)
                        {
                            Console.WriteLine("Id not found and status not compatible");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Remove Task");
                        Console.WriteLine();


                        int id3 = int.Parse(Console.ReadLine());

                        taskService.RemoveTasks(id3);
                        break;
                    case 6:
                        Console.WriteLine("History Task");
                        Console.WriteLine();

                        int id4 = int.Parse(Console.ReadLine());

                        var history = taskService.HistoryTask(id4);

                        foreach (var item in history)
                        {
                            Console.WriteLine(item);
                        }

                        break;
                    case 7:
                        Console.WriteLine("Filter Task");
                        Console.WriteLine();
                        var listFilter = taskService.FilterTask();


                        foreach (var item in listFilter)
                        {
                            Console.WriteLine($"Status: {item.Status}");
                        }
                        break;

                }
            }
            while (_option != 0);
        }
    }
}
