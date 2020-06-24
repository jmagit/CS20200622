using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosCurso {
    public class Point: ICloneable {
        public Point(double x, double y) {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public object Clone() {
            return new Point(this.X, this.Y);
        }

        public override bool Equals(object obj) {
            return obj is Point punto &&
                   X == punto.X &&
                   Y == punto.Y;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static bool operator ==(Point left, Point right) {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right) {
            return !(left == right);
        }
    }

    public class Line {
        private readonly Point punto1;
        private readonly Point punto2;

        public Line(Point punto1, Point punto2) {
            this.punto1 = punto1;
            this.punto2 = punto2;
        }

        public Point Punto1 { get => punto1.Clone() as Point;  }
        public Point Punto2 { get => punto2.Clone() as Point;  }

        public double DeltaX() { return Math.Abs(Punto1.X - Punto2.X); }
        public double DeltaY() { return Math.Abs(Punto1.Y - Punto2.Y); }
    }

    class Ejercicio1 {
        public void Ejecutar() {
            Caso1();
            Caso2();
            Caso3();
            Caso4();
        }

        public void Caso1() {
            var A = "string";
            var B = "string";
            var C = A;

            Console.WriteLine($"\nCadenas");
            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine($"A == B es {A == B}");
            Console.WriteLine($"A.Equals(B) es {A.Equals(B)}");
            Console.WriteLine($"A == C es {A == C}");
            Console.WriteLine($"A.Equals(C) es {A.Equals(C)}");
            Console.WriteLine($"B == C es {B == C}");
            Console.WriteLine($"B.Equals(C) es {B.Equals(C)}");
        }
        public void Caso2() {
            var A = new Point(3, 5);
            var B = new Point(3, 5);
            var C = A;

            Console.WriteLine($"\nPuntos");
            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine($"A == B es {A == B}");
            Console.WriteLine($"A.Equals(B) es {A.Equals(B)}");
            Console.WriteLine($"A == C es {A == C}");
            Console.WriteLine($"A.Equals(C) es {A.Equals(C)}");
            Console.WriteLine($"B == C es {B == C}");
            Console.WriteLine($"B.Equals(C) es {B.Equals(C)}");
        }
        public void Caso3() {
            var L = new Line(new Point(3, 5), new Point(3, 5));
            var P = L.Punto1;
            var Ant = L.DeltaX();
            P.X = 10;
            var Pos = L.DeltaX();

            Console.WriteLine($"\nReferencias");
            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine($"Ant: {Ant} Pos: {Pos} Iguales: {Ant == Pos}");
        }

        void Add(Point p) { p.X += 1; }

        public void Caso4() {
            var L = new Line(new Point(3, 5), new Point(3, 5));
            var P = L.Punto1;
            var Ant = L.DeltaX();
            Add(P.Clone() as Point);
            var Pos = L.DeltaX();

            Console.WriteLine($"\nPaso por Referencias");
            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine($"Ant: {Ant} Pos: {Pos} Iguales: {Ant == Pos}");
        }
    }
}

