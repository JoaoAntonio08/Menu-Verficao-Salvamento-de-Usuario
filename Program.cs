using System;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class Program
{
    // Declarando variáveis globais
    public static string strNome, strNomeTentativa, strSenhaTentativa;
    public static int senha, SenhaTentativa, idade;
    public static string ultimaTelaVisitada;
    static void Main()
    {
        // Menu
        string respota;
        Console.Clear();

        do
        {
            voltarMenu();
            respota = Console.ReadLine();

            if (respota == "1")
            {
                Console.Clear();
                // Tela inicial
                ultimaTelaVisitada = "Tela 1";
                MostrarPrimeiraTela();
            }
            else if (respota == "2")
            {
                Console.Clear();
                // Segunda Tela
                ultimaTelaVisitada = "Tela 2";
                MostrarSegundaTela();
            }
            else if (respota == "3")
            {
                Console.Clear();
                // Terceira tela
                MostrarTerceiraTela();

            }
            else if (respota != "4")
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Tela Inválida");
                System.Console.WriteLine("");
            }

            if (respota != "4") // Caso tenha clicado algum número inválido temos a opção de voltar ao menu
            {
                System.Console.WriteLine("------------------------------------------------------------");
                System.Console.WriteLine("Pressione qualquer tecla par voltar ao menu");
                System.Console.WriteLine("------------------------------------------------------------");
                Console.ReadLine();
            }


        } while (respota != "4");
    }

    static void MostrarPrimeiraTela()
    {
        // Solicita ao usuário que digite seu nome
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("Para realizar seu cadastro digite seu nome");
        System.Console.WriteLine("------------------------------------------------------------");
        strNome = Console.ReadLine();

        // Verifica se o Nome contém apenas letras
        if (!ValidaNome(strNome))
        {
            System.Console.WriteLine("Nome Inválido, Digite apenas letras");
            return;
        }

        // Solicita ao usuário que digite sua senha
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("Para finalizar crie uma senha");
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

        // Inicializa as variáveis booleanas que controlam os loops
        // Só mudam para verdadeiras caso seja o mesmo nome ou senha digitados na primeira vez
        bool nomeCorreto = false;
        bool senhaCorreta = false;

        // Loop para verificar o nome
        do
        {
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.WriteLine("Para confirmar que é você digite o nome de usuário novamente");
            System.Console.WriteLine("------------------------------------------------------------");
            strNomeTentativa = Console.ReadLine();
            if (strNome == strNomeTentativa)
            {
                nomeCorreto = true;
            }
            else
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Nome inválido. Digite novamente.");
                System.Console.WriteLine("");
            }
        } while (!nomeCorreto);

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
        System.Console.WriteLine("Agora você está registrado no nosso sistema");
        System.Console.WriteLine("------------------------------------------------------------");


        // Salvar os dados registrados em um arquivo .txt criado na função SalvarUsuariosNoArquivo
        SalvarUsuarioNoArquivo(strNome, senha);
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
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("Por Favor Informe seu nome");
        System.Console.WriteLine("------------------------------------------------------------");
        strNome = Console.ReadLine();
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("Agora escreva sua idade");
        System.Console.WriteLine("------------------------------------------------------------");
        idade = int.Parse(Console.ReadLine());

        // Salvar os dados registrados em um arquivo .txt criado na função SalvarUsuariosNoArquivo
        SalvarUsuarioNoArquivo(strNome, idade);
        // Chama tela final
        TelaFinal();
    }

    public static void TelaFinal()
    {
        Console.Clear();

        System.Console.WriteLine($"Sejam Bem Vindo {strNome}");

        if (ultimaTelaVisitada == "Tela 1")
        {
            System.Console.WriteLine($"Sua senha atual é: {senha}");
        }
        else if (ultimaTelaVisitada == "Tela 2")
        {
            System.Console.WriteLine($"De acordo com as informações dadas, você tem: {idade} anos");
        }

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
        Console.Clear();
        System.Console.WriteLine("##################### OLÁ SEJA BEM-VINDO #####################");
        System.Console.WriteLine("Neste sistema você pode cadastrar sua senha ou idade.");
        System.Console.WriteLine("Selecione uma opção:");
        System.Console.WriteLine("1 - Cadastrar Senha");
        System.Console.WriteLine("2 - Cadastrar Idade");
        System.Console.WriteLine("3 - Mostrar Usuários");
        System.Console.WriteLine("4 - Sair");


        System.Console.WriteLine("Qual sua opção:");

    }
    static void SalvarUsuarioNoArquivo(string nome, int senha)
    {
        using (StreamWriter writer = File.AppendText("usuarios.txt")) // Escrevendo usuários no arquivo
        {
            writer.WriteLine("-------------------------------");

            writer.WriteLine($"Nome:{nome}");
            if (ultimaTelaVisitada == "Tela 1")
            {
                writer.WriteLine($"Senha: {senha}");
                writer.WriteLine("-------------------------------");
            }
            else if (ultimaTelaVisitada == "Tela 2")
            {
                writer.WriteLine($"idade: {idade} anos");
                writer.WriteLine("-------------------------------");
            }

            writer.Close();

        }
    }
}
