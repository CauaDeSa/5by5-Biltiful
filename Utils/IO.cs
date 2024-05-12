namespace _5by5_Biltiful.Utils
{
    public static class IO
    {
        public static int LerOpcao(int max)
        {
            int opcao;
            Console.Write("\nOpcao: ");

            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > max)
                Console.Write("Opcao invalida, tente novamente: ");

            return opcao;
        }

        public static DateOnly LerData()
        {
            DateOnly data;
            Console.Write("Data: ");

            while (!DateOnly.TryParse(Console.ReadLine(), out data))
                Console.Write("Data invalida, tente novamente: ");

            return data;
        }
    }
}