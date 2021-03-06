﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosCurso {
    class Calculadora {
        private decimal acumulador = 0;
        private string pendiente = "+";

        public decimal Acumulador { get => acumulador; }

        public event EventHandler<CalculoEventArgs> Resultado;

        public void Init() {
            acumulador = 0;
            pendiente = "+";
        }

        [Obsolete("Versión dependiente de la consola")]
        public void Decodificar(string cad) {
            var operComplet = false;
            var finNum = false;
            var num = "";
            foreach (var c in cad) {
                if (operComplet)
                    throw new Exception("No puedo continuar después del =");

                if ("1234567890, +-*/=".IndexOf(c) == -1)
                    throw new Exception("Entrada no valida");
                if (c == ' ') {
                    finNum = num.Length > 0;
                    continue;
                }
                if ('0' <= c && c <= '9' || c == ',') {
                    if (finNum)
                        throw new Exception("No puedo continuar después del blanco");
                    num += c;
                    continue;
                }

                if ("+-*/=".IndexOf(c) != -1) {
                    if (num.Length == 0)
                        throw new Exception("No tengo el número para operar.");
                    if (num[^1] == ',')
                        throw new Exception("Faltan decimales.");
                    Console.WriteLine($"{num} {c}");
                    finNum = false;
                    num = "";
                    operComplet = c == '=';
                }
            }
            if (!operComplet)
                throw new Exception("Falta el =");
        }

        public void Calcula(string operando, string operacion) {
            if (!decimal.TryParse(operando, out decimal numero))
                throw new Exception("Operando invalido.");
            switch (pendiente) {
                case "+":
                    acumulador += numero;
                    break;
                case "-":
                    acumulador -= numero;
                    break;
                case "*":
                    acumulador *= numero;
                    break;
                case "/":
                    acumulador /= numero;
                    break;
                case "=":
                    break;
                default:
                    throw new Exception("Operación desconocida.");
            }
            OnResultado(new CalculoEventArgs() { Operando = numero, Operacion = operacion, Resultado = acumulador });
            pendiente = operacion;
        }

        protected virtual void OnResultado(CalculoEventArgs e) {
            Resultado?.Invoke(this, e);
            //if (Resultado != null)
            //    Resultado(this, e);

        }
        public void Calcula(string cad) {
            Init();
            Decodificar(cad, Calcula);
        }

        public void Decodificar(string cad, Action<string, string> tratar) {
            var operComplet = false;
            var finNum = false;
            var num = "";
            foreach (var c in cad) {
                if (operComplet)
                    throw new Exception("No puedo continuar después del =");

                if ("1234567890, +-*/=".IndexOf(c) == -1)
                    throw new Exception("Entrada no valida");
                if (c == ' ') {
                    finNum = num.Length > 0;
                    continue;
                }
                if ('0' <= c && c <= '9' || c == ',') {
                    if (finNum)
                        throw new Exception("No puedo continuar después del blanco");
                    num += c;
                    continue;
                }

                if ("+-*/=".IndexOf(c) != -1) {
                    if (num.Length == 0)
                        throw new Exception("No tengo el número para operar.");
                    if (num[^1] == ',')
                        throw new Exception("Faltan decimales.");
                    tratar(num, c.ToString());
                    finNum = false;
                    num = "";
                    operComplet = c == '=';
                }
            }
            if (!operComplet)
                throw new Exception("Falta el =");
        }
 

        public void Ficheros() {
            string line;
            System.IO.StreamReader fileIn = new System.IO.StreamReader(@"Entrada.txt");
            using (System.IO.StreamWriter fileOut = new System.IO.StreamWriter(@"Salida.txt"))
                while ((line = fileIn.ReadLine()) != null) {
                    Decodificar(line, (n, o) => fileOut.Write($"{n}\r\n{o}"));
                    Calcula(line);
                    fileOut.WriteLine($"====================\r\n{acumulador}");
                }
            fileIn.Close();

        }
    }

    public class CalculoEventArgs : EventArgs {
        public decimal Operando { get; set; }
        public string Operacion { get; set; }
        public decimal Resultado { get; set; }
    }
}
