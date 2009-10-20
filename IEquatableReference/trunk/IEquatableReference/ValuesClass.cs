using System;
using System.Globalization;

namespace IEquatableReference
{
    public class ValuesClass : IEquatable<ValuesClass>
    {
        public int First { get; set; }
        public double Second { get; set; }

        #region IEquatable<ValuesClass> Members

        public bool Equals(ValuesClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            return (this.First.Equals(other.First))
                && (this.Second.Equals(other.Second));
        }

        #endregion

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ValuesClass);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (-1521134295 * this.First)
                    + this.Second.GetHashCode();
            }
        }

        public override string ToString()
        {
            return String.Format("{{ First = {0}, Second = {1} }}"
                , this.First.ToString(CultureInfo.InvariantCulture)
                , this.Second.ToString(CultureInfo.InvariantCulture)
                );
        }

        public static bool operator ==(ValuesClass leftOperand, ValuesClass rightOperand)
        {
            if (ReferenceEquals(null, leftOperand)) return ReferenceEquals(null, rightOperand);
            return leftOperand.Equals(rightOperand);
        }

        public static bool operator !=(ValuesClass leftOperand, ValuesClass rightOperand)
        {
            return !(leftOperand == rightOperand);
        }
    }
}

//    public bool Equals(ValuesClass other)
//    {
//        if (ReferenceEquals(null, other)) return false;
//        // The Refactor plugin suggests the following line, but it is optional:
//        //    if (ReferenceEquals(this, other)) return true;
//        return (this.First.Equals(other.First))
//            && (this.Second.Equals(other.Second));
//    }

//    public override int GetHashCode()
//    {
//        // Avoids arithmetic overflows
//        unchecked
//        {
//            // Int32 doesn't need .GetHashCode()
//            return (-1521134295 * this.First)
//                + this.Second.GetHashCode();
//        }

//           // C# 3.0 anon types are implemented as follows:
//           //int num = -1134271262;
//           //num = (-1521134295 * num) + this.First.GetHashCode();
//           //return ((-1521134295 * num) + this.Second.GetHashCode());


//        // The solution with least collision probability would be:
//        //     return ((this.First << 16) | (this.First >> 16)) ^ this.Second.GetHashCode();
//        // this code only isn't cleaner because C# lacks a bitwise rotate operator

//        // Generalized as:
//        //     return GetHashCode(new object[] { this.First, this.Second });
//    }

//    // where:
//    //const int NumberOfBits = 32;
//    //Int32 GetHashCode(object[] properties)
//    //{
//    //    var offset = NumberOfBits / properties.Length;
//    //    return properties
//    //        .Select((property, index) => new { hash = property.GetHashCode(), index })
//    //        .Aggregate(0, (hash, item) => hash ^= (item.hash << (offset * item.index)) | (item.hash << (NumberOfBits - (offset * item.index))));
//    //}

//    public static bool operator ==(ValuesClass valuesClassA, ValuesClass valuesClassB)
//    {
//        if (ReferenceEquals(null, valuesClassA)) return ReferenceEquals(null, valuesClassB);
//        return valuesClassA.Equals(valuesClassB);

//        // Since double.NaN.Equals(double.NaN) is true
//        // and   double.NaN   ==   double.NaN  is false
//        // we could also implement this as:
//        //if (ReferenceEquals(null, other)) return false;
//        //return (this.First.Equals(other.First))
//        //    && (this.Second == other.Second);
//        // Where it differs from the Equals implementation in the last line
//    }