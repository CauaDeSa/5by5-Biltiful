using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Entidades;
using _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro.Validacoes;
using _5by5_Biltiful.Utils;

namespace _5by5_Biltiful.Modulos.Cadastro.ClassesCadastro
{
    internal class ManipularMateriaPrima : EditorArquivo
    {
        public ManipularMateriaPrima(string diretorio, string arquivo) : base(diretorio, arquivo) { }

        public List<MateriaPrima> RecuperarArquivo()
        {
            List<MateriaPrima> materiasPrimas = new();

            foreach (string linha in Ler())
                materiasPrimas.Add(new MateriaPrima(linha));

            return materiasPrimas;
        }

        public void SalvarArquivo(List<MateriaPrima> materiasPrimas)
        {
            List<string> conteudo = new();

            foreach (MateriaPrima materiaPrima in materiasPrimas)
                conteudo.Add(materiaPrima.ToString());

            Escrever(conteudo);
        }

        public int LerId()
        {
            int id;
            Console.Write("Insira o ID: ");

            while (ValidarMateriaPrima.ID(id = Console.ReadLine()))
                Console.Write("ID inválido, tente novamente: ");

            return id;
        }   

        public string LerNome()
        {
            string nome;
            Console.Write("Insira o nome: ");

            while (ValidarMateriaPrima.Nome(nome = Console.ReadLine()))
                Console.Write("Nome inválido, tente novamente: ");

            return nome;
        }

        public char LerSituacao()
        {
            char situacao;
            Console.Write("Insira a situacao (A/I): ");

            while (!char.TryParse(Console.ReadLine(), out situacao) || (situacao != 'A' && situacao != 'I'))
                Console.Write("Situacao invalida, tente novamente: ");

            return situacao;
        }

        public void Cadastrar()
        {
            int id = 1;
            string nome;
            List<MateriaPrima> materiasPrimas = RecuperarArquivo();

            Console.WriteLine(">>> CADASTRO DE MATERIA PRIMA <<<");

            foreach (MateriaPrima materiaPrima in materiasPrimas)
                if (materiaPrima.Id > id)
                    id = materiaPrima.Id;

            nome = LerNome();

            materiasPrimas.Add(new MateriaPrima(id + 1, nome));
            SalvarArquivo(materiasPrimas);

            Console.WriteLine("Materia Prima cadastrada com sucesso!");
        }

        public void Editar()
        {
            List<MateriaPrima> materiasPrimas = RecuperarArquivo();
            MateriaPrima? materiaPrima;
            int id;
            int opcao;

            Console.WriteLine(">>> EDIÇÃO DE CLIENTE <<<");

            id = LerId();

            materiaPrima = materiasPrimas.Find(materia => materia.Id == id);

            if (materiaPrima == null)
            {
                Console.WriteLine("Materia Prima não encontrada");
                return;
            }

            Console.WriteLine($"Materia prima encontrada: \n{materiaPrima}\n\n");
            
            do
            {
                Console.WriteLine(@">>> Menu edicao <<<

                                    [ 1 ] Nome
                                    [ 2 ] Situacao
                                    [ 0 ] Voltar");

                opcao = IO.LerOpcao(4);

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        materiaPrima.Nome = LerNome().PadRight(50).Substring(0, 50);
                        break;
                    case 2:
                        materiaPrima.Situacao = LerSituacao();
                        break;
                }
            } while (opcao != 0);
            
            SalvarArquivo(materiasPrimas);
        }

        public MateriaPrima? BuscarPorId()
        {
            int id;

            Console.WriteLine(">>> BUSCA DE MATERIA PRIMA <<<");

            id = LerId();

            return RecuperarArquivo().Find(materia => materia.Id == id);
        }

        public void Localizar()
        {
            MateriaPrima? mPrima = BuscarPorId();

            if (mPrima == null)
            {
                Console.WriteLine("Materia prima não encontrada");
                return;
            }

            Console.WriteLine($"\n{mPrima}\n\n");
        }

        public void Imprimir()
        {
            List<MateriaPrima> materiasPrimas = RecuperarArquivo();

            Console.WriteLine(">>> LISTA DE MATERIAS PRIMAS <<<");

            foreach (MateriaPrima materiaPrima in materiasPrimas)
                Console.WriteLine(materiaPrima);
        }
    }
}