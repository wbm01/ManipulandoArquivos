using System.Data;
using ManipulandoArquivos;

internal class Program
{
    private static void Main(string[] args)
    {
        string name;
        char gender;
        string file;
        //string fixedtext = "Lorem ipsum dolor sit amet, @consectetur adipiscing elit. Duis ut nisi justo. @Nulla ac lorem ante. Praesent tellus est, feugiat et vulputate eu, @vehicula eu justo. Aenean nec fermentum ex. @Morbi urna urna, mollis quis malesuada sit amet"

        Person person1 = CreatePerson();
        Person person2 = CreatePerson();

        WriteFile(person1);
        WriteFile(person2);

        Console.Clear();

        Console.Write("Informe o nome do arquivo a ser lido: ");
        file = Console.ReadLine();

        var texto = ReadFile(file);

        Console.WriteLine(texto);

        void WriteFile(Person person)
        {
            try
            {
                if (File.Exists("backup.txt"))
                {
                    var temp = ReadFile("backup.txt");
                    StreamWriter sw = new StreamWriter("backup.txt"); // Cria o arquivo
                    sw.WriteLine(temp + person.ToString());
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter("backup.txt");
                    sw.WriteLine(person.ToString());
                    sw.Close();
                }
            }
            catch (Exception) {

                throw;
            }
            finally
            {
                Console.WriteLine("Registro gravado com sucesso!");
                Thread.Sleep(1000);
            }
        }

        string ReadFile(string file)
        {
                StreamReader sr = new StreamReader(file);
                string text = "";

            try
            {

                text = sr.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                sr.Close();
            }
            return text;
        }

        Person CreatePerson()
        {

            Console.Write("Informe o nome da pessoa: ");
            name = Console.ReadLine();

            Console.Write("Informe o gênero da pessoa: ");
            gender = char.Parse(Console.ReadLine());

            return new Person(name, gender); // retorna uma nova pessoa para o objeto person
        }
    }
}