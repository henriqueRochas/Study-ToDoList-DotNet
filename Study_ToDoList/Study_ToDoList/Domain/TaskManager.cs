

namespace Study_ToDoList.Domain
{
    internal class TaskManager
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public Guid AssignedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? BlockedReason { get; set; }

        public enum TaskStatus
        {
            Pending,
            InProgress,
            Blocked,
            Completed
        }

        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }

        public TaskManager() { }

        public TaskManager(Guid id, string title, string description, TaskPriority priority)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            Status = TaskStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Start()
        {
            if(Status != TaskStatus.Pending)
            {
                throw new InvalidOperationException("Invalid operation: The current status is not 'Pending'.");
            }

            Status = TaskStatus.InProgress;
            StartedAt = DateTime.UtcNow;
        }

        public void Block(string? reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
            {
               throw new ArgumentException(nameof(reason), "This field cannot be empty.");
                
            }

            BlockedReason = reason;
            Status = TaskStatus.Blocked;
        }

        public void Complete()
        {
            if (Status == TaskStatus.Blocked)
            {
                throw new InvalidOperationException("The status is blocked. Please unlock it and try to confirm again.");
            }
            Status = TaskStatus.Completed;
            CompletedAt = DateTime.UtcNow;
        }
    }
}
