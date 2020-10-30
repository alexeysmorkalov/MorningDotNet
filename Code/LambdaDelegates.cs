using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class LambdaDelegates
    {
        public Func<int, int, int> Sum = (x, y) => x + y;
    }
}
