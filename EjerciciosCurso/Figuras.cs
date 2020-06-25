using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EjerciciosCurso {
    public abstract class Figura {
        public Color Color { get; set; } = Color.Transparent;

        public Figura() { }
        public Figura(Color color) {
            Color = color;
        }

        public abstract double Area { get; }
    }

    public class Circulo : Figura {
        public Circulo(double radio) {
            Radio = radio;
        }
        public Circulo(double radio, Color color) : base(color) {
            Radio = radio;
        }

        public double Radio { get; set; }
        public override double Area => Math.PI * Math.Pow(Radio, 2);

        public override string ToString() {
            return $"Circulo [Radio: {Radio} Color: {Color} Área: {Area}]";
        }
    }

    public class Triangulo : Figura {
        public double Base { get; set; }
        public double Altura { get; set; }

        public Triangulo(double @base, double altura) {
            Base = @base;
            Altura = altura;
        }
        public Triangulo(double @base, double altura, Color color): this(@base, altura) {
            Color = color;
        }

        public override double Area => Base * Altura / 2;

        public override string ToString() {
            return $"Triangulo [Base: {Base} Altura: {Altura} Color: {Color} Área: {Area}]";
        }
    }

    public class Rectangulo : Figura {
        public virtual double LadoA { get; set; }
        public virtual double LadoB { get; set; }

        public Rectangulo(double ladoA, double ladoB) {
            LadoA = ladoA;
            LadoB = ladoB;
        }
        public Rectangulo(double ladoA, double ladoB, Color color):this(ladoA, ladoB) {
            Color = color;
        }

        public override double Area => LadoA * LadoB;

        public override string ToString() {
            return $"Rectángulo [Lado A: {LadoA} Lado B: {LadoB} Color: {Color} Área: {Area}]";
        }
    }

    public class Cuadrado : Rectangulo {
        public override double LadoA {
            get => base.LadoA;
            set {
                base.LadoA = value;
                base.LadoB = value;
            }
        }
        public override double LadoB {
            get => base.LadoA;
            set {
                base.LadoA = value;
                base.LadoB = value;
            }
        }

        public double Lado { get => base.LadoA; set => base.LadoA = value; }

        public Cuadrado(double lado) : base (lado, lado) { }
        public Cuadrado(double lado, Color color) : base (lado, lado, color) { }

        public override double Area => LadoA * LadoB;

        public override string ToString() {
            return $"Cuadrado [Lado: {Lado} Color: {Color} Área: {Area}]";
        }
    }
}
