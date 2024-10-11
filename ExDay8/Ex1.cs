using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDay7
{
    public class Node
    {
        internal int Data;
        internal Node Next;
        public Node(int Data)
        {
            this.Data = Data;
            this.Next = null;
        }
    }

    public class LinkedList
    {
        public Node _first;
        public Node _last;
        public int _size;
        public int Count
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


        public void AddLast(int data)
        {
            Node newNode = new Node(data);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                _last.Next = newNode;
                _last = newNode;
            }

            _size++;
        }



    }


    class Ex
    {
        static int validInt(string name)
        {
            int tmpInt = 0;
            while (true)
            {
                Console.WriteLine(name);
                string n = Console.ReadLine();
                if (int.TryParse(n, out tmpInt))
                {
                    return tmpInt;
                }
                else
                {
                    Console.WriteLine("Đầu vào không hợp lệ, hãy nhập số nguyên!");
                }

            }

        }

        static void input(LinkedList list)
        {
            int n = validInt("Số lượng phần tử: ");


            for (int i = 0; i < n; i++)
            {
                int endX = validInt($"Phần tử thứ {i + 1}");
                list.AddLast(endX);
            }
        }

        static void output(LinkedList list)
        {
            Console.WriteLine("Danh sách phần tử:");
            Node current = list.getFirst();
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.ReadLine();

        }

        static bool isPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static void listPrimes(LinkedList list)
        {
            Console.WriteLine("Các số nguyên tố trong danh sách:");
            Node current = list.getFirst();
            while (current != null)
            {
                if (isPrime(current.Data))
                {
                    Console.Write(current.Data + " ");
                }
                current = current.Next;
            }
            Console.WriteLine();
        }

        static void average(LinkedList list)
        {
            Node current = list.getFirst();
            int sum = 0, count = 0;
            while (current != null)
            {
                sum += current.Data;
                count++;
                current = current.Next;
            }

            if (count > 0)
            {
                double avg = (double)sum / count;
                Console.WriteLine($"Trung bình cộng các phần tử trong danh sách: {avg}");
            }
            else
            {
                Console.WriteLine("Danh sách rỗng!");
            }
        }

        static void countOccurrences(LinkedList list)
        {
            int x = validInt("Nhập giá trị x cần đếm: ");
            Node current = list.getFirst();
            int count = 0;
            while (current != null)
            {
                if (current.Data == x)
                    count++;
                current = current.Next;
            }
            Console.WriteLine($"Số lần xuất hiện của {x}: {count}");
        }

        static bool isPerfectSquare(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            return sqrt * sqrt == n;
        }

        static void findLastPerfectSquare(LinkedList list)
        {
            Node current = list.getFirst();
            int lastPerfectSquare = -1;
            while (current != null)
            {
                if (isPerfectSquare(current.Data))
                {
                    lastPerfectSquare = current.Data;
                }
                current = current.Next;
            }

            if (lastPerfectSquare != -1)
            {
                Console.WriteLine($"Số chính phương cuối cùng trong danh sách: {lastPerfectSquare}");
            }
            else
            {
                Console.WriteLine("Không có số chính phương trong danh sách.");
            }
        }

        static void findKthElement(LinkedList list)
        {
            int k = validInt("Nhập vị trí k: ");
            Node current = list.getFirst();
            int index = 1;
            while (current != null && index < k)
            {
                current = current.Next;
                index++;
            }

            if (current != null)
            {
                Console.WriteLine($"Phần tử thứ {k}: {current.Data}");
            }
            else
            {
                Console.WriteLine("Vị trí k không tồn tại.");
            }
        }

        static void findMinElement(LinkedList list)
        {
            Node current = list.getFirst();
            if (current == null)
            {
                Console.WriteLine("Danh sách rỗng!");
                return;
            }

            int min = current.Data;
            while (current != null)
            {
                if (current.Data < min)
                {
                    min = current.Data;
                }
                current = current.Next;
            }
            Console.WriteLine($"Giá trị nhỏ nhất trong danh sách: {min}");
        }

        static void addAfter(LinkedList list)
        {
            int q = validInt("Nhập giá trị q: ");
            int newVal = validInt("Nhập giá trị phần tử mới: ");
            Node current = list.getFirst();
            while (current != null && current.Data != q)
            {
                current = current.Next;
            }

            if (current != null)
            {
                Node newNode = new Node(newVal);
                newNode.Next = current.Next;
                current.Next = newNode;
                Console.WriteLine($"Thêm phần tử {newVal} vào sau {q} thành công.");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy phần tử có giá trị {q}.");
            }
        }

        static bool contains(LinkedList list, int data)
        {
            Node current = list.getFirst();
            while (current != null)
            {
                if (current.Data == data)
                    return true;
                current = current.Next;
            }
            return false;
        }

        static void addUnique(LinkedList list)
        {
            int newVal = validInt("Nhập giá trị phần tử mới: ");
            if (!contains(list, newVal))
            {
                list.AddLast(newVal);
                Console.WriteLine($"Thêm phần tử {newVal} thành công.");
            }
            else
            {
                Console.WriteLine($"Phần tử {newVal} đã tồn tại.");
            }
        }

        static void removeFirstK(LinkedList list)
        {
            int k = validInt("Nhập số phần tử k cần xóa: ");
            for (int i = 0; i < k; i++)
            {
                if (list.getFirst() != null)
                {
                    list._first = list.getFirst().Next;
                    list._size--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"{k} phần tử đầu tiên đã được xóa.");
        }

        static void removeByValue(LinkedList list)
        {
            int x = validInt("Nhập giá trị x cần xóa: ");
            Node current = list.getFirst();
            Node prev = null;

            while (current != null)
            {
                if (current.Data == x)
                {
                    if (prev == null)
                    {
                        
                        list._first = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    list._size--;
                    Console.WriteLine($"Đã xóa phần tử có giá trị {x}.");
                    return;
                }
                prev = current;
                current = current.Next;
            }

            Console.WriteLine($"Không tìm thấy phần tử có giá trị {x}.");
        }

        static void removeAfter(LinkedList list)
        {
            int q = validInt("Nhập giá trị q: ");
            Node current = list.getFirst();

            while (current != null && current.Data != q)
            {
                current = current.Next;
            }

            if (current != null && current.Next != null)
            {
                current.Next = current.Next.Next;
                list._size--;
                Console.WriteLine($"Đã xóa phần tử sau {q}.");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy phần tử sau {q} hoặc phần tử q không tồn tại.");
            }
        }

        static void removeDuplicates(LinkedList list)
        {
            Node current = list.getFirst();
            while (current != null)
            {
                Node runner = current;
                while (runner.Next != null)
                {
                    if (runner.Next.Data == current.Data)
                    {
                        runner.Next = runner.Next.Next;
                        list._size--;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
            Console.WriteLine("Đã xóa các phần tử lặp lại.");
        }

        static void interchangeSort(LinkedList list)
        {
            if (list.getFirst() == null) return;

            Node i = list.getFirst();
            while (i != null)
            {
                Node j = i.Next;
                while (j != null)
                {
                    if (i.Data > j.Data)
                    {
                        int temp = i.Data;
                        i.Data = j.Data;
                        j.Data = temp;
                    }
                    j = j.Next;
                }
                i = i.Next;
            }
            Console.WriteLine("Danh sách đã được sắp xếp theo thứ tự tăng dần.");
        }

        static void addInSortedOrder(LinkedList list)
        {
            int newVal = validInt("Nhập giá trị phần tử mới cần thêm: ");
            Node newNode = new Node(newVal);

            
            if (list.getFirst() == null || list.getFirst().Data > newVal)
            {
                newNode.Next = list.getFirst();
                list._first = newNode;
                list._size++;
            }
            else
            {
                Node current = list.getFirst();
                while (current.Next != null && current.Next.Data < newVal)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                list._size++;
            }
            Console.WriteLine($"Đã thêm phần tử {newVal} vào danh sách.");
        }

        static bool isPerfectNumber(int n)
        {
            if (n < 2) return false;
            int sum = 1;
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }
            return sum == n;
        }

        static void updatePerfectNumbers(LinkedList list)
        {
            Node current = list.getFirst();
            while (current != null)
            {
                if (isPerfectNumber(current.Data))
                {
                    current.Data = 0;
                }
                current = current.Next;
            }
            Console.WriteLine("Các số hoàn thiện trong danh sách đã được cập nhật thánh số 0.");
        }



        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            LinkedList list = new LinkedList();
            input(list);

            while (true)
            {
                int func = validInt("Chọn chức năng: \n"
                                  + "0.Thoát chương trình. \n"
                                  + "1.Xuất danh sách ra màn hình.\n"
                                  + "2.Liệt kê các số nguyên tố có trong danh sách.\n"
                                  + "3.Tính trung bình cộng của các phần tử trong danh sách.\n"
                                  + "4.Đếm số lần xuất hiện của một số nguyên nhập từ bàn phím có trong danh sách.\n"
                                  + "5.Tìm số chính phương cuối cùng trong danh sách.\n"
                                  + "6.Tìm và trả về phần tử thứ k trong danh sách tính từ đầu danh sách.\n"
                                  + "7.Tìm phần tử có giá trị nhỏ nhất trong danh sách.\n"
                                  + "8.Thêm một phần tử vào sau phần tử q trong danh sách.\n"
                                  + "9.Thêm một phần tử vào danh sách sao cho phần tử thêm vào không trùng với các phần tử đã có trong danh sách.\n"
                                  + "10.Xóa k phần tử ở đầu danh sách(k nhập từ bàn phím).\n"
                                  + "11.Xóa phần tử có giá trị bằng x có trong danh sách.\n"
                                  + "12.Xóa một phần tử sau phần tử q trong danh sách.\n"
                                  + "13.Xóa tất cả các phần tử lặp lại trong danh sách(chỉ giữ lại duy nhất 1 phần tử).\n"
                                  + "14.Sắp xếp danh sách theo thứ tự tăng dần dùng InterchangeSort.\n"
                                  + "15.Thêm một phần tử vào danh sách tăng dần(Quá trình thêm không làm mất tính tăng dần của danh sách).\n"
                                  + "16.Cập nhật các số hoàn thiện trong danh sách thành số 0.\n") ;
                switch (func)
                {
                    
                    case 1:
                        output(list);
                        break;
                    case 2:
                        listPrimes(list);
                        break;
                    case 3:
                        average(list);
                        break;
                    case 4:
                        countOccurrences(list);
                        break;
                    case 5:
                        findLastPerfectSquare(list);
                        break;
                    case 6:
                        findKthElement(list);
                        break;
                    case 7:
                        findMinElement(list);
                        break;
                    case 8:
                        addAfter(list);
                        break;
                    case 9:
                        addUnique(list);
                        break;
                    case 10:
                        removeFirstK(list);
                        break;
                    case 11:
                        removeByValue(list);
                        break;
                    case 12:
                        removeAfter(list);
                        break;
                    case 13:
                        removeDuplicates(list);
                        break;
                    case 14:
                        interchangeSort(list);
                        break;
                    case 15:
                        addInSortedOrder(list);
                        break;
                    case 16:
                        updatePerfectNumbers(list);
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ, vui lòng chọn lại.");
                        break;
                }
                if(func == 0)
                {
                    break;
                }
            } 
        }
    }
}
