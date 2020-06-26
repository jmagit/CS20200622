using System;
using System.Collections.Generic;
using System.Text;

namespace Majorel.Demos.Cursos {
    public abstract partial class Persona : IGrafico, ICloneable {
        protected static int cont = 0;
        private int id;
        protected string nombre, apellidos;

        public Persona(string nombre, string apellidos) {
            this.Nombre = nombre;
            this.apellidos = apellidos;
        }
        public string Nombre {
            get {
                return nombre;
            }
            set {
                if (String.IsNullOrWhiteSpace(value)) // (value == null || value == "")
                    throw new Exception("Nombre invalido");
                
                if (nombre == value) return;
                nombre = value;
            }
        }
        public string NombreLargo {
            get {
                return $"{nombre} {apellidos}";
            }
            set {
                if (value == null || value == "")
                    throw new Exception("Nombre invalido");
                var partes = value.Split(' ');
                nombre = partes[0];
                apellidos = partes[1];
            }
        }

        public int Edad { get; set; } = 25;
        public int Id { get => id; set => id = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }

        public virtual void Pintate() {
            Console.WriteLine($"Persona: {nombre} {apellidos} de un total de {cont}");
        }
        public abstract void Despide();

        public override string ToString() {
            return $"Persona[Nombre: {nombre}, Apellido: {apellidos}]";
        }

        public override bool Equals(object obj) {
            return (obj is Persona) && this.Id == (obj as Persona).Id;
        }

        public object Clone() {
            throw new NotImplementedException();
        }
    }

    public partial class Profesor : Persona, IDisposable {
        public List<Alumno> Alumnos { get; set; } = new List<Alumno>();
        public Profesor(string nombre, string apellidos) : base(nombre, apellidos) {
        }
        public Profesor() : base("Anonimo", null) {
        }

        public override void Despide() {
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
        public override void Pintate() {
            Console.WriteLine($"Persona: {nombre} {apellidos} de un total de {cont}");
        }

    }
    public class Alumno : Persona {
        public Alumno(string nombre, string apellidos) : base(nombre, apellidos) {
        }
        public Alumno(int id, string nombre, string apellidos, int edad) : base(nombre, apellidos) {
            Id = id;
            Edad = edad;
        }

        public override void Despide() {
            throw new NotImplementedException();
        }
    }
}
