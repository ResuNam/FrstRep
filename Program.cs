using System;

namespace BarsEv
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Press_c_to_exit();
            obj.OnKeyPressed += (object sender, char c) => Console.WriteLine(c);
            obj.Run();
        }
    }

    class Press_c_to_exit
    {
        public event EventHandler<char> OnKeyPressed;

        public void Run()
        {
            ConsoleKeyInfo c;
            do
            {
                c = Console.ReadKey();
                if (c.Key == ConsoleKey.C)
                    break;
                OnKeyPressed?.Invoke(this, c.KeyChar);

            } while (true);
        }
    }
}