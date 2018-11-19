using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public enum Operator
    {
        plus,// +
        minus,// -
        multiply,// *
        divide,// /
        power,// ^
    }
    class Number
    {
        int _int;
        int child;
        int mother;
        bool negative;
        public Number(int a, int b, int c, bool d)
        {
            _int = a;
            child = b;
            mother = c;
            negative = d;
            Text();
        }
        public Number(int a, int b, bool c)
        {
            _int = 0;
            child = a;
            mother = b;
            negative = c;
            Text();
        }
        public Number(int a, bool b)
        {
            _int = a;
            child = 0;
            mother = 0;
            negative = b;
            Text();
        }
        private bool Text()
    }
    class Calculate
    {
        Stack<Operator> _operator;
        Stack<double> _number;
        Stack<int> power;
        bool _new;
        bool _point;
        double ans;
        string question;
        public Calculate(string question)
        {
            _operator = new Stack<Operator>();
            _number = new Stack<double>();
            this.question = question;
            _Calculate();
        }
        private bool Add(char a)
        {
            int b = Convert.ToInt32(a);
            double d = 0;
            int e = 0;
            if (!_new)
            {
                d = _number.Pop();
                e = power.Pop();
            }
            if (_point)
            {
                e++;
                for (int i = 0; i < e; i++)
                {
                    d *= 10;
                }
                d += b;
                for (int i = 0; i < e; i++)
                {
                    d /= 10;
                }
                _number.Push(d);
                power.Push(e);
                return true;
            }
            else
            {
                d = d * 10 + b;
                _number.Push(d);
                power.Push(e);
                return true;
            }
        }
        private double Once(double c, Operator b, double a)
        {
            if (b == Operator.plus)
            {
                return a + c;
            }
            else if (b == Operator.minus)
            {
                return a - c;
            }
            else if (b == Operator.multiply)
            {
                return a * c;
            }
            else if (b == Operator.divide)
            {
                return a / c;
            }
            else
            {
                return Math.Pow(a, c);
            }
        }
        private double _Calculate()
        {
            for (int i = 0; i < question.Length; i++)
            {
                _new = true;
                _point = false;
                if (question[i] == '(')
                {
                    _new = true;
                }
                else if (question[i] == '+')
                {
                    _operator.Push(Operator.plus);
                    _new = true;
                }
                else if (question[i] == '-')
                {
                    _operator.Push(Operator.minus);
                    _new = true;
                }
                else if (question[i] == '*')
                {
                    _operator.Push(Operator.multiply);
                    _new = true;
                }
                else if (question[i] == '/')
                {
                    _operator.Push(Operator.divide);
                    _new = true;
                }
                else if (question[i] == '^')
                {
                    _operator.Push(Operator.power);
                    _new = true;
                }
                else if (question[i] == ')')
                {
                    double a, c, d;
                    Operator b;
                    a = _number.Pop();
                    b = _operator.Pop();
                    c = _number.Pop();
                    d = Once(c, b, a);
                    _number.Push(d);
                }
                else
                {
                    if (question[i] == '.')
                    {
                        _point = true;
                    }
                    else
                    {
                        bool _ok = Add(question[i]);
                        if (!_ok)
                        {
                            Exception exception = new Exception("error");
                        }
                    }
                }
            }
            return _number.Pop();
        }
    }
}

