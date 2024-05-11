namespace _5by5_Biltiful.Utils
{
    internal class EditorArquivo
    {
        private readonly string CaminhoDiretorio;
        private readonly string CaminhoArquivo;

        protected EditorArquivo(string diretorio, string arquivo)
        {
            CaminhoDiretorio = diretorio;
            CaminhoArquivo = arquivo;

            if (!Directory.Exists(CaminhoDiretorio))
                Directory.CreateDirectory(CaminhoDiretorio);

            if (!File.Exists(CaminhoDiretorio + CaminhoArquivo))
            {
                var aux = File.Create(CaminhoDiretorio + CaminhoArquivo);
                aux.Close();
            }
        }

        protected List<string> Ler()
        {
            List<string> conteudo = new();
            
            foreach (string line in File.ReadAllLines(CaminhoDiretorio + CaminhoArquivo))
                conteudo.Add(line);

            return conteudo;
        }

        protected void Escrever(List<string> conteudo)
        {
            File.WriteAllLines(CaminhoDiretorio + CaminhoArquivo, conteudo);
        }
    }
}