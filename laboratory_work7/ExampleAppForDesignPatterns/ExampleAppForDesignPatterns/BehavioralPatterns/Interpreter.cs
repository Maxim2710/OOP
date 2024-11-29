using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Абстрактный класс для выражений
    public abstract class Expression
    {
        public abstract int Interpret();
    }

    // Терминальные выражения
    public class Number : Expression
    {
        private readonly int _value;

        public Number(int value)
        {
            _value = value;
        }

        public override int Interpret()
        {
            return _value;
        }
    }

    // Нетерминальное выражение (операция сложения)
    public class Add : Expression
    {
        private readonly Expression _leftExpression;
        private readonly Expression _rightExpression;

        public Add(Expression left, Expression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public override int Interpret()
        {
            return _leftExpression.Interpret() + _rightExpression.Interpret();
        }
    }

    // Нетерминальное выражение (операция вычитания)
    public class Subtract : Expression
    {
        private readonly Expression _leftExpression;
        private readonly Expression _rightExpression;

        public Subtract(Expression left, Expression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public override int Interpret()
        {
            return _leftExpression.Interpret() - _rightExpression.Interpret();
        }
    }

    // Клиент
    public class Client3
    {
        public static void ExecuteInterpreterPattern()
        {
            // Формируем выражение: (3 + 2) - 1
            Expression three = new Number(3);
            Expression two = new Number(2);
            Expression one = new Number(1);

            Expression add = new Add(three, two); // (3 + 2)
            Expression subtract = new Subtract(add, one); // (3 + 2) - 1

            // Интерпретируем выражение
            Console.WriteLine("Результат интерпретации: " + subtract.Interpret());
        }
    }
}
