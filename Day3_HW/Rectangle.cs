using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_HW
{
    public class Rectangle : Figures
    {
        private readonly decimal _b;
        private readonly decimal _h;
        public Rectangle(decimal h, decimal b)
        {
            _h = h;
            _b = b;
        }

        public Rectangle(decimal h, decimal b, decimal c, decimal a)
        {
            _h = h;
            _b = b;
        }

        public override decimal area()
        {
            return _b * _h;
        }

        public override decimal perimeter()
        {
            return 2 * (_b + _h);
        }
    }
}
