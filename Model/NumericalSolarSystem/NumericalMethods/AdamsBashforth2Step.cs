using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace NumericalMethods
{
    class AdamsBashforth2Step
    {
        public double Step;
        public int CurrentStep;
        public Vector<double> SystemImpulseVector;
        public Vector<double> SystemCoordinatesVector;
        public Vector<double> SystemImpulsePrevVector;
        public Vector<double> SystemCoordinatesPrevVector;
        public AdamsBashforth2Step(double step = 1)
        {
            Step = step;
            CurrentStep = 0;
            SystemImpulseVector = Vector<double>.Build.Dense(18);
            SystemCoordinatesVector = Vector<double>.Build.Dense(18);

            SystemImpulsePrevVector = Vector<double>.Build.Dense(18);
            SystemCoordinatesPrevVector = Vector<double>.Build.Dense(18);
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
            if (CurrentStep == 0)
            {
                CurrentStep++;
                SystemImpulsePrevVector = SystemImpulseVector.Clone();
                SystemCoordinatesPrevVector = SystemCoordinatesVector.Clone();

                SystemImpulseVector += Step * Derivatives.ImpulseDerivativeAt(SystemCoordinatesPrevVector);
                SystemCoordinatesVector += Step * Derivatives.CoordinatesDerivativeAt(SystemImpulsePrevVector);
            }
            else
            {
                CurrentStep++;
                var SystemImpulseNextVector = SystemImpulseVector.Clone();
                var SystemCoordinatesNextVector = SystemCoordinatesVector.Clone();

                SystemImpulseNextVector += 1.5 * Step * Derivatives.ImpulseDerivativeAt(SystemCoordinatesVector)
                                         - 0.5 * Step * Derivatives.ImpulseDerivativeAt(SystemCoordinatesPrevVector);
                SystemCoordinatesNextVector += 1.5 * Step * Derivatives.CoordinatesDerivativeAt(SystemImpulseVector)
                                             - 0.5 * Step * Derivatives.CoordinatesDerivativeAt(SystemImpulsePrevVector);

                SystemImpulsePrevVector = SystemImpulseVector;
                SystemCoordinatesPrevVector = SystemCoordinatesVector;

                SystemImpulseVector = SystemImpulseNextVector;
                SystemCoordinatesVector = SystemCoordinatesNextVector;
            }
        }
    }
}