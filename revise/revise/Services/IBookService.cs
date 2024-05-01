using revise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookService
    {
        int userId { get; set; }

        List<Book> AllBooks();
    }
}
