using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace MathCommands
{
    public class TheMainDispenserAndTheScore
    {
        private string[] fileSplit; //пусть файл будет вида например: var 5; mov a, 6; add a, 10
        private Dictionary<string, double> dicElements = new Dictionary<string, double>();
        public TheMainDispenserAndTheScore(string fileSplit)
        {
            FileSplit = fileSplit.Split(';');
        }
        public string[] FileSplit
        {
            get { return fileSplit; }
            set { fileSplit = value; }
        }
        public Dictionary<string, double> DicElements
        {
            get { return dicElements; }
            set { dicElements = value; }
        }

        public void Calculate()
        {
            for (var i=0; i<FileSplit.Count();i++)
            {
                var splitElementsOperation = FileSplit[i].Split(',', ' ');
                switch (splitElementsOperation[0])
                {

                    case "var":
                        dicElements.Add(splitElementsOperation[1], double.Parse(splitElementsOperation[2]));
                        break;
                    case "add":
                        dicElements[splitElementsOperation[1]] = MakeOperation(splitElementsOperation, "add");
                        break;
                    case "div":
                        dicElements[splitElementsOperation[1]] = MakeOperation(splitElementsOperation, "div");
                        break;
                    case "mul":
                        dicElements[splitElementsOperation[1]] = MakeOperation(splitElementsOperation, "mul");
                        break;
                    case "sub":
                        dicElements[splitElementsOperation[1]] = MakeOperation(splitElementsOperation, "sub");
                        break;
                    case "mov":
                        dicElements[splitElementsOperation[1]] = MakeOperation(splitElementsOperation, "mov");
                        break;

                }
            }
        }

        public double MakeOperation(string[] splitFile, string operation)
        {
            var calc = new Calculator(dicElements[splitFile[1]], double.Parse(splitFile[2]), operation);
            return calc.Calculation(calc.First, calc.Second, calc.Operation);
        }
    }
}
