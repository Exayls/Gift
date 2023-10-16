namespace TestGift
{
    public class TestHelper
    {
        public static string Replace(string s, string replace, int index)
        {
            return s.Remove(index, replace.Length).Insert(index, replace);
        }
    }
}
