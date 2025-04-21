using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS
{
    class Element // Định nghĩa mỗi phần tử trong hàng đợi ưu tiên
    {
        private int tendinh;
        private int g; //Tiêu chí để ưu tiên chọn phần tử xem xét trước
        private int pre;

        //Hàm khởi tạo không có tham số
        public Element()
        {
            tendinh = -1;
            g = 0;
            pre = -2;
        }

        //Hàm khởi tạo Element với 3 tham số
        public Element(int dinh, int cp, int dt)
        {
            tendinh = dinh;
            g = cp;
            pre = dt;
        }
        public void printElmt()
        {
            Console.Write("\n ({0},{1},{2})", tendinh, g, pre); //Giống như phần ví dụ trình bày trong phần lý thuyết
        }

        //Các hàm get/set dữ liệu thành viên
        public int TenDinh
        {
            get { return tendinh; }
            set { tendinh = value; }
        }

        public int G
        {
            get { return g; }
            set { g = value; }
        }

        public int Pre
        {
            get { return pre; }
            set { pre = value; }
        }
    } 
}