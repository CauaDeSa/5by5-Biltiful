namespace _5by5_Biltiful.Utils
{
    public static class Formato
    {
        public static string LimparFormatacao(string data)
        {
            return data.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");
        }

        public static DateOnly ConverterParaData(string data)
        {
            return DateOnly.ParseExact(data, "ddMMyyyy", null);
        }
    }
}