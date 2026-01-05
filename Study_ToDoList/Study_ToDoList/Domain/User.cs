using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_ToDoList.Domain
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int LimitMaxTask { get; set; }

        public User() { }

        public User(Guid id, string name, string email, int limitMaxTask)
        {
            Id = id;
            Name = name;
            Email = email;
            LimitMaxTask = limitMaxTask;
        }

        public void CheckMaxTasks(int amountTask)
        {
            if(amountTask >= LimitMaxTask)
            {
                throw new InvalidOperationException ("Task limit exceeded");
            }
        }
    }
}
