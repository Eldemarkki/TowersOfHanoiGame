using System.Text;

namespace TowerOfHanoi.Utilities
{
    public static class Utilities
    {
        public static string Repeat(this string text, int count)
        {
            StringBuilder sb = new StringBuilder(text.Length * count);
            for (int i = 0; i < count; i++)
            {
                sb.Append(text);
            }

            return sb.ToString();
        }
    }
}
