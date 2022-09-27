namespace UnitTestTraining
{
    public static class StringCalculator
    {
        public static int Add(string number)
        {
            if (string.IsNullOrEmpty(number)) return 0;

            List<string> stringList;

            if (number.StartsWith("//"))
            {
                //Delimiter
                string[] inputLines = number.Replace("//", "").Split('\n');

                string[] delimiters = inputLines[0].Replace("]", "").Split('[');

                stringList = inputLines[1].Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                //Delimiter
                char[] delimiter = { ',', '\n' };
                stringList = number.Split(delimiter).ToList();
            }

            if (stringList.Any(a => Convert.ToInt32(a) < 0))
            {
                string message = $"Negatives not allowed: {String.Join(", ", stringList.Where(a => Convert.ToInt32(a) < 0).Select(s => s))}";
                throw new ArgumentException(message);
            }

            stringList.RemoveAll(a => Convert.ToInt32(a) > 1000);

            return stringList.Select(s => Convert.ToInt32(s)).Sum(a => a);
        }
    }
}