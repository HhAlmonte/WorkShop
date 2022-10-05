namespace Day3_HW
{
    public class Square : Figures
    {
        private readonly decimal _n;

        public Square(decimal n)
        {
            _n = n;
        }

        public override decimal area()
        {
            return _n * _n;
        }

        public override decimal perimeter()
        {
            return _n * 4;
        }
    }
}
