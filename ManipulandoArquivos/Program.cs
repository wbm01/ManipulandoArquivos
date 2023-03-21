using ManipulandoArquivos;

internal class Program
{
    private static void Main(string[] args)
    {


        string fixedtext = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\nProin fermentum leo vel orci porta non pulvinar neque.\nVivamus arcu felis bibendum ut tristique et egestas quis.\nMalesuada proin libero nunc consequat interdum.\nQuisque sagittis purus sit amet.";

        WriteFile(fixedtext);

        var texto = ReadFile("peste.txt");

        Console.WriteLine(texto);

        Console.Write("Quantas linhas você quer ler? ");
        var lines = int.Parse(Console.ReadLine());

        var txt = ReadFileLines(lines);

        Console.WriteLine(txt);

        string ReadFileLines(int l)
        {
            StreamReader sr = new("peste.txt");
            string txt = "";

            List<string> srlist = new();
            for (int i = 0; i < l; i++)
            {
                txt += sr.ReadLine() + "\n";
            }

            //foreach (var item in srlist)
            //{
            //    txt += item.ToString() + "\n";
            //}

            return txt;
        }

        void WriteFile(string text)
        {
            try
            {
                if (File.Exists("peste.txt"))
                {
                    StreamWriter sw = new("peste.txt");
                    sw.WriteLine(text);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("peste.txt");
                    sw.WriteLine(text);
                    sw.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("Registro Gravado com Sucesso!");
                Thread.Sleep(1000);
            }
        }

        string ReadFile(string f)
        {
            StreamReader sr = new StreamReader(f);
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
            var name = Console.ReadLine();
            Console.Write("\nInforme o genero da pessoa: ");
            var gender = char.Parse(Console.ReadLine());

            return new Person(name, gender);
        }
    }

}