using System;
using System.Linq;

namespace Fraction
{
    class Fraction
    {
        private double main;
        private double numerator;
        private double denumerator;
        private string[] fileSplit;
        private string[] arrayToFoundOperations;
        public Fraction(string fileSplit, string originalString)
        {
            FileSplit = fileSplit.Split('+', '-', '*', '/');
            ArrayToFoundOperations = originalString.Split();
        }
        public string[] FileSplit
        {
            get { return fileSplit; }
            set { fileSplit = value; }
        }
        public double Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }
        public double Denumerator
        {
            get { return denumerator; }
            set { denumerator = value; }
        }
        public double Main
        {
            get { return main; }
            set { main = value; }
        }
        public string[] ArrayToFoundOperations
        {
            get { return arrayToFoundOperations; }
            set { arrayToFoundOperations = value; }
        }
        private static bool first = true;
        public string AddInFraction()
        {
            for (int i=0; i<FileSplit.Count()-1;i++)
            {
                var splitedFirstPartFile = FileSplit[i].Split(' ', '\\').Where(s => s != String.Empty).ToArray<string>();
                var splitedNextPartFile = FileSplit[i+1].Split(' ','\\').Where(s => s != String.Empty).ToArray<string>();
                double firstDenumerator = double.Parse(splitedFirstPartFile[2]);
                double adv = firstDenumerator;
                double nextDenumerator = double.Parse(splitedNextPartFile[2]);
                if (splitedFirstPartFile[2] != splitedNextPartFile[2])
                {
                    splitedFirstPartFile[1] = (double.Parse(splitedFirstPartFile[1]) * nextDenumerator).ToString();
                    splitedNextPartFile[1] = (double.Parse(splitedNextPartFile[1]) * firstDenumerator).ToString();
                    firstDenumerator *= nextDenumerator;
                    nextDenumerator *= adv;
                }
                var operation = FoundOperation(null);
                switch(operation)
                {
                    case "+":
                        if (first == true)
                        {
                            Main += double.Parse(splitedFirstPartFile[0]) + double.Parse(splitedNextPartFile[0]);
                            Numerator += double.Parse(splitedFirstPartFile[1]) + double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                            first = false;
                        }
                        else
                        {
                            Main += double.Parse(splitedNextPartFile[0]);
                            Numerator += double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                        }
                        break;
                    case "-":
                        if (first == true)
                        {
                            Main += double.Parse(splitedFirstPartFile[0]) - double.Parse(splitedNextPartFile[0]);
                            Numerator += double.Parse(splitedFirstPartFile[1]) - double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                            first = false;
                        }
                        else
                        {
                            Main -= double.Parse(splitedNextPartFile[0]);
                            Numerator -= double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                        }
                        break;
                    case "*":
                        if (first == true)
                        {
                            Main += double.Parse(splitedFirstPartFile[0]) * double.Parse(splitedNextPartFile[0]);
                            Numerator += double.Parse(splitedFirstPartFile[1]) * double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                            first = false;
                        }
                        else
                        {
                            Main *= double.Parse(splitedNextPartFile[0]);
                            Numerator *= double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                        }
                        break;
                    case "/":
                        if (first == true)
                        {
                            Main += double.Parse(splitedFirstPartFile[0]) / double.Parse(splitedNextPartFile[0]);
                            Numerator += double.Parse(splitedFirstPartFile[1]) / double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                            first = false;
                        }
                        else
                        {
                            Main /= double.Parse(splitedNextPartFile[0]);
                            Numerator /= double.Parse(splitedNextPartFile[1]);
                            Denumerator = nextDenumerator;
                        }
                        break;
                    default: break;
                }
            }
            return "Ответ без перевода: "+Main.ToString()+ ' ' +Numerator.ToString() + '/' + Denumerator.ToString();
        }

        private static int index=0;

        public string FoundOperation(string op)
        {
            while (op==null)
            {
                switch (arrayToFoundOperations[index])
                {
                    case "+":
                        op = "+";
                        break;
                    case "-":
                        op = "-";
                        break;
                    case "*":
                        op = "*";
                        break;
                    case "/":
                        op = "/";
                        break;
                }
                index++;
            }
            return op;
        }

    }
}
