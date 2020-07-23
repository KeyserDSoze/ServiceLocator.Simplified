using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator.Models
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        private Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }
        public static Book CreateNew(string title = null, string author = null)
            => new Book(title ?? Guid.NewGuid().ToString("N"), author ?? Guid.NewGuid().ToString("N"));
    }
}
