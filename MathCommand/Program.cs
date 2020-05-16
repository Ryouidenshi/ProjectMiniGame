using System;
using System.IO;

namespace MathCommands
{
    class Program
    {
        static void Main()
        {
            var path = @"C:\Users\Stas74\source\repos\16_05\file.txt";
            var file = File.ReadAllText(path);
            Console.WriteLine(file);
            var CompleteActionsInFile = new TheMainDispenserAndTheScore(file);
            CompleteActionsInFile.Calculate();
            foreach (var element in CompleteActionsInFile.DicElements)
                Console.WriteLine("Итоговой значение элемента {0} - {1}",element.Key, element.Value);
        }
    }
}
