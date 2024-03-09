using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Escreva seu nome : ");
        string nome = Console.ReadLine();
        Console.Write("Escreva sua cidade natal : ");
        string cidade = Console.ReadLine();
        Console.Write("Escreva sua data de nascimento : ");
        string nascimento = Console.ReadLine();

        string dados = $"{nome} {cidade} {nascimento}";
        Console.WriteLine($"Nome: {nome} Cidade Natal: {cidade} Data de Nascimento: {nascimento}");

        byte[] bytesEntrada = Encoding.UTF8.GetBytes(dados);
        byte[] hashBytes;
        using (SHA256 sha256 = SHA256.Create()){
            hashBytes = sha256.ComputeHash(bytesEntrada);
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++){
            sb.Append(hashBytes[i].ToString("x2"));
        }string hashString = sb.ToString();


        using (StreamWriter writer = new StreamWriter("dados.txt")){
            writer.WriteLine($"Dados criptografados : {hashString} || Dados normais : {dados}");
        }
    }
}