using System.Collections.Generic;

namespace BookStore
{
    public class ShoppingCart
    {
        private List<Book> _booksToBuy = new List<Book>();
        
        public void Add(Book newBook)
        {
            _booksToBuy.Add(newBook);
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (Book book in _booksToBuy)
                {
                    total += book.Price;
                }
                return total;
            }
        }
        
        public string PrintReceipt()
        {
            string receipt = "\nReceipt\n";
            foreach (Book book in _booksToBuy)
            {
                receipt += book.BookInfo();
                receipt += "\n";
            }

            receipt += "\nTotal: $" + TotalPrice;

            return receipt;
        }
    }
}