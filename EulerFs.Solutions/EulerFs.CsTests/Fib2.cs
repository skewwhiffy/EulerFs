using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerFs.CsTests
{
    public class Fib2
    {
        private readonly List<int> _itemCache = new List<int> {0, 1};

        public int this[int i]
        {
            get { return GetItem(i); }
        }
    }
}
