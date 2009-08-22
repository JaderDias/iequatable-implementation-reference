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
            return (this.First.Equals(other.First))
                && (this.Second.Equals(other.Second));
        }

        #endregion
    }
}
