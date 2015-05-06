using MathNet.Numerics.LinearAlgebra;
using NumericalMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storages
{
    class VectorMegaStorage
    {
        public Vector<double>[] EulerArray;
        public Vector<double>[] EulerSemiImplicitArray;
      //public Vector<double>[] EulerImplicitArray;
        private double timeStep;
        private int stepNumber;
        public VectorMegaStorage(double step, int n)
        {
            EulerArray = new double[n];
            EulerSemiImplicitArray = new double[n];
        //  EulerImplicitArray = new double[n];
            stepNumber = n;
        }
        public void Initialise()
        {
            var method1 = new EulerForward(timeStep);
            var method2 = new EulerSemiImplicit(timeStep);
            for (int i = 0; i < stepNumber; i++)
            {
                EulerArray[i] = method1.SystemCoordinatesVector;
                EulerSemiImplicitArray[i] = method2.SystemCoordinatesVector;
                method1.NextStep();
                method2.NextStep();
            }
        }
        public Vector<float> GetCoordinatesAtTime(float time, int methodNumber)
        {
            var result=Vector<float>.Build.Dense(EulerArray[0].Count);
            if(time<0||time>stepNumber*timeStep)
                throw new IndexOutOfRangeException("This time moment is not stored. Make the UI code not accept such time");
            else
            {
                if (methodNumber == 0)
                {
                    for(int i=0;i<EulerArray[0].Count;i++)
                    {
                        result[i]=Convert.ToSingle(EulerArray[Convert.ToInt32(time/timeStep)][i]);
                    }
                }
                else if (methodNumber == 1)
                {
                    for (int i = 0; i < EulerSemiImplicitArray[0].Count; i++)
                    {
                        result[i] = Convert.ToSingle(EulerSemiImplicitArray[Convert.ToInt32(time / timeStep)][i]);
                    }
                }
            }
            return result;
        }
    }
}
