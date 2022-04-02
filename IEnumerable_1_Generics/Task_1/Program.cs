using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var intLFL = new LocalFileLogger<int>(@"d:\Log.txt");
            var stringLFL = new LocalFileLogger<string>(@"d:\Log.txt");
            var boolLFL = new LocalFileLogger<bool>(@"d:\Log.txt");

            intLFL.LogInfo("Все целы.");
            stringLFL.LogInfo("Всё читаемо.");
            boolLFL.LogInfo("Всё логично.");

            intLFL.LogWarning("Число вне допустимых границ.");
            stringLFL.LogWarning("Неверный формат строки.");
            boolLFL.LogWarning("Значение не задано. Установлено значение по умолчанию(true).");
            
            var exception = new StackOverflowException();
            intLFL.LogError("Бесконечность — не предел", exception);
            stringLFL.LogError("Много букв", exception);
            boolLFL.LogError("Парадокс", exception);
        }
    }
}
