using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace NumericalMethods
{
    class RungeKutta
    {
        public double Step;
        public int CurrentStep;
        public Vector<double> SystemImpulseVector;
        public Vector<double> SystemCoordinatesVector;
        public Vector<double> k1Impulse, k2Impulse, k3Impulse, k4Impulse;
        public Vector<double> k1Coordinates, k2Coordinates, k3Coordinates, k4Coordinates;
        public RungeKutta(double step = 1)
        {
            Step = step;
            CurrentStep = 0;
            SystemImpulseVector = Vector<double>.Build.Dense(18);
            SystemCoordinatesVector = Vector<double>.Build.Dense(18);
            k1Impulse = Vector<double>.Build.Dense(18);
            k2Impulse = Vector<double>.Build.Dense(18);
            k3Impulse = Vector<double>.Build.Dense(18);
            k4Impulse = Vector<double>.Build.Dense(18);

            k1Coordinates = Vector<double>.Build.Dense(18);
            k2Coordinates = Vector<double>.Build.Dense(18);
            k3Coordinates = Vector<double>.Build.Dense(18);
            k4Coordinates = Vector<double>.Build.Dense(18);
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
            var SystemImpulseTmpVector = SystemImpulseVector.Clone();
            k1Impulse = Derivatives.ImpulseDerivativeAt(SystemCoordinatesVector);
            k1Coordinates = Derivatives.CoordinatesDerivativeAt(SystemImpulseVector);

            k2Impulse = Derivatives.ImpulseDerivativeAt(SystemCoordinatesVector + Step / 2 * k1Coordinates);
            k2Coordinates = Derivatives.CoordinatesDerivativeAt(SystemImpulseVector + Step / 2 * k1Impulse);

            k3Impulse = Derivatives.ImpulseDerivativeAt(SystemCoordinatesVector + Step / 2 * k2Coordinates);
            k3Coordinates = Derivatives.CoordinatesDerivativeAt(SystemImpulseVector + Step / 2 * k2Impulse);

            k4Impulse = Derivatives.ImpulseDerivativeAt(SystemCoordinatesVector + Step * k3Coordinates);
            k4Coordinates = Derivatives.CoordinatesDerivativeAt(SystemImpulseVector + Step * k3Impulse);

            SystemImpulseVector += Step / 6 * (k1Impulse + 2 * k2Impulse + 2 * k3Impulse + k4Impulse);
            SystemCoordinatesVector += Step / 6 * (k1Coordinates + 2 * k2Coordinates + 2 * k3Coordinates + k4Coordinates);
        }
    }
}