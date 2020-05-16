using System;

namespace MathCommands
{
    public class Calculator
    {
        private double first;
        private double second;
        private string operation;
        public Calculator(double first, double second, string operation)
        {
            First = first;
            Second = second;
            Operation = operation;
        }
        public double First
        {
            get { return first; }
            set { first = value; }
        }
        public double Second
        {
            get { return second; }
            set { second = value; }
        }
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public double Calculation(double a, double b, string operation)
        {
            switch (operation)
            {
                case "add":
                    return a + b;
                case "div":
                    return a / b;
                case "sub":
                    return a - b;
                case "mul":
                    return a * b;
                case "mov":
                    return b;
                default: throw new Exception("Неправильное действие");
            }         
        }
    }
}
