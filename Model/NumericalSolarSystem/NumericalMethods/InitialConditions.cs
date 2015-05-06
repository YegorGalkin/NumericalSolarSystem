using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public static class InitialConditions
    {
        public static readonly double G = 0.000295912208286;
        public static readonly DateTime Time = new DateTime(1994, 9, 5);// 5'th september
        public static readonly Body[] Bodies ={
                                                new Body(new Speed3d(0,0,0),
                                                         new Coordinate3d(0,0,0),
                                                         1.00000597682,"Sun")
                                                ,
                                                new Body(new Speed3d(0.00565429,-0.00412490,-0.00190589),
                                                         new Coordinate3d(-3.5023653,-3.8169847,-1.5507963),
                                                         0.000954786104043,"Jupiter")
                                                ,   
                                                new Body(new Speed3d(0.00168318,0.00483525,0.00192462),
                                                         new Coordinate3d(9.0755314,-3.0458353,-1.6483708),
                                                         0.000285583733151,"Saturn")
                                                ,   
                                                new Body(new Speed3d(0.00354178,0.00137102,0.00055029),
                                                         new Coordinate3d(8.3101420,-16.2901086,-7.2521278),
                                                         0.0000437273164546,"Uranus")
                                                ,   
                                                new Body(new Speed3d(0.00288930,0.00114527,0.00039677),
                                                         new Coordinate3d(11.4707666,-25.7294829,-10.8169456),
                                                         0.0000517759138449,"Neptune")
                                                ,   
                                                new Body(new Speed3d(0.00276725,-0.00170702,-0.00136504),
                                                         new Coordinate3d(-15.5387357,-25.2225594,-3.1902382),
                                                         0.0000000076923077,"Pluto")
                                              };

    }
}
