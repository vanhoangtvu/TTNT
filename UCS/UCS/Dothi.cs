
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS
{
    class Dothi
    {
        private int sodinh;
        private int start;
        private int goal;
        private int[,] matran;

        public Dothi()
        {
            this.sodinh = -1;
            this.start = -1;
            // Có thể thay thế số 12 bằng 1 hằng nào đó được định nghĩa ở đầu tập tin
            this.matran = new int[12, 12];
            readDothi();
        }

        // Doc file tu o dia, Giong phan thuc hanh BFS và LCBFS
        public void readDothi()
        {
            // Đổi đường dẫn phù hợp với bài tập của SV
            string textFile = @"C:\Users\Hoc vien\Desktop\TTNT\UCS\UCSinput.txt";
            if (File.Exists(textFile))
            {
                // Read a text file line by line.
                string[] lines = File.ReadAllLines(textFile);
                string line0 = lines[0].Trim(); // Dong thu 1
                this.sodinh = Convert.ToInt16(line0);

                string line1 = lines[1].Trim();
                string[] tam = line1.Split(' ');
                this.start = Convert.ToInt16(tam[0]);
                this.goal = Convert.ToInt16(tam[1]);

                for (int i = 0; i < this.sodinh; i++)
                {
                    string linei = lines[i + 2].Trim();
                    //Console.WriteLine(linei);
                    string[] arr = linei.Split(' ');
                    for (int j = 0; j < this.sodinh; j++)
                    {
                        this.matran[i, j] = Convert.ToInt32(arr[j]);
                        //Console.Write(matran[i,j] + " ");
                    }
                    //Console.WriteLine();
                }

            }
        }
        public void printDothi() //Hien thi noi dung da doc
        {
            System.Console.WriteLine("So dinh: {0}", sodinh);
            System.Console.WriteLine("Start:{0}; Goal: {1} ", start, goal);
            for (int i = 0; i < this.sodinh; i++)
            {
                Console.WriteLine(); // Xuống dòng cho mỗi hàng mới của ma trận
                for (int j = 0; j < this.sodinh; j++)
                {
                    Console.Write(this.matran[i, j] + " "); // In phần tử và một khoảng trắng
                }

            }

            public int SoDinh
        {
            get { return sodinh; }
            set { sodinh = value; }
        }
        public int Start
        {
            get { return start; }
            set { start = value; }
        }

        public int Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        public int[,] MaTran
        {
            get { return matran; }
            set { matran = value; }
        }
    }

}
