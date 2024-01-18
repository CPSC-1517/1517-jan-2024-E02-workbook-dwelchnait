using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        //static classes are NOT instantiated by the outside user (developer/code)
        //static class items are referenced using: classname.xxxx
        //methods within this class have the keyword static in their signature
        //static class are shared between all outside users at the same time
        //DO NOT consider saving data within a static class BECAUSE you cannot be
        //  certain it (data) will be there when you use the class again
        //consider placing Generic re-usable methods within a static class

        //public static bool IsPositive(double value)
        //{
        //    //a structure method (applies to loops, etc) will have a single entry point
        //    //  and a single exit point
        //    //in this course you WILL AVOID where possible multiple returns from a method
        //    //in this course you WILL AVOID using a break command to exit a loop structure or
        //    //      if structure

        //    bool valid = true;
        //    if (value < 0.0)
        //    {
        //        valid = false;
        //    }
        //    return valid;
        //}
        public static bool IsPositive(double value) => value < 0.0;

        //overloaded methods
        //an overloaded methods has the same methodname but a different list of parameters
        public static bool IsPositive(int value) => value < 0.0;
        public static bool IsPositive(decimal value) => value < 0.0m;

    }
}
