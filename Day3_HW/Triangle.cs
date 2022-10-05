namespace Day3_HW
{
    public class Triangle : Figures
    {
        private readonly decimal _b;
        private readonly decimal _h;

        public Triangle(decimal b, decimal h)
        {
            _b = b;
            _h = h;
        }

        public override decimal area()
        {
            return _b * _h / 2;
        }

        public override decimal perimeter()
        {
            return _b + 2 * _h;
        }
    }
}
