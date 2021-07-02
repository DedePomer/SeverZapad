using System;
using System.IO;
using System.Diagnostics;

namespace Северо_запад
{
    public class Program
    {
        public  int [] ZapolnVectora(int [] vector, string s)
        {
            string[] Smas = s.Split(' ');
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = Convert.ToInt32(Smas[i]);
            }
            return vector;
        }
        static void InfoVectora(int[] vector)// метод выводящий отладочные данные
        {
            Debug.WriteLine("Вектор "+ vector);
            foreach (var n in vector)
            {
                Debug.WriteLine(n);
            }
        }
        public  void Main(string[] args)
        {
            string path = "Входные данные.txt";
            string[] Data = File.ReadAllLines(path);//Передача данных из файла в массив
            int M, N;
            M = Data.Length - 2;
            string[] Nlenght = Data[2].Split(' ');
            N = Nlenght.Length;
            Debug.WriteLine("Значение N = "+N+ " Значение M = "+M);
            int[] VectorN = new int[N];
            int[] VectorM = new int[M];

            VectorN=ZapolnVectora(VectorN, Data[0]);//Заполнение векторов
            VectorM=ZapolnVectora(VectorM, Data[1]);
            InfoVectora(VectorN);
            InfoVectora(VectorM);

            int[,] MatrixA = new int[M, N];
            int[,] MatrixB = new int[M, N];
            for (int i = 0; i < M; i++)// Заполнение матрицы
            {
                Nlenght = Data[i + 2].Split(' ');
                for (int j = 0; j < N; j++)
                {
                    MatrixA[i, j] = Convert.ToInt32(Nlenght[j]);
                }
            }

            Class1 SZ = new Class1();
            MatrixB=SZ.Severo_Zapad(VectorM, VectorN,M,N, MatrixB);

            path = "Ответ.csv";
            int F = 0;
            for (int i = 0; i < M; i++) // Подсчёт F
            {
                for (int j = 0; j < N; j++)
                {
                    if (MatrixB[i,j]!=0)
                    {
                        F = F + MatrixB[i, j] * MatrixA[i, j];
                    }                
                }
            }
            string s = "F = "+F ;
            Debug.WriteLine(s);
            File.WriteAllText(path, s);
          
            }
    }
}
