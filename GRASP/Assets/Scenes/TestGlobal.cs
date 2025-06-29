public class Test
{
    public string Name;
}

namespace Scenes
{
    public class Test
    {
        public int Name;
    }

    class Main
    {
        public Main()
        {
            global::Test test = new global::Test();
           test.Name = "10";
        }
    }
}
