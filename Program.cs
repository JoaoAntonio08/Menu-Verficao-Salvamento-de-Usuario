using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class Program
{
    // Declarando variáveis globais
    public static string strSenhaTentativa, nomeUsuario, resposta;
    public static int senha, SenhaTentativa, idade;
    public static string ultimaTelaVisitada;
    static void Main()
    {
        // Menu
        Console.Clear();
        System.Console.WriteLine("##### PARA INICIARMOS DIGITE SEU NOME #####");
        nomeUsuario = Console.ReadLine();
        // Verifica se o Nome contém apenas letras
        if (!ValidaNome(nomeUsuario))
        {
            System.Console.WriteLine("Nome Inválido, Digite apenas letras");
            Console.Clear();
            voltarMenu();
            resposta = Console.ReadLine();
        }
        do
        {
            voltarMenu();
            resposta = Console.ReadLine();

            if (resposta == "1")
            {
                Console.Clear();
                // Tela inicial
                ultimaTelaVisitada = "Tela 1";
                MostrarPrimeiraTela();
            }
            else if (resposta == "2")
            {
                Console.Clear();
                // Segunda Tela
                ultimaTelaVisitada = "Tela 2";
                MostrarSegundaTela();
            }
            else if (resposta == "3")
            {
                Console.Clear();
                // Terceira tela
                MostrarTerceiraTela();

            }
            else if (resposta != "4")
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Tela Inválida");
                System.Console.WriteLine("");
            }

            if (resposta != "4") // Caso tenha clicado algum número inválido temos a opção de voltar ao menu
            {
                System.Console.WriteLine("------------------------------------------------------------");
                System.Console.WriteLine("Pressione qualquer tecla par voltar ao menu");
                System.Console.WriteLine("------------------------------------------------------------");
                Console.ReadLine();
                Console.Clear();
            }


        } while (resposta != "4");
    }

    static void MostrarPrimeiraTela()
    {
        // Solicita ao usuário que digite sua senha
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("Agora crie um senha para você");
        System.Console.WriteLine("É importante lembrar que a senha deve conter apenas números e");
        System.Console.WriteLine("Deve conter entre 5 à 10 caracteres");
        System.Console.WriteLine("------------------------------------------------------------");
        strSenhaTentativa = Console.ReadLine();

        // Verifica se a senha contém apenas dígitos
        if (!ValidaSenha(strSenhaTentativa))
        {
            System.Console.WriteLine("Senha Inválida.");
            return;
        }
        // Aqui a variável strSenhaTentativa passa a ser somente senha, eu criei a strSenhaTentativa para poder se usada na função
        senha = int.Parse(strSenhaTentativa);

        bool senhaCorreta = false;
        // Loop para verificar a senha
        do
        {
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.WriteLine("Para finalizarmos confirme a senha");
            System.Console.WriteLine("------------------------------------------------------------");
            SenhaTentativa = int.Parse(Console.ReadLine());
            if (senha == SenhaTentativa)
            {
                senhaCorreta = true;
            }
            else
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Senha inválida. Digite novamente.");
                System.Console.WriteLine("");
            }
        } while (!senhaCorreta);

        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("Por fim escreva sua idade");
        System.Console.WriteLine("------------------------------------------------------------");
        idade = int.Parse(Console.ReadLine());

        // Salvar os dados registrados em um arquivo .txt criado na função SalvarUsuariosNoArquivo
        SalvarUsuarioNoArquivo(nomeUsuario, senha, idade);
        Console.Clear();
        // Chama tela final
        TelaFinal();

    }

    // Função Criada para Verificar se senha é composta por apenas números e com caracteres de 5 a 10 números
    public static bool ValidaSenha(string senha)
    {
        Regex regex = new Regex(@"^\d{5,10}$");
        return regex.IsMatch(senha);
        // A expressão @"^\d{5,10}$" é utilizada para validar se uma string é composta por apenas números e qntd de caracteres
        // @ - conhecido como prefixo de string verbatim. Ele permite que você crie strings longas que abrangem várias linhas e que não precisam escapar caracteres especiais.
        // ^ - Este é o caractere de início de linha. Ele indica que a correspondência deve começar no início da string.
        // \d - Este é um metacaracter que corresponde a qualquer dígito decimal. Em outras palavras, corresponde a qualquer número de 0 a 9.
        // {5,10} - Estes são quantificadores que especificam que o padrão anterior (neste caso, um dígito) deve aparecer pelo menos 5 vezes, mas não mais do que 10 vezes.
        // $ - Este é o caractere de fim de linha. Ele indica que a correspondência deve terminar no final da string.
    }
    //Função para verificar se o nome contém apenas letras
    public static bool ValidaNome(string nome)
    {
        return nome.All(char.IsLetter);
    }

    static void MostrarSegundaTela()
    {
        Console.Clear();
        System.Console.WriteLine("Aqui é a segunda tela");

    }

    public static void TelaFinal()
    {
        System.Console.WriteLine($"Sejam Bem Vindo {nomeUsuario}");
        System.Console.WriteLine($"Sua senha atual é: {senha}");
        System.Console.WriteLine($"De acordo com as informações dadas, você tem: {idade} anos");
    }


    static void MostrarTerceiraTela() // Caso não tenha um arquivo de texto, está criando um novo e registrando
    {
        using (StreamReader reader = new StreamReader("usuarios.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
            }
        }
    }

    public static void voltarMenu()
    {
        #region Apresentação de menu
        Console.Clear();
        System.Console.WriteLine($"##################### Olá Seja Bem-Vindo {nomeUsuario} #####################");
        System.Console.WriteLine($"Neste sistema {nomeUsuario} pode cadastrar sua senha ou idade.");
        System.Console.WriteLine("Selecione uma opção:");
        System.Console.WriteLine("1 - Cadastrar Senha");
        System.Console.WriteLine("2 - Cadastrar Idade");
        System.Console.WriteLine("3 - Mostrar Usuários");
        System.Console.WriteLine("4 - Sair");


        System.Console.WriteLine("Qual sua opção:");
        #endregion Apresentação de menu
    }
    static void SalvarUsuarioNoArquivo(string nome, int senha, int idade)
    {
        using (StreamWriter writer = File.AppendText("usuarios.txt")) // Escrevendo usuários no arquivo
        {

            writer.WriteLine("-------------------------------");
            writer.WriteLine($"Nome: {nome}");
            writer.WriteLine($"Senha: {senha}");
            writer.WriteLine($"idade: {idade} anos");
            writer.WriteLine("-------------------------------");
            writer.Close();

        }
    }
}