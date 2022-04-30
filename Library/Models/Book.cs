namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public Book (int id, string name, string author, int pages){
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.Pages = pages;
        }
    }
}