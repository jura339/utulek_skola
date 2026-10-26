using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<zvire> list = new List<zvire>();

            zvire pepa = new zvire("Pepa", 5, "pes", 'M', 20220101, "zdravý", "bez poznámky");
            list.Add(pepa);
            pepa.Vypis();
        }
    }
}
