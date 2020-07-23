using ServiceLocator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator.Abstractions
{
    public interface IReadable
    {
        IEnumerable<Book> List();
    }
}