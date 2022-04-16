using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static DummyRequestHandler RequestHandler = new DummyRequestHandler();

        public static void Main(string[] args)
        {
            Console.WriteLine("Приложение запущено");
            Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
            var command = RedInput();
            while (command != "/exit")
            {
                Request(command);
                Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
                command = RedInput();
            }

            Console.WriteLine("Приложение заверщает работу.");
        }

        static string RedInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var str = Console.ReadLine();
            Console.ResetColor();
            return str;
        }

        static void Request(string message)
        {
            Console.WriteLine($"Будет послано сообщение '{message}'");
            Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны - введите /end");

            var args = new List<string>();
            var command = RedInput();
            while (command != "/end")
            {
                args.Add(command);
                Console.WriteLine("Введите следующий аргумент сообщения. Если аргументы не нужны - введите /end");
                command = RedInput();
            }
            var id = Guid.NewGuid().ToString("D");
            ThreadPool.QueueUserWorkItem(callBack => HandleRequest(id, message, args));
            Console.WriteLine($"Было отправлено сообщение '{message}'. Присвоен идентификатор {id}");
        }

        static void HandleRequest(string id, string message, List<string> args)
        {
            try
            {
                var r = RequestHandler.HandleRequest(message, args.ToArray());
                Console.WriteLine($"Сообщение с идентификатором {id} получило ответ - {r}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сообщение с идентификатором {id} упало с ошибкой: {ex.Message}");
            }
        }
    }
}