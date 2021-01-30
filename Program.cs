using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        static string encode(string key,string mes) {
            while (mes.Length % key.Length != 0)
                mes += " ";
            char [,] mat=new char[key.Length,mes.Length/key.Length];
            int []arr=new int[key.Length];
            string sorted_key=sort_string(key);
            char []s_k = sorted_key.ToArray();
            char[] k = key.ToArray();
            string res="";
            int K=0;
            foreach(char i in k){
                int j=0;
                foreach (char r in s_k)
                {
                    if (i == r)
                    {
                        arr[K] = j;
                        s_k[j] = ' ';
                        k[K] = ' ';
                    }
                    j++;
                }
                K++;
            }
            int q = 0;
            K = 0;
            foreach (char i in mes) {
                if (q == arr.Length)
                {
                    q = 0;
                    K++;
                }
                mat[arr[q], K] = i;
                q++;
            }
            for (int i = 0; i < mat.GetLength(1); i++)
                for (int r = 0; r < mat.GetLength(0); r++)
                    res += mat[r, i];
                    return res;
        }
        static string decode(string key,string mes) {
            while (mes.Length % key.Length != 0)
                mes += " ";
            char[,] mat = new char[key.Length, mes.Length / key.Length];
            int[] arr = new int[key.Length];
            string sorted_key = sort_string(key);
            char[] s_k = sorted_key.ToArray();
            char[] k = key.ToArray();
            string res = "";
            int K = 0;
            foreach (char i in k)
            {
                int j = 0;
                foreach (char r in s_k)
                {
                    if (i == r)
                    {
                        arr[K] = j;
                        s_k[j] = ' ';
                        k[K] = ' ';
                    }
                    j++;
                }
                K++;
            }
            int q = 0;
            K = 0;
            foreach (char i in mes)
            {
                if (q == arr.Length)
                {
                    q = 0;
                    K++;
                }
                mat[q, K] = i;
                q++;
            }
            for (int i = 0; i < mat.GetLength(1);i++ )
                foreach(int r in arr)
                    res+=mat[r,i];
                return res;
        }
        static string sort_string(string str) {
            char[] chs = str.ToArray();
            Array.Sort(chs);
            return new string(chs);
        }
        static void run()
        {
            int i = 0;
            string key = "";
            string message = "";
            while (true)
            {
                Console.WriteLine("\n1 = encode\n2 = decode\n3 = exit");
                i = int.Parse(Console.ReadLine());
                if (i == 3)
                    break;
                Console.WriteLine("\nEnter key");
                key = Console.ReadLine();
                Console.WriteLine("Enter message");
                message = Console.ReadLine();
                switch (i)
                {
                    case 1:
                        Console.WriteLine(encode(key, message));
                        break;
                    case 2:
                        Console.WriteLine(decode(key, message));
                        break;
                }
            }
            Console.WriteLine("Good Bye");
        }
        static void Main(string[] args)
        {
            run();
            Console.ReadLine();
        }
    }
}
