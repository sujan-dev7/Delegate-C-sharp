using System;
using System.ComponentModel.DataAnnotations;

namespace Delegate
{
    public class Program
    {
        public delegate int MathOperation(int a, int b);
        public delegate void Display(string message);

        public static void Main(string[] args)
        {
            Console.WriteLine("Entry point of application");
            int a = 20;
            int b = 5;
            int result = Add(a, b);
            MathOperation addTwoNumbers = Add;
            MathOperation multiplyTwoNumbers = Multiply;
            MathOperation subTwoNumbers = Subtract;
            MathOperation divTwoNumbers = Divide;

            int resultWithDelegate = addTwoNumbers(a, b);
            Console.WriteLine($"Delegate add result :{ resultWithDelegate}");

            MathOperation mathOperation = Add;
            mathOperation += Subtract;
            mathOperation += Multiply;
            mathOperation += Divide;

            int mathOperationResult = mathOperation(a, b);
            Console.WriteLine($"Result with delegate : {mathOperationResult}");

            Display display = DisplayMessage;
            display("Text Message");

            ExecuteMathOperation(10, 5, multiplyTwoNumbers);
        }
        static void ExecuteMathOperation(int x, int y, MathOperation mathCallback)
        {
            int result = mathCallback(x, y);
            Console.WriteLine($"Callback finished execution. Result received: {result}");
        }

        public static int Add (int a, int b)
        {
            Console.WriteLine("Add method called");
            return a + b;

        }
        public static int Subtract (int a, int b)
        {
            Console.WriteLine("Subtract method called");
            return a - b;
        }
        public static int Multiply (int a, int b)
        {
            Console.WriteLine("Multiply method called");
            return a * b;
        }
        public static int Divide (int a, int b)
        {
            Console.WriteLine("Divide method called");
            return a / b;
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}