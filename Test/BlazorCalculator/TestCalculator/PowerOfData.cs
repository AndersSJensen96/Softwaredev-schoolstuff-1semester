using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
	public class PowerOfData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2 };
            yield return new object[] { -4, -6 };
            yield return new object[] { 5, 2 };
            yield return new object[] { 10, 2 };
            yield return new object[] { 23425632, 34 };
            yield return new object[] { int.MinValue, int.MaxValue };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	}
}
