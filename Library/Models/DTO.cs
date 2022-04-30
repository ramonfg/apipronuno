using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Library.Models
{
    public class AddBookDto
    {
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Guid Guid { get; set; }
    }

    public class EditBookDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Guid Guid { get; set; }
    }

    public class DeleteBookDto
    {
        public int Id;
        public Guid Guid { get; set; }
    }

    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class GetBookIdDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }

    public class GetBookDto
    {
        public string Text { get; set; }
        public Guid Guid { get; set; }
    }

}