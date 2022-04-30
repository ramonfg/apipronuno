using System.Collections.Generic;
using System.Linq;
using Library.Models;
using System;

namespace Library.Functions
{
    public class UserFunctions
    {
        public static int TimeLimitLogin = 30;
        private readonly File File;
        private List<User> Users;
        private List<Access> Accesses;
        public UserFunctions()
        {
            this.File = new File();
            this.Users = new List<User>();
            this.Accesses = new List<Access>();
        }

        public IEnumerable<User> GetUsers()
        {
            this.Users = File.GetUsers();
            return this.Users;
        }

        public Access Login(string username, string password)
        {
            GetUsers();
            User found = this.Users.Where(user => user.Username == username && user.Password == password).SingleOrDefault();
            if (found is null) return new Access(new User(), true);
            else 
            {
                Access access = new Access(found, false);
                this.Accesses.Add(access);
                SetAccess();
                return access;
            }
        }
        public void SetAccess()
        {
            this.File.SetAccesses(this.Accesses);
        }

        public void GetAccesses()
        {
            this.Accesses = this.File.GetAccesses().Where(access => access.time.AddMinutes(UserFunctions.TimeLimitLogin) >= DateTime.Now).ToList<Access>();
        }

        public bool HasChangePermission(Guid guid)
        {
            GetAccesses();
            return this.Accesses.Where(access => access.guid == guid && access.user.Permission == 0).Any();
        }

        public bool HasReadPermission(Guid guid)
        {
            GetAccesses();
            return this.Accesses.Where(access => access.guid == guid).Any();
        }
    }
}