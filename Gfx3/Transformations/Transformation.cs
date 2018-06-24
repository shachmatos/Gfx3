using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gfx3.GfxObjects;

namespace Gfx3.Transformations
{
    abstract class Transformation
    {
        //Parent class
        public abstract Shape Transform(Shape shape, Point3D transformVector);

        public static double[,] MultiplyMatrix(double[,] A, double[,] B)
        {
            //This is a general matrix mult function
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);
            double[,] kHasil = new double[rA, cB];
            if (cA != rB)
            {
                Console.WriteLine(@"matrik can't be multiplied !!");
            }
            else
            {
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        double temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        kHasil[i, j] = temp;
                    }
                }
                return kHasil;
            }

            return null;
        }
    }
}
