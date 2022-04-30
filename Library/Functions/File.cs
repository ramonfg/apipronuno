using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using System.IO;
using Newtonsoft.Json;

namespace Library.Functions
{
    public class File
    {
        public List<Book> GetBooks()
        {
            StreamReader streamReader = new StreamReader("jsons/books.json");
            string jsonString = streamReader.ReadToEnd();
            List<Book> listOfBooks = JsonConvert.DeserializeObject<List<Book>>(jsonString);
            streamReader.Close();
            return listOfBooks;
        }

        public void SetBooks(List<Book> books)
        {
            StreamWriter streamWriter = new StreamWriter("jsons/books.json");
            streamWriter.Write(JsonConvert.SerializeObject(books));
            streamWriter.Close();
        }

        public List<User> GetUsers()
        {
            StreamReader streamReader = new StreamReader("jsons/users.json");
            string jsonString = streamReader.ReadToEnd();
            List<User> listOfUsers = JsonConvert.DeserializeObject<List<User>>(jsonString);
            streamReader.Close();
            return listOfUsers;
        }

        public List<Access> GetAccesses()
        {
            StreamReader streamReader = new StreamReader("jsons/access.json");
            string jsonString = streamReader.ReadToEnd();
            List<Access> listOfAccesses = JsonConvert.DeserializeObject<List<Access>>(jsonString);
            streamReader.Close();
            return listOfAccesses;
        }

        public void SetAccesses(List<Access> accesses)
        {
            accesses = accesses.Where(access => access.time.AddMinutes(UserFunctions.TimeLimitLogin) >= DateTime.Now).ToList<Access>();
            StreamWriter streamWriter = new StreamWriter("jsons/access.json");
            streamWriter.Write(JsonConvert.SerializeObject(accesses));
            streamWriter.Close();
        }

        public List<Log> GetLogs()
        {
            StreamReader streamReader = new StreamReader("jsons/logs.json");
            string jsonString = streamReader.ReadToEnd();
            List<Log> listOflogs = JsonConvert.DeserializeObject<List<Log>>(jsonString);
            streamReader.Close();
            return listOflogs;
        }

        public void SetLogs(List<Log> logs)
        {
            StreamWriter streamWriter = new StreamWriter("jsons/logs.json");
            streamWriter.Write(JsonConvert.SerializeObject(logs));
            streamWriter.Close();
        }

    }
}