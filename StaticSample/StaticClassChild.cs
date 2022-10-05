namespace StaticSample
{
    public class StaticClassChild : StaticClass
    {
        public override int GetCounter()
        {
            return _counter * 2;
        }
    }
}
