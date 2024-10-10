using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3D
{
    public readonly struct Vector3DClass(double x, double y, double z)
    {
        public double X { get; } = x;
        public double Y { get; } = y;
        public double Z { get; } = z;

        // task 2

        // Свойство для вычисления модуля вектора
        public readonly double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);


        // task 3

        // Перегрузка оператора сложения
        public static Vector3DClass operator +(Vector3DClass v1, Vector3DClass v2)
        {
            return new Vector3DClass(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        // Перегрузка оператора вычитания
        public static Vector3DClass operator -(Vector3DClass v1, Vector3DClass v2)
        {
            return new Vector3DClass(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        // task 4

        // Перегрузка оператора ==
        public static bool operator ==(Vector3DClass v1, Vector3DClass v2)
        {
            return v1.X == v1.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }

        // Перегрузка оператора !=
        public static bool operator !=(Vector3DClass v1, Vector3DClass v2)
        {
            return !(v1 == v2);
        }

        // task 6

        // Перегрузка оператора умножения на скаляр (слева)
        public static Vector3DClass operator *(double scalar, Vector3DClass v)
        {
            return new Vector3DClass(scalar * v.X, scalar * v.Y, scalar * v.Z);
        }

        // Перегрузка оператора умножения на скаляр (справа)
        public static Vector3DClass operator *(Vector3DClass v, double scalar)
        {
            return scalar * v;
        }

        // task 7

        // Векторное произведение двух векторов
        public static Vector3DClass CrossProduct(Vector3DClass v1, Vector3DClass v2)
        {
            return new Vector3DClass(
                v1.Y * v2.Z - v1.Z * v2.Y,
                v1.Z * v2.X - v1.X * v2.Z,
                v1.X * v2.Y - v1.Y * v2.X
            );
        }

        // task 5

        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"Vector3D({X}, {Y}, {Z})";
        }

        // Переопределение метода Equals
        public override bool Equals(object? obj)
            => obj is Vector3DClass other && this == other; // Используем перегрузку оператора ==

        // Переопределение метода GetHashCode
        public override int GetHashCode()
            => HashCode.Combine(X, Y, Z); // Создаем хэш-код на основе свойств X, Y и Z
    }
}
