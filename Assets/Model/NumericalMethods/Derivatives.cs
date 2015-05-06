using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace NumericalMethods
{
    public static class Derivatives
    {
        public static Vector<double> CoordinatesDerivativeAt(Vector<double> SystemImpulseVector)
        {
            var result = Vector<double>.Build.Dense(SystemImpulseVector.Count);
            for (int i = 0; i < SystemImpulseVector.Count / 3; i++)
            {
                result[3 * i] = SystemImpulseVector[3 * i] / InitialConditions.Bodies[i].Mass;
                result[3 * i + 1] = SystemImpulseVector[3 * i + 1] / InitialConditions.Bodies[i].Mass;
                result[3 * i + 2] = SystemImpulseVector[3 * i + 2] / InitialConditions.Bodies[i].Mass;
            }
            return result;
        }

        public static Vector<double> ImpulseDerivativeAt(Vector<double> SystemCoordinatesVector)
        {
            var result = Vector<double>.Build.Dense(SystemCoordinatesVector.Count);
            for (int i = 0; i < SystemCoordinatesVector.Count / 3; i++)
            {
                for (int j = 0; j < SystemCoordinatesVector.Count / 3; j++)
                {
                    if (j != i)
                    {
                        var Rij = (SystemCoordinatesVector[3 * i] - SystemCoordinatesVector[3 * j]) * (SystemCoordinatesVector[3 * i] - SystemCoordinatesVector[3 * j]) +
                            (SystemCoordinatesVector[3 * i + 1] - SystemCoordinatesVector[3 * j + 1]) * (SystemCoordinatesVector[3 * i + 1] - SystemCoordinatesVector[3 * j + 1]) +
                            (SystemCoordinatesVector[3 * i + 2] - SystemCoordinatesVector[3 * j + 2]) * (SystemCoordinatesVector[3 * i + 2] - SystemCoordinatesVector[3 * j + 2]);

                        result[3 * i] -= (SystemCoordinatesVector[3 * i] - SystemCoordinatesVector[3 * j]) *
                                             InitialConditions.Bodies[i].Mass * InitialConditions.Bodies[j].Mass / Math.Pow(Rij, 1.5);

                        result[3 * i + 1] -= (SystemCoordinatesVector[3 * i + 1] - SystemCoordinatesVector[3 * j + 1]) *
                                             InitialConditions.Bodies[i].Mass * InitialConditions.Bodies[j].Mass / Math.Pow(Rij, 1.5);

                        result[3 * i + 2] -= (SystemCoordinatesVector[3 * i + 2] - SystemCoordinatesVector[3 * j + 2]) *
                                             InitialConditions.Bodies[i].Mass * InitialConditions.Bodies[j].Mass / Math.Pow(Rij, 1.5);
                    }
                }
            }
            return result * InitialConditions.G;
        }
    }
}