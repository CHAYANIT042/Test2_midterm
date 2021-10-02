using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Books
    {
        private string[] booknames;

        public Books()
        {
            booknames = new string[] { "Now I understand", "Revolutionary Wealth", "Six Degrees", "Les Vacances" };
        }

        public string[] GetBookList()
        {
            return booknames;
        }
    }
}
