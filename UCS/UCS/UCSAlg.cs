using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCS
{
    class UCSAlg
    {
        private Dothi g;             
        private HDUT OPEN;            
        private Element[] CLOSE;    
        private static readonly int NIL = -5; 

        //Thực hiện dòng lệnh thứ 2 của giải thuật tại hàm UCSAlg
        // 2. Khởi tạo hàng đợi ưu tiên, tập đóng và đưa đỉnh start vào hàng đợi OPEN
        public UCSAlg()
        {
            g = new Dothi();            
            OPEN = new HDUT();          
            CLOSE = new Element[g.SoDinh];

            // Initialize CLOSE array elements (optional, but good practice)
            for (int i = 0; i < g.SoDinh; i++)
            {
                Element elmt = new Element(); // Create default Element (tendinh=-1, g=0, pre=-2)
                CLOSE[i] = elmt;              // Assign to CLOSE array (marks all nodes as unvisited initially)
                                              // Note: Using tendinh=-1 might be the check for visited status later.
            }

            // Create the starting element: (start_vertex_ID, cost=0, predecessor=NIL)
            Element startElmt = new Element(g.Start, 0, NIL); // e.g., (0, 0, -5) if Start is 0
            OPEN.enQueue(startElmt); // Add the starting element to the OPEN queue
        }

        // (Continuing the UCS_Search method from the previous image)
        public bool UCS_Search()
        {
            while (!OPEN.isEmpty()) // Dòng 3: Trong khi hàng đợi (OPEN) còn phần tử
            {
                Element X = OPEN.deQueue(); // Lấy phần tử có chi phí thấp nhất (ví dụ: //{0,0,-5}: Đỉnh bắt đầu)

                // Mark node X as visited (conceptually adding to CLOSE set)
                // The commented line below is likely incorrect syntax/logic.
                // A better approach: if (CLOSE[X.TenDinh].TenDinh != -1) continue; // Already visited with optimal path
                // CLOSE[X.TenDinh] = X; // Store the path info for X
                // //CLOSE[3] = X; //Xác định vị trí <-- Incorrect/Specific Comment

                if (X.TenDinh == g.Goal) // Check if the current node X is the goal
                {
                    Console.WriteLine("Tìm được đường đi!"); // Found the path!
                                                             // Need to store X in CLOSE here too, so the path can be reconstructed
                    CLOSE[X.TenDinh] = X;
                    return true; // Signal success
                }
                else // If X is not the goal, expand its neighbors
                     // Xét đỉnh sau J của X tại dòng lệnh thứ 7 của giải thuật
                {
                    // Mark X as visited *after* dequeuing and *before* expanding neighbors
                    // This prevents revisiting the same node unnecessarily in the current path search
                    if (CLOSE[X.TenDinh].TenDinh != -1 && CLOSE[X.TenDinh].G <= X.G)
                    {
                        // If already in CLOSE with an equal or better path cost, skip expansion
                        continue;
                    }
                    CLOSE[X.TenDinh] = X; // Record the best path found so far to X


                    for (int J = 0; J < g.SoDinh; J++) // Iterate through potential neighbors J
                    {
                        // Check if there is an edge from X to J
                        if (g.MaTran[X.TenDinh, J] > 0) // Assumes > 0 indicates edge weight
                        {
                            Console.WriteLine("Dinh sau J={0}", J); // Print neighbor ID

                            // --- Student needs to add code here ---
                            // //SV bổ sung một vài dòng lệnh vào trong đoạn này để hoàn thành bài thực hành
                            // 1. Calculate cost to reach neighbor J via X:
                            int newCost = X.G + g.MaTran[X.TenDinh, J];

                            // 2. Check if J is already in CLOSE with a better or equal path cost
                            if (CLOSE[J].TenDinh != -1 && CLOSE[J].G <= newCost)
                            {
                                continue; // Skip if a better or equal path to J is already found and processed
                            }

                            // 3. Check if J is in OPEN (needs a way to check/update OPEN efficiently)
                            //    or if J is not in CLOSE (or has a worse cost in CLOSE)
                            //    If a better path to J is found (or J is new), create/update Element and add to OPEN.
                            //    (This part depends heavily on how HDUT allows checking/updating priorities)

                            // Simplified logic (assuming HDUT handles duplicates/updates correctly or we just add):
                            // Check if neighbor J has already been processed via CLOSE check above.
                            // If not processed or if this path is better than any recorded path to J (implicit in HDUT update/check or explicit check needed)
                            // then enqueue.

                            // Only enqueue if we potentially found a better path than one already processed
                            // (More sophisticated check involving OPEN contents might be needed depending on HDUT)
                            Element neighborElement = new Element(J, newCost, X.TenDinh);
                            OPEN.enQueue(neighborElement); // Add neighbor to the priority queue

                        } // End if edge exists
                    } // End for neighbors J

                    // !!! Potential logical error in original image: returning true here is incorrect !!!
                    // The search should continue with the next element from OPEN.
                    // return true; <-- REMOVED (This would stop the search prematurely)

                } // End else (X is not the goal)
            } // End while OPEN is not empty

            // If the loop finishes and the goal was not found
            return false; // Signal failure
        } // End UCS_Search method

        //Phương thức in đường đi
        // ... (Path printing method implementation would go here, using the CLOSE array) ...

    } // End class UCSAlg (likely)