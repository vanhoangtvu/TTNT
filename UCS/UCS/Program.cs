using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Kiểm tra việc thực hiện hàng đợi ưu tiên
            Element el1 = new Element(4, 9, 0);
            Element el2 = new Element(5, 1, 0);

            HDUT q = new HDUT(); // Assuming HDUT is the Priority Queue class
            q.enQueue(el1);
            q.enQueue(el2);

            Element elm = q.deQueue();
            elm.printElmt(); //Ket qua phai la (5,1,0) vi chi phi 1 tai el2 < 9 tai el1

            //2. Kiểm tra thực hiện giải thuật UCS
            UCSAlg ucs = new UCSAlg(); // Assuming UCSAlg is the class for the algorithm
            ucs.UCS_Search(); // Assuming UCS_Search is the method to run the search

            Console.ReadLine(); // Keep console window open
        }
    }
}