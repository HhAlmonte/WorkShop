namespace StaticSample
{
    public class StaticClass
    {
        protected static int _counter;
        private int normalInt;

        public StaticClass()
        {
            normalInt = _counter;
            UpdateCounter();
        }

        public virtual int GetCounter()
        {
            return _counter;
        }

        public int GetNormalInt()
        {
            return normalInt;
        }

        private void UpdateCounter()
        {
            _counter++;
        }
    }
}
