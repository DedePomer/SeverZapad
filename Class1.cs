using System;
using System.Collections.Generic;
using System.Text;

namespace Северо_запад
{
    class Class1
    {
        public  int[,] Severo_Zapad(int [] VectorM, int[] VectorN, int M, int N, int[,] MatrixB) // Сам метод
        {
            for (int i = 0; i < M; i++) 
            {
                for (int j = 0; j < N; j++)
                {
                    if (VectorM[i] == VectorN[j] && VectorM[i] != 0 && VectorN[j] != 0)
                    {
                        MatrixB[i, j] = VectorM[i];
                        VectorM[i] = 0;
                        VectorN[j] = 0;
                    }
                    else if (VectorM[i] < VectorN[j] && VectorM[i] != 0 && VectorN[j] != 0)
                    {
                        MatrixB[i, j] = VectorM[i];
                        VectorN[j] -= VectorM[i];
                        VectorM[i] = 0;
                    }
                    else if (VectorM[i] > VectorN[j] && VectorM[i] != 0 && VectorN[j] != 0)
                    {
                        MatrixB[i, j] = VectorN[j];
                        VectorM[i] -= VectorN[j];
                        VectorN[j] = 0;
                    }
                }
            }
            return MatrixB;
        }
    }
}
