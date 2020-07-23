using ServiceLocator.Abstractions;
using ServiceLocator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator
{
    public class Library : IReadable
    {
        public Manager Manager { get; }
        private readonly List<Book> Books = new List<Book>();
        //inject in library service the service locator to use every service inside here
        public Library(Manager manager)
        {
            this.Manager = manager;
            this.Books = new List<Book> { Book.CreateNew(), Book.CreateNew(), Book.CreateNew(), Book.CreateNew(), Book.CreateNew() };
        }

        public IEnumerable<Book> List()
            => this.Books;
        //Singleton simulation
        public static Library Instance { get; } = new Library(null);
    }
}
