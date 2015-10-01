namespace CanvasPractice
{
    internal class Elissa
    {
        public class person
        {
            public person()
            {
                _madness = 10;
            }

            public int getMad()
            {
                return _madness++;
            }

            // private attributes
            private int _madness = 0;
        }
    }
}