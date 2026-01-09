
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

            public TaskManager SearchTask(List<TaskManager> listTasks, int id)
            {
                var search = listTasks.FirstOrDefault(a => a.Id == id);

                if (search != null)
                {
                    return search;
                }
                else
                {
                    return null;
                }
            }

            public bool ChangeStatus(List<TaskManager> listTasks, int id)
            {
                var resultSearch = SearchTask(listTasks, id);

                if (resultSearch == null)
                {
                    return false;
                }
                else
                {
                    if (resultSearch.Status == StatusTask.Pending)
                    {
                        resultSearch.Status = StatusTask.Progress;
                        return true;
                    }
                    else if (resultSearch.Status == StatusTask.Progress)
                    {
                        resultSearch.Status = StatusTask.Completed;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            List<TaskManager> listTasks = new List<TaskManager>();
            int _option;

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

                        listTasks.AddRange(new List<TaskManager>
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

                        break;
                    case 2:
                        Console.WriteLine("List Task");
                        Console.WriteLine();

                        foreach (var item in listTasks)
                        {
                            Console.WriteLine($"Id: {item.Id} Title: {item.Title} Status: {item.Status}");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Start Task");
                        Console.WriteLine();

                        bool checkId = false;
                        int id = int.Parse(Console.ReadLine());

                        foreach (var item in listTasks)
                        {
                            if (item.Id == id)
                            {
                                if (item.Status == StatusTask.Pending)
                                {
                                    item.Status = StatusTask.Progress;
                                    checkId = true;
                                    item.HistoryTask.Add("Task progress");
                                    break;
                                }
                            }
                        }

                        if (checkId != true)
                        {
                            Console.WriteLine("Id not found and status not compatible");
                        }

                        break;
                    case 4:
                        Console.WriteLine("Completed Task");
                        Console.WriteLine();

                        bool checkId2 = false;
                        int ids = int.Parse(Console.ReadLine());

                        foreach (var item in listTasks)
                        {
                            if (item.Id == ids)
                            {
                                if (item.Status == StatusTask.Progress)
                                {
                                    item.Status = StatusTask.Completed;
                                    checkId2 = true;
                                    item.HistoryTask.Add("Task completed");
                                    break;
                                }
                            }
                        }

                        if (checkId2 != true)
                        {
                            Console.WriteLine("Id not found and status not compatible");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Remove Task");
                        Console.WriteLine();

                        bool checkId3 = false;
                        int id3 = int.Parse(Console.ReadLine());

                        for (int i = 0; i < listTasks.Count; i++)
                        {
                            var item = listTasks[i];
                            if (item.Id == id3)
                            {
                                if (item.Status == StatusTask.Completed)
                                {
                                    item.HistoryTask.Add("Task remove");
                                    listTasks.RemoveAt(i);
                                    checkId3 = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("The task exists, but it is incomplete and can't be removed");
                                }
                            }
                        }
                        if (!checkId3)
                        {
                            Console.WriteLine("Id not found and status not compatible");
                        }

                        break;
                    case 6:
                        int id4 = int.Parse(Console.ReadLine());

                        foreach (var item in listTasks)
                        {
                            if (item.Id == id4)
                            {
                                foreach (var item1 in item.HistoryTask)
                                {
                                    Console.WriteLine(item1);
                                }
                            }
                        }
                        break;

                    case 7:
                        var filterStatusTask1 = listTasks.Where(i => i.Status == StatusTask.Pending);

                        foreach (var item in filterStatusTask1)
                        {
                            Console.WriteLine($"Status: {item.Status}");
                        }

                        Console.WriteLine();
                        var filterStatusTask2 = listTasks
                            .Where(r => r.Status == StatusTask.Completed);

                        foreach (var item1 in filterStatusTask2)
                        {
                            Console.WriteLine($"Status: {item1.Status}");
                        }

                        Console.WriteLine();

                        var count = listTasks.GroupBy(a => a.Status);

                        foreach (var item in count)
                        {
                            Console.WriteLine($"Status: {item.Key} Amount: {item.Count()}");
                        }

                        Console.WriteLine();

                        var check = listTasks.FirstOrDefault(p => p.Status == StatusTask.Progress);
                        Console.WriteLine($"Status: {check.Status}");
                        break;
                }
            }
            while (_option != 0);
        }
    }
}
