using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public struct Coordinate3d
    {
        public double X, Y, Z;
        public Coordinate3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    public struct Speed3d
    {
        public double Vx, Vy, Vz;
        public Speed3d(double vx, double vy, double vz)
        {
            Vx = vx;
            Vy = vy;
            Vz = vz;
        }
    }
    public class Body
    {
        public Vector<double> SpeedVector;
        public Vector<double> PositionVector;
        public double Mass;
        public string Name;
        public Body(Speed3d spd, Coordinate3d crd, double m, string s)
        {
            SpeedVector = Vector<double>.Build.Dense(new double[] { spd.Vx, spd.Vy, spd.Vz });
            PositionVector = Vector<double>.Build.Dense(new double[] { crd.X, crd.Y, crd.Z });
            Mass = m;
            Name = s;
        }
    }

}
