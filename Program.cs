using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Tela inicial
        MostrarTelaInicial();
    }

    static void MostrarTelaInicial()
    {
        string strNome, strNomeTentativa;
        string strSenhaTentativa;
        int senha, SenhaTentativa;

        // Solicita ao usuário que digite seu nome
        System.Console.WriteLine("Para cadastrar um novo usuário digite seu Nome");
        strNome = Console.ReadLine();

        // Verifica se o Nome contém apenas letras
        if (!ValidaNome(strNome))
        {
            System.Console.WriteLine("Nome Inválido, Digite apenas letras");
            return;
        }

        // Solicita ao usuário que digite sua senha
        System.Console.WriteLine("Por fim digite sua senha");
        System.Console.WriteLine("É importante lembrar que a senha deve conter apenas números");
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
            System.Console.WriteLine("Agora confirme seu nome");
            strNomeTentativa = Console.ReadLine();
            if (strNome == strNomeTentativa)
            {
                System.Console.WriteLine("Você passou na verificação do nome");
                nomeCorreto = true;
            }
            else
            {
                System.Console.WriteLine("Nome inválido. Digite novamente.");
            }
        } while (!nomeCorreto);

        // Loop para verificar a senha
        do
        {
            System.Console.WriteLine("Por fim confirme sua senha");
            SenhaTentativa = int.Parse(Console.ReadLine());
            if (senha == SenhaTentativa)
            {
                System.Console.WriteLine("Você passou na verificação da senha");
                senhaCorreta = true;
            }
            else
            {
                System.Console.WriteLine("Senha inválida. Digite novamente.");
            }
        } while (!senhaCorreta);

        System.Console.WriteLine("Você passou na verificação, agora está registrado seu nome e senha");
        
        //Chamando Segunda tela
        MostrarSegundaTela();
    }

    // Função Criada para Verificar se senha é composta por apenas números e com caracteres de 5 a 10 números
    public static bool ValidaSenha(string senha)
    {
        // A expressão @"^\d{5,10}$" é utilizada para validar se uma string é composta por apenas números e qntd de caracteres
        // @ - conhecido como prefixo de string verbatim. Ele permite que você crie strings longas que abrangem várias linhas e que não precisam escapar caracteres especiais.
        // ^ - Este é o caractere de início de linha. Ele indica que a correspondência deve começar no início da string.
        // \d - Este é um metacaracter que corresponde a qualquer dígito decimal. Em outras palavras, corresponde a qualquer número de 0 a 9.
        // $ - Este é o caractere de fim de linha. Ele indica que a correspondência deve terminar no final da string.
        Regex regex = new Regex(@"^\d$");
        return regex.IsMatch(senha);
    }
    public static bool ValidaNome(string nome)
    {
        return nome.All(char.IsLetter);
    }
    
    static void MostrarSegundaTela()
    {
        Console.Clear();
        System.Console.WriteLine("Bem-vindo à segunda tela!");
    }
}
