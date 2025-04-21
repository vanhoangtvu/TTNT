using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HDUT
{
    private int front; //Con trỏ chỉ ở đầu hàng đợi
    private int rear;  //Con trỏ ở cuối hàng đợi
    private int noItems; //Spt hiện có của hàng đợi
    private Element[] arr; //Dữ liệu của hàng đợi là một Element vừa được trình bày
    static readonly int MAX = 1000; //Spt tối đa có thể có trong hàng đợi

    public HDUT()
    {
        this.front = -1;
        this.rear = -1;
        this.noItems = 0;
        this.arr = new Element[MAX];
    }

    public void enQueue(Element x) //OK
    {
        // This logic seems intended for a circular queue or fixed buffer
        // but the check `noItems == MAX` before incrementing rear is unusual.
        // It appears to overwrite arr[0] when full, otherwise appends.
        // Standard priority queue enqueue logic would involve maintaining order.
        if (this.noItems == MAX)
            this.rear = 0; // If full, wrap rear to 0 (overwriting oldest?)
        else
            this.rear++; // Otherwise, increment rear

        this.arr[this.rear] = x; // Place element at the new rear position
        this.noItems++; // Increment item count

        // Note: A standard queue might also update 'front' if it was the first item added.
        // Note: This enqueue does NOT maintain priority order.
    }

    //Thực hiện lấy từ Hàng đợi phần tử có chi phí g là thấp nhất
    public Element deQueue()
    {
        Element elmt = new Element(0, 0, -5); // Initialize a temporary element

        //Cài đặt cách lấy phần tử ra khỏi hàng đợi với độ ưu tiên là chi phí thấp nhất
        //Tìm phần tử có chi phí (g) nhỏ nhất trong queue
        //Đổi chỗ với phần tử ở vị trí đầu hàng đợi (front)
        //thực hiện lấy phần tử ở đầu hàng đợi X;

        // --- The actual implementation for finding the min 'g' element, ---
        // --- swapping it with the front, and removing it is missing here ---
        // --- in the provided image snippet.                             ---

        // Placeholder return based on initialization above
        return elmt;
    }

    // ... (rest of the class definition might follow)
}