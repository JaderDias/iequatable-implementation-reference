using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return this.First.GetHashCode() ^ this.Second.GetHashCode();
        }

        public static bool operator ==(ValuesClass valuesClassA, ValuesClass valuesClassB)
        {
            if (ReferenceEquals(null, valuesClassA)) return ReferenceEquals(null, valuesClassB);
            return valuesClassA.Equals(valuesClassB);
        }

        public static bool operator !=(ValuesClass valuesClassA, ValuesClass valuesClassB)
        {
            if (ReferenceEquals(null, valuesClassA)) return !ReferenceEquals(null, valuesClassB);
            return !valuesClassA.Equals(valuesClassB);
        }
    }
}
