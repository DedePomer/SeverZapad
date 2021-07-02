using System;
using System.IO;

namespace Северо_запад
{
    class Program
    {
        static void ZapolnVectora(int [] vector, string s)
        {
            string[] Smas = s.Split(' ');
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = Convert.ToInt32(Smas[i]);
            }
        }
        static void Main(string[] args)
        {
            string path = "Входные данные.txt";
            string[] Data = File.ReadAllLines(path);//Передача данных из файла в массив
            int M, N;
            M = Data.Length - 2;
            string[] Nlenght = Data[2].Split(' ');
            N = Nlenght.Length;
            int[] VectorN = new int[N];
            int[] VectorM = new int[M];

            ZapolnVectora(VectorN, Data[0]);//Заполнение векторов
            ZapolnVectora(VectorM, Data[1]);

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
            File.WriteAllText(path, s);
          
            }
    }
}
