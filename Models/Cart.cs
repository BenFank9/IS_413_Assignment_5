using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //when they go to add an item were going to pass in the object and quantity.
        //go into the lines object and select where the Books is == the Books passed in.
        public virtual void AddItem(Books books, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Books.BookId == books.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Books = books,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //remove a line or an item in the cart
        public virtual void RemoveLine(Books books) =>
            Lines.RemoveAll(x => x.Books.BookId == books.BookId);

        //get a total price
        public decimal ComputeTotalSum() => 
            (decimal)Lines.Sum(e => e.Books.Price * e.Quantity);

        //clear everything in the cart
        public virtual void Clear() => Lines.Clear();

    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Books Books { get; set; }
        public int Quantity { get; set; }

    }
    
}
