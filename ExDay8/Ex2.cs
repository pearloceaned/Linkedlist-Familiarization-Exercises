using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDay8
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public class LinkedList
    {
        public Node _first;
        public Node _last;
        public int _size;
        public int count
        {
            get
            {
                return _size;
            }
        }

        public Node getFirst()
        {
            return _first;
        }

        public LinkedList()
        {
            _first = null;
            _last = null;
            _size = 0;
        }

        public void addLast(int data)
        {
            Node newNode = new Node(data);
            if(_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                _last.next = newNode;
                _last = newNode;
            }
            _size++;
        }
        public void clear()
        {
            _first = null;
            _last = null;
            _size = 0;
        }
    }

    


    class Ex2
    {


        // Chức năng nối L2 vào cuối L1
        static void concatenateLists(LinkedList L1, LinkedList L2, LinkedList L3)
        {
            Node current = L1.getFirst();
            while (current != null)
            {
                L3.addLast(current.data);
                current = current.next;
            }
            current = L2.getFirst();
            while (current != null)
            {
                L3.addLast(current.data);
                current = current.next;
            }
        }

        // Chức năng trừ các phần tử của L2 khỏi L1
        static void differenceLists(LinkedList L1, LinkedList L2, LinkedList L3)
        {
            L3.clear();
            Node current = L1.getFirst();
            while (current != null)
            {
                if (!contains(L2, current.data))
                {
                    L3.addLast(current.data);
                }
                current = current.next;
            }
        }

        // Chức năng tìm giao điểm của L1 và L2
        static void intersectionLists(LinkedList L1, LinkedList L2, LinkedList L3)
        {
            L3.clear();
            Node current = L1.getFirst();
            while (current != null)
            {
                if (contains(L2, current.data))
                {
                    L3.addLast(current.data);
                }
                current = current.next;
            }
        }

        // Chức năng tìm hợp của L1 và L2
        static void unionLists(LinkedList L1, LinkedList L2, LinkedList L3)
        {
            L3.clear();
            Node current = L1.getFirst();
            while (current != null)
            {
                L3.addLast(current.data);
                current = current.next;
            }
            current = L2.getFirst();
            while (current != null)
            {
                if (!contains(L1, current.data))
                {
                    L3.addLast(current.data);
                }
                current = current.next;
            }
        }

        // Chức năng thêm các phần tử tương ứng của L1 và L2
        static void sumLists(LinkedList L1, LinkedList L2, LinkedList L3)
        {
            L3.clear();
            Node current1 = L1.getFirst();
            Node current2 = L2.getFirst();
            while (current1 != null || current2 != null)
            {
                int sum = 0;
                if (current1 != null)
                {
                    sum += current1.data;
                    current1 = current1.next;
                }
                if (current2 != null)
                {
                    sum += current2.data;
                    current2 = current2.next;
                }
                L3.addLast(sum);
            }
        }

        // Chức năng kiểm tra xem L1 và L2 có cùng phần tử không
        static bool checkSameValues(LinkedList L1, LinkedList L2)
        {
            Node current1 = L1.getFirst();
            Node current2 = L2.getFirst();
            while (current1 != null && current2 != null)
            {
                if (current1.data != current2.data)
                {
                    return false;
                }
                current1 = current1.next;
                current2 = current2.next;
            }
            return current1 == null && current2 == null;
        }

        // Chức năng loại bỏ nút đầu tiên trong L1 có giá trị lớn hơn tổng tất cả các giá trị trong L2the sum of all values in L2
        static void removeFirstGreaterThanSumOfL2(LinkedList L1, LinkedList L2)
        {
            int sumL2 = 0;
            Node current = L2.getFirst();
            while (current != null)
            {
                sumL2 += current.data;
                current = current.next;
            }

            current = L1.getFirst();
            Node previous = null;
            while (current != null)
            {
                if (current.data > sumL2)
                {
                    if (previous == null)
                    {
                        L1._first = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                    break;
                }
                previous = current;
                current = current.next;
            }
        }

        // Chức năng xóa tất cả các phần tử trong L1 có cùng giá trị với giá trị lớn nhất trong L2
        static void removeAllMaxFromL1(LinkedList L1, LinkedList L2)
        {
            int maxL2 = int.MinValue;
            Node current = L2.getFirst();
            while (current != null)
            {
                if (current.data > maxL2)
                {
                    maxL2 = current.data;
                }
                current = current.next;
            }

            current = L1.getFirst();
            Node previous = null;
            while (current != null)
            {
                if (current.data == maxL2)
                {
                    if (previous == null)
                    {
                        L1._first = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                    }
                }
                else
                {
                    previous = current;
                }
                current = current.next;
            }
        }

        // Hàm trợ giúp để kiểm tra xem danh sách có chứa giá trị hay không
        static bool contains(LinkedList list, int value)
        {
            Node current = list.getFirst();
            while (current != null)
            {
                if (current.data == value)
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }


        static int validInt(string name)
        {
            int Int;
            while (true)
            {
                Console.WriteLine(name);
                string tempInt = Console.ReadLine();
                if (int.TryParse(tempInt, out Int))
                {
                    return Int;
                }
                else
                {
                    Console.WriteLine("Đầu vào không hợp lệ, hãy nhập số nguyên");
                }
            }
        }

        static void input(LinkedList L1, LinkedList L2)
        {
            int l1 = validInt("Độ dài L1: ");
            
            for (int i = 0; i < l1; i++)
            {
                int temp = validInt($"Phần tử thứ {i + 1}");
                L1.addLast(temp);
                
            }
            int l2 = validInt("Độ dài L2: ");
            for (int i = 0; i < l2; i++)
            {
                int temp = validInt($"Phần tử thứ {i + 1}");
                L2.addLast(temp);
            }
        }

        static void output(LinkedList list)
        {
            Node current = list.getFirst();
            Console.Write("[ ");
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine("]");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            LinkedList L1 = new LinkedList();
            LinkedList L2 = new LinkedList();
            LinkedList L3 = new LinkedList();
            input(L1, L2);
            while (true)
            {
                int function = validInt("Chọn chức năng\n"
                + "0. Thoát chương trình\n"
                + "1. Xuất danh sách\n"
                + "2. Tạo danh sách L3 bằng cách nối L2 vào sau L1.\n"
                + "3. Tạo danh sách L3 bao gồm các phần tử chỉ có trong L1 mà không có trong L2(L3 là hiệu của L1 và L2)\n"
                + "4. Tạo danh sách L3 bao gồm các phần tử vừa có trong L1 vừa có trong L2 (L3 là giao của L1 và L2)\n"
                + "5. Tạo danh sách L3 bao gồm các phần tử hoặc có trong L1 hoặc có trong L2 (L3 là hợp của L1 và L2)\n"
                + "6. Tạo danh sách tổng L3 sao cho:\n"
                + "- Có độ dài là độ dài lớn nhất của L1 và L2.\n"
                + "- Có giá trị phần tử là tổng giá trị các phần tử tương ứng của L1 và L2"
                + "(các phần tử bị thiếu trong danh sách ngắn hơn xem như có giá trị 0).\n"
                + "7. Kiểm tra 2 danh sách L1 và L2 có trùng giá trị hay không?\n"
                + "8. Xóa một phần tử đầu tiên được tìm thấy trong L1 thõa mãn điều kiện: Giá"
                + " trị của nó lớn hơn tổng giá trị phần tử của L2.\n"
                + "9. Xóa tất cả các phần tử trong L1 có giá trị bằng giá trị lớn nhất trong L2."
                ) ;

                switch (function)
                {
                    case 1:
                        Console.WriteLine("Danh sách L1:");
                        output(L1);
                        Console.WriteLine("Danh sách L2:");
                        output(L2);
                        Console.WriteLine("Danh sách L3:");
                        output(L3);
                        break;
                    case 2:
                        concatenateLists(L1, L2, L3);
                        Console.WriteLine("L3 sau khi nối L2 vào sau L1:");
                        output(L3);
                        break;
                    case 3:
                        differenceLists(L1, L2, L3);
                        Console.WriteLine("L3 là hiệu của L1 và L2:");
                        output(L3);
                        break;
                    case 4:
                        intersectionLists(L1, L2, L3);
                        Console.WriteLine("L3 là giao của L1 và L2:");
                        output(L3);
                        break;
                    case 5:
                        unionLists(L1, L2, L3);
                        Console.WriteLine("L3 là hợp của L1 và L2:");
                        output(L3);
                        break;
                    case 6:
                        sumLists(L1, L2, L3);
                        Console.WriteLine("L3 là tổng của L1 và L2:");
                        output(L3);
                        break;
                    case 7:
                        bool isSame = checkSameValues(L1, L2);
                        Console.WriteLine(isSame ? "L1 và L2 có cùng giá trị" : "L1 và L2 không có cùng giá trị");
                        break;
                    case 8:
                        removeFirstGreaterThanSumOfL2(L1, L2);
                        Console.WriteLine("L1 sau khi xóa phần tử đầu tiên lớn hơn tổng của L2:");
                        output(L1);
                        break;
                    case 9:
                        removeAllMaxFromL1(L1, L2);
                        Console.WriteLine("L1 sau khi xóa tất cả phần tử có giá trị bằng giá trị lớn nhất của L2:");
                        output(L1);
                        break;
                }

            }
        }
    }
}
