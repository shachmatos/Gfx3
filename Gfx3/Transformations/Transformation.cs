using Gfx3.GfxObjects;
using System;

/**
 * Made By:
 *  Yftah Livny - 066633744
 *  Edan Hauon - 305249187
 */

namespace Gfx3.Transformations
{
    abstract class Transformation
    {
        /// <summary>
        /// Perform an abstract transformation
        /// </summary>
        /// <param name="shape">Shape to transform</param>
        /// <param name="transformVector">transform vector</param>
        /// <returns>transformmed shape</returns>
        public abstract Shape Transform(Shape shape, Point3D transformVector);

        /// <summary>
        /// Perform a transformation around an alternative center (such as scene center rather than object center)
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="transformVector"></param>
        /// <param name="transformCenter"></param>
        /// <returns></returns>
        public abstract Shape Transform(Shape shape, Point3D transformVector, Point3D transformCenter);


        /// <summary>
        /// General matrix multiplication method
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double[,] MultiplyMatrix(double[,] A, double[,] B)
        {
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
