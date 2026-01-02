using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_ToDoList
{
    internal class User
    {

        public User() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int LimitMaxTask { get; set; }

        public User(Guid id, string name, string email, int limitMaxTask)
        {
            Id = id;
            Name = name;
            Email = email;
            LimitMaxTask = limitMaxTask;
        }
    }
}
