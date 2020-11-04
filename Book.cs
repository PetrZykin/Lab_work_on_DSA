using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_labRSP
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> authors = new List<string>();
        public string PublihingHouse { get; set; }
        public int PublishDate { get; set; }
        public int NumberOfPages { get; set; }
        public double Price { get; set; }
        public string TypeOfBinding { get; set; }       
    }
}
