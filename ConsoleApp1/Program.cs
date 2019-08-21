using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var database = new EntityFrameWork.PublixLibraryEntities())
            {
                foreach(var publisher in database.PublixLibraries.Select(b => b.Publisher).Distinct())
                {
                    var filename = publisher + ".txt";
                    var books = database.PublixLibraries.Where(b => b.Publisher == publisher).OrderBy(b => b.Title).ToArray().Select(b => String.Format("{0}\t{1}\t{2}", b.Title, b.Author, b.Price));
                    if (books !=null)
                    {
                        System.IO.File.WriteAllLines(filename, books);
                    }
                }
            }
        }
    }
}
