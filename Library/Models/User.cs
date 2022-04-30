using System;
using System.Linq;
using Library.Functions;
using System.Collections.Generic;

namespace Library.Models
{
    public enum Permissions
    {
        Manage,
        Read
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Permissions Permission { get; set; }
    }

    public class Access
    {
        public User user { get; set; }
        public Guid guid { get; set; }
        public DateTime time { get; set; }
        public bool denied { get; set; }
        public Access(User user, bool denied)
        {
            this.user = user;
            this.guid = Guid.NewGuid();
            this.time = DateTime.Now;
            this.denied = denied;
        }
    }
}

