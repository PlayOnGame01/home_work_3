using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многомерные_массивы_homework_03._02._2023
{
    static class MatrixExt
    {
        public static int RowsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }
        public static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
    internal class Program
    {
        static void Multiply(int[,] m)
        {
            int num = 0;
            Console.Write("Enter number: ");
            string n = Console.ReadLine();
            num = Convert.ToInt32(n);
            Console.WriteLine();

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    m[i, j] *= num;
                    Console.Write($"{m[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        static void Addition(int[,] m)
        {
            int[,] mas = new int[3, 3];
            Random rand = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = rand.Next(1, 9);
                    Console.Write($"{mas[i, j]}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    m[i, j] += mas[i, j];
                    Console.Write($"{m[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        static int Product(int[,] m)
        {
            int[,] mass = new int[3, 3];
            Random random = new Random();
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = random.Next(1, 9);
                    Console.Write($"{mass[i, j]}  ");
                }
                Console.WriteLine();
            }
            var matrixC = new int[m.RowsCount(), mass.ColumnsCount()];

            Console.WriteLine();
            for (var i = 0; i < m.RowsCount(); i++)
            {
                for (var j = 0; j < mass.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;
                    for (var k = 0; k < m.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += m[i, k] * mass[k, j];
                    }
                }
            }
            for (int i = 0; i < matrixC.GetLength(0); i++)
            {
                for (int j = 0; j < matrixC.GetLength(1); j++)
                {
                    Console.Write($"{matrixC[i, j]}  ");
                }
                Console.WriteLine();
            }
            return 0;
        }
        public class CaesarCipher
        {
            const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            private string CodeEncode(string text, int k)
            {
                var fullAlfabet = alfabet + alfabet.ToLower();
                var letterQty = fullAlfabet.Length;
                var retVal = "";
                for (int i = 0; i < text.Length; i++)
                {
                    var c = text[i];
                    var index = fullAlfabet.IndexOf(c);
                    if (index < 0)
                    {
                        retVal += c.ToString();
                    }
                    else
                    {
                        var codeIndex = (letterQty + index + k) % letterQty;
                        retVal += fullAlfabet[codeIndex];
                    }
                }
                return retVal;
            }
            //шифрование текста
            public string Encrypt(string plainMessage, int key)
                => CodeEncode(plainMessage, key);
            //дешифрование текста
            public string Decrypt(string encryptedMessage, int key)
                => CodeEncode(encryptedMessage, -key);
        }
        static void Main(string[] args)
        {
            #region ex1
            //    int[] mass_A = new int[5];
            //    string str = null;
            //    Console.WriteLine("Enter 5 number:");
            //    for (int i = 0; i < mass_A.Length; i++)
            //    {
            //        str = Console.ReadLine();
            //        mass_A[i] = Convert.ToInt32(str);
            //    }
            //    Console.WriteLine();
            //    foreach (int i in mass_A) { Console.Write($"{i}  "); }
            //    int min_A = 0, max_A = 0, sum_A = 0, proizvod_A = 0, sum_chet_A = 0;
            //    min_A = mass_A[0];
            //    for (int i = 0; i < mass_A.Length; i++)
            //    {
            //        if (min_A > mass_A[i]) { min_A = mass_A[i]; }
            //        if (max_A < mass_A[i]) { max_A = mass_A[i]; }
            //        sum_A += mass_A[i];
            //        if (proizvod_A == 0) { proizvod_A = mass_A[i]; }
            //        proizvod_A *= mass_A[i];
            //        if (mass_A[i] % 2 == 0) { sum_chet_A += mass_A[i]; }
            //    }
            //    Console.WriteLine($"\nMin = {min_A}\nMax = {max_A}\nSum = {sum_A}\nDerivative = {proizvod_A}\nSum chet = {sum_chet_A}");
            //    Console.WriteLine("\n\n");
            //    int[,] mas_B = new int[3, 4];
            //    Random rand = new Random();
            //    for (int i = 0; i < mas_B.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < mas_B.GetLength(1); j++)
            //        {
            //            mas_B[i, j] = rand.Next(0, 99);
            //            Console.Write($"{mas_B[i, j]}  ");
            //        }
            //        Console.WriteLine();
            //    }
            //    int min_B = 0, max_B = 0, sum_B = 0, proizvod_B = 0, sum_nechet_B = 0;
            //    min_B = mas_B[0, 0];
            //    for (int i = 0; i < mas_B.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < mas_B.GetLength(1); j++)
            //        {
            //            if (min_B > mas_B[i, j]) { min_B = mas_B[i, j]; }
            //            if (max_B < mas_B[i, j]) { max_B = mas_B[i, j]; }
            //            sum_B += mas_B[i, j];
            //            if (proizvod_B == 0) { proizvod_B = mas_B[i, j]; }
            //            proizvod_B *= mas_B[i, j];
            //            if (mas_B[i, j] % 2 != 0) { sum_nechet_B += mas_B[i, j]; }
            //        }
            //    }
            //    Console.WriteLine($"\nMin = {min_B}\nMax = {max_B}\nSum = {sum_B}\nDerivative = {proizvod_B}\nSum chet = {sum_nechet_B}");
            #endregion

            #region ex2
            //int[,] mass = new int[5, 5];
            //Random random = new Random();
            //int min = mass[0, 0], max = 0, min_i = 0, min_j = 0, max_i = 0, max_j = 0;
            //for (int i = 0; i < mass.GetLength(0); i++)
            //{
            //    for (int j = 0; j < mass.GetLength(1); j++)
            //    {
            //        mass[i, j] = random.Next(-100, 100);
            //        Console.Write($"{mass[i, j]}  ");
            //        if (min > mass[i, j]) { min = mass[i, j]; min_i = i; min_j = j; }
            //        if (max < mass[i, j]) { max = mass[i, j]; max_i = i; max_j = j; }
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine($"\nMin = {min}\nMax = {max}");
            //int sum = 0;
            //for (int i = min_i; i < max_i; i++)
            //{
            //    for (int j = min_j; j < max_j; j++)
            //    {
            //        sum += mass[i, j];
            //    }
            //}
            //Console.WriteLine($"\nSum = {sum}");
            //#endregion

            #region ex3
            //var shifer = new CaesarCipher();
            //Console.Write("Введите текст: ");
            //var text = Console.ReadLine();
            //Console.Write("Введите ключ: ");
            //var secretKey = Convert.ToInt32(Console.ReadLine());
            //var encryptedText = shifer.Encrypt(text, secretKey);
            //Console.WriteLine("Шифруем: {0}", encryptedText);
            //Console.WriteLine("Вскрываем: {0}", shifer.Decrypt(encryptedText, secretKey));
            //Console.ReadLine();
            #endregion

            #region ex4 
            int[,] mat = new int[3, 3];
            Random random = new Random();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = random.Next(1, 9);
                    Console.Write($"{mat[i, j]}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nChoose option:\n1) Multiply martica by a number\n2) Matrix addition\n3) Product of matrices\n");
            string ch = Console.ReadLine();
            Console.WriteLine();
            int choose = Convert.ToInt32(ch);
            switch (choose)
            {
                case 1:
                    Multiply(mat);
                    break;
                case 2:
                    Addition(mat);
                    break;
                case 3:
                    Product(mat);
                    break;
            }
            #endregion
        }
    }
}