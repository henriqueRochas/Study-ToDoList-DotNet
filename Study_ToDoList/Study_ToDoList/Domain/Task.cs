using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Study_ToDoList.Domain
{
    internal class Task
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

        public Task() { }

        public Task(Guid id, string title, string description, TaskPriority priority)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            Status = TaskStatus.Pending;
            CreatedAt = DateTime.UtcNow;

        }

        public void 


    }
}
