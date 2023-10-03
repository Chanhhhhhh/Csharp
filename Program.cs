using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal class exs
    {

        // bai 1 
        public void find()
        {
            int[] arr = new int[] { 1, 5, 3, 7, 6, 8, 4, 8, 1, 0 };
            int minOOD = arr[0]; // so Le nho nhat
            int maxEVEN = arr[0]; // so Chan lon nhat
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1 && arr[i] < minOOD)
                    minOOD = arr[i];
                if (arr[i] % 2 == 0 && arr[i] > maxEVEN)
                    maxEVEN = arr[i];
            }

            Console.Write($"min :{minOOD}\nmax :{maxEVEN}\n");
        }


        // bai 2
        public void delete(int value) // value (giá trị cần xóa trong list)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 4, 4, 6, 8, 9, 10 };
            for (int i = 0; i < list.Count; i++)
            {
                if (list.Contains(value))
                    list.Remove(value);
                else
                    break;
            }

            foreach (int i in list)
            {
                Console.Write(i + "   ");
            }
            Console.WriteLine("\n");
        }


        // bai 3
        public void LongestIncreasing()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 4, 4, 6, 8, 9, 10 };
            int[] index = new int[list.Count]; // lưu vị trí đầu tiên của chuỗi con có độ dài dài nhất

            int res = 0, CountLength = 1, CountList = 0;
            // res (độ dài chuỗi lớn nhất : tạm thời)
            // CountLength ( lưu độ dài chuỗi lớn nhất : tăng dần)
            // CountList (lưu số chuỗi con tăng dần có độ dài lớn nhất)


            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > list[i - 1])
                    CountLength++;
                else
                    CountLength = 1;
                if (CountLength > res)
                {
                    res = CountLength;
                    index[0] = i - res + 1;
                    CountList = 1;
                }
                else if (CountLength == res)
                {
                    index[CountList] = i - res + 1;
                    CountList++;
                }
            }
            Console.WriteLine("Longest Increasing: ");
            for (int i = 0; i < CountList; i++)
            {
                for (int j = 0; j < CountLength; j++)
                {
                    Console.Write(list[index[i] + j] + "   ");
                }
                Console.WriteLine("\n");
            }

        }

        // bai 4
        public bool CheckPointIsInLine(Vector2 point, Vector2 a, Vector2 b)
        {

            Vector2 ab = new Vector2(b.X - a.X, b.Y - a.Y);
            Vector2 aPoint = new Vector2(point.X - a.X, point.Y - a.Y);

            double key = (ab.X * aPoint.Y) - (ab.Y * aPoint.X); // kiem tra 2 vector ab va aPoint co cùng phương khong
            if (key == 0)
                return true;
            else
                return false;
        }


        // bai 5
        public List<int> GetLish(int n)
        {

            // lưu các 
            List<int> values = new List<int>();
            for (int i = 1; i <= n / 2; i++)
            {
                values.Add(i);
            }

            // tao list 10 phan tu có 2 phần từ trong danh sách có thể có chung một giá trị
            List<int> result = new List<int>(values);
            result.AddRange(values);



            /*
             * Random 1 vi tri trong list đổi chỗ nó với phần tử thứ i
             */
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int random = rand.Next(i, n);
                int temp = result[i];
                result[i] = result[random];
                result[random] = temp;
            }

            return result;

        }

    }
    public class Vector2
    {
        public double X;
        public double Y;

        public Vector2(double a, double b)
        {
            X = a;
            Y = b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            exs test = new exs();
            test.find();
            test.delete(4);
            test.LongestIncreasing();
            Console.WriteLine(test.CheckPointIsInLine(new Vector2(1, 1), new Vector2(0, 2), new Vector2(2, 0)));
            Console.WriteLine(test.CheckPointIsInLine(new Vector2(0,0), new Vector2(0, 2), new Vector2(2, 0)));

             foreach(int i in test.GetLish(10))
            {
                Console.Write(i+ "   ");
            }




            Console.ReadKey();
        }
    }
}
