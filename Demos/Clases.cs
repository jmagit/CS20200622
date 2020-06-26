using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Majorel.Demos.Cursos {
    [Serializable]
    public abstract partial class Persona : IGrafico, ICloneable {
        protected static int cont = 0;
        private int id;
        protected string nombre, apellidos;
        [NonSerialized]
        int aux = 1;

        public Persona(string nombre, string apellidos) {
            this.Nombre = nombre;
            this.apellidos = apellidos;
        }
        [Name("id")]
        public int Id { get => id; set => id = value; }
        [Name("nombre")]
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
        [Name("apellidos")]
        public string Apellidos { get => apellidos; set => apellidos = value; }
        [Name("edad")]
        public int Edad { get; set; } = -1;
        [Ignore]
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
    [Serializable]
    public class Alumno : Persona , ISerializable {
        public Alumno(string nombre, string apellidos) : base(nombre, apellidos) {
        }
        public Alumno(int id, string nombre, string apellidos, int edad) : base(nombre, apellidos) {
            Id = id;
            Edad = edad;
        }

        public override void Despide() {
            throw new NotImplementedException();
        }

        public Alumno(SerializationInfo info, StreamingContext context) : base("?", null) {
            Id = info.GetInt32("id");
            Nombre = info.GetString("nom");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("id", Id);
            info.AddValue("nom", Nombre.ToUpper());
        }

    }
}
