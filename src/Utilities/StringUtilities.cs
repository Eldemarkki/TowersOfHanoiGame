namespace TowerOfHanoi
{
    public static class StringUtilities
    {
        public static string ReplaceUntilDifferentCharacter(string text, char charToReplace, char replaceWith)
        {
            var result = text.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == charToReplace)
                {
                    result[i] = replaceWith;
                }
                else
                {
                    break;
                }
            }

            return new string(result);
        }
    }
}
