namespace HyperCasual.Extensions
{
    /// <summary>
    /// Extends the string class with common char-specific operations.
    /// </summary>
    public static class StringCharExtensions
    {
        public static string ReplaceAt(this string input, int i, char ch)
        {
            if (input == null || i >= input.Length)
                return input;

            var ch_array = input.ToCharArray();
            ch_array[i] = ch;
            return new string(ch_array);
        }

        public static int Count(this string input, char ch)
        {
            var count = 0;
            for (var i = 0; i < input.Length; ++i)
                count += input[i] == ch ? 1 : 0;

            return count;
        }

        public static string RemoveChar(this string input, char ch)
        {
            var count = input.Count(ch);
            var ch_array = new char[input.Length - count];

            var ch_index = 0;
            for (var i = 0; i < input.Length; ++i)
            {
                var input_ch = input[i];
                if (input_ch == ch)
                    continue;

                ch_array[ch_index] = input_ch;
                ++ch_index;
            }

            return new string(ch_array);
        }
    }
}
