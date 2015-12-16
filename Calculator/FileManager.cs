using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineProject
{
    public class FileManager
    {
        public enum Operator : int
        {
            eUnknown = 0,
            eAdd = 1,
            eSubtract = 2,
            eMultiply = 3,
            eDivide = 4,
            ePower = 5,
        }
        
        private static string stringAnswer;
        private static double firstNumber;
        private static double secondNumber;
        private static double numericAnswer;
        private static Operator calcOperation;
        private static double negativeConverter = -1;

        public string GetDate()
        {
            DateTime curDate = new DateTime();
            curDate = DateTime.Now;
            string stringDate = System.Convert.ToString(curDate);

            return (stringDate);
        }

        public string Reset()
        {
            numericAnswer = 0;
            firstNumber = 0;
            secondNumber = 0;
            stringAnswer = "0";
            calcOperation = Operator.eUnknown;

            return stringAnswer;
        }

        public string InputNumber(string keyNumber)
        {
            stringAnswer = stringAnswer + keyNumber;

            return stringAnswer;
        }

        public string InputSign()
        {
            double n = System.Convert.ToDouble(stringAnswer);
            stringAnswer = System.Convert.ToString(n * negativeConverter);

            return stringAnswer;
        }

        public string SecondNumberAdded()
        {
            {
                string Dot = ".";
                if (stringAnswer != "")
                {
                    stringAnswer = stringAnswer + Dot;
                }
                else
                {
                    stringAnswer = "0.";
                }
                return stringAnswer;
            }
        }

        public string InputOperator(string stringAnswer, Operator oper)
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            calcOperation = oper;
            stringAnswer = "";
            return stringAnswer;
        }

        public string InputOperator(Operator oper)
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            calcOperation = oper;
            stringAnswer = "";
            return stringAnswer;
        }

        public string Sqtr()
        {
            {
                firstNumber = System.Convert.ToDouble(stringAnswer);

                if (firstNumber != 0)
                {
                    numericAnswer = Math.Sqrt(firstNumber);
                }
                else
                {
                    numericAnswer = 0;
                }
                stringAnswer = System.Convert.ToString(numericAnswer);

                return stringAnswer;
            }
        }

        public string CubeRoot()
        {
            {
                firstNumber = System.Convert.ToDouble(stringAnswer);
                numericAnswer = Math.Pow(firstNumber, 1 / 3f);
                stringAnswer = System.Convert.ToString(numericAnswer);
                return stringAnswer;
            }
        }

        public string Factorial()
        {
            firstNumber = System.Convert.ToDouble(stringAnswer);
            numericAnswer = 1;
            for (int i = 2; i <= firstNumber; i++)
            {
                numericAnswer = numericAnswer * i;
            }
            stringAnswer = System.Convert.ToString(numericAnswer);
            return stringAnswer;
        }

        public string EqualMethod(string stringAnswer)
        {
            if (stringAnswer != "")
            {
                secondNumber = System.Convert.ToDouble(stringAnswer);

                switch (calcOperation)
                {
                    case Operator.eUnknown:
                        break;

                    case Operator.eAdd:
                        numericAnswer = firstNumber + secondNumber;
                        break;

                    case Operator.eSubtract:
                        numericAnswer = firstNumber - secondNumber;
                        break;

                    case Operator.eMultiply:
                        numericAnswer = firstNumber * secondNumber;
                        break;

                    case Operator.eDivide:

                        if (firstNumber != 0)
                        {
                            numericAnswer = firstNumber / secondNumber;
                        }
                        else
                        {
                            numericAnswer = 0;
                        }
                        break;

                    case Operator.ePower:
                        numericAnswer = Math.Pow(firstNumber, secondNumber);
                        break;
                }
            }
            stringAnswer = System.Convert.ToString(numericAnswer);
            return (stringAnswer);
        }
    }
}
