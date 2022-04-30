using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library.Functions;
using Library.Models;
using System;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly BookFunctions bookFunctions;
        private readonly UserFunctions userFunctions;
        private readonly LogFunctions logFunctions;
        public BooksController()
        {
            this.bookFunctions = new BookFunctions();
            this.userFunctions = new UserFunctions();
            this.logFunctions = new LogFunctions();
        }

        [HttpGet("{guid}")]
        public ActionResult<List<Book>> GetBooks(Guid guid)
        {
            if (!this.userFunctions.HasReadPermission(guid)) return Unauthorized();
            return Ok(bookFunctions.GetBooks());
        }

        [HttpGet("id")]
        public ActionResult<Book> GetBook(int id, Guid guid)
        {
            if (!this.userFunctions.HasReadPermission(guid)) return Unauthorized();
            Book book = bookFunctions.GetBook(id);
            if (book is null) return NotFound();
            else return Ok(book);
        }

        [HttpGet("{text}")]
        public ActionResult<List<Book>> SearchBook(GetBookDto getbook)
        {
            if (!this.userFunctions.HasReadPermission(getbook.Guid)) return Unauthorized();
            List<Book> searched = bookFunctions.SearchBook(getbook.Text);
            if (searched.Count == 0) return NotFound();
            else return Ok(searched);
        }

        [HttpPost]
        public ActionResult AddBook(AddBookDto addBook)
        {
            if (!this.userFunctions.HasChangePermission(addBook.Guid)) return Unauthorized();
            Book b = new Book(bookFunctions.GetHighestId() + 1, addBook.Name, addBook.Author, addBook.Pages);
            bookFunctions.AddBook(b);
            return Ok();
        }

        [HttpPut]
        public ActionResult EditBook(EditBookDto editBook)
        {
            if (!this.userFunctions.HasChangePermission(editBook.Guid)) return Unauthorized();
            Book b = new Book(editBook.Id, editBook.Name, editBook.Author, editBook.Pages);
            if (!bookFunctions.EditBook(b)) return NotFound();
            else return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteBook(DeleteBookDto deleteBook)
        {
            if (!this.userFunctions.HasChangePermission(deleteBook.Guid)) return Unauthorized();
            if (!bookFunctions.DeleteBook(deleteBook.Id)) return NotFound();
            else return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBooks(Guid guid)
        {
            if (!this.userFunctions.HasChangePermission(guid)) return Unauthorized();
            bookFunctions.DeleteBooks();
            return Ok();
        }
    }
}