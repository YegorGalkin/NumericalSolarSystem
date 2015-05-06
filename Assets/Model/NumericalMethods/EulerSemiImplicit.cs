using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public class EulerSemiImplicit
    {
        public double Step;
        public int CurrentStep;
        public Vector<double> SystemImpulseVector;
        public Vector<double> SystemCoordinatesVector;
        public EulerSemiImplicit(double step = 1)
        {
            Step = step;
            CurrentStep = 0;
            SystemImpulseVector = Vector<double>.Build.Dense(18);
            SystemCoordinatesVector = Vector<double>.Build.Dense(18);
            for (int i = 0; i < InitialConditions.Bodies.Length; i++)
            {
                SystemImpulseVector[3 * i] = InitialConditions.Bodies[i].SpeedVector[0] * InitialConditions.Bodies[i].Mass;
                SystemImpulseVector[3 * i + 1] = InitialConditions.Bodies[i].SpeedVector[1] * InitialConditions.Bodies[i].Mass;
                SystemImpulseVector[3 * i + 2] = InitialConditions.Bodies[i].SpeedVector[2] * InitialConditions.Bodies[i].Mass;
                SystemCoordinatesVector[3 * i] = InitialConditions.Bodies[i].PositionVector[0];
                SystemCoordinatesVector[3 * i + 1] = InitialConditions.Bodies[i].PositionVector[1];
                SystemCoordinatesVector[3 * i + 2] = InitialConditions.Bodies[i].PositionVector[2];
            }
        }
        public void NextStep()
        {
            CurrentStep++;
            SystemImpulseVector += Step * Derivatives.ImpulseDerivativeAt(SystemCoordinatesVector);
            SystemCoordinatesVector += Step * Derivatives.CoordinatesDerivativeAt(SystemImpulseVector);
        }
    }
}

