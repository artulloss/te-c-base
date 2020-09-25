namespace BookStore
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        
        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
        public Book() {}
        
        public string BookInfo()
        {
            return "Title: " + Title + ", Author: " + Author + ", Price: $" + Price;
        }
    }
}