using Biblioteca;
using corto = Majorel.Demos.Cursos;
using System;
using System.Drawing;
using static System.Math;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Majorel.Demos.Cursos;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace Majorel.Demos {
    public enum DiasLaborales {
        Lunes = 1,
        Martes,
        Miercoles = 7,
        Jueves,
        Viernes
    }

    public interface IGrafico {
        void Pintate();
    }

    namespace Cursos {
        public partial class Persona : IGrafico {
            public void Saluda(string nombre, int veces = 1, string saludo = "Hola") {
                if (veces == 0)
                    return;
                nombre = nombre.ToUpper();
                for (int i = 1; i <= veces; i++)
                    Console.WriteLine($"{saludo} {nombre}");
            }
            public void Saluda(params string[] varios) {
                foreach (var item in varios)
                    Console.WriteLine($"Hola {item}");
            }

            public void Cambia(ref string nombre) {
                nombre = nombre.ToUpper();
            }

            public string NombreCompleto() {
                return $"{apellidos}, {nombre}";
            }
        }
    }

    /// <summary>
    /// Mi primera clase
    /// </summary>
    public class Program {
        static void CargaAlumnos(List<Alumno> lst) {
            StreamReader file = new StreamReader(@"personas.csv");
            string line;
            string[] row;
            line = file.ReadLine(); // Linea de cabecera
            if (line != null)
                while ((line = file.ReadLine()) != null) {
                    row = line.Split(',');
                    lst.Add(new Alumno(
                            int.Parse(row[0]),
                            row[1],
                            row[2],
                            int.Parse(row[3])
                        ));
                }
            file.Close();
            //using (var reader = new StreamReader("personas.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
            //    lst.AddRange(csv.GetRecords<Alumno>());
            //}
        }
        static void GuardaAlumnos(List<Alumno> lst) {
            using (System.IO.StreamWriter fileOut = new System.IO.StreamWriter(@"resultados.csv")) {
                fileOut.WriteLine("id,nombre,apellidos,edad");
                foreach (var item in lst) {
                    fileOut.WriteLine($"{item.Id},{item.Nombre},{item.Apellidos},{item.Edad}");
                }
            }
        }

        static void Main(string[] args) {
            var alumnos = new List<Alumno>();
            alumnos.Add(new Alumno("Alberto", "Gonzalez"));
            alumnos.Add(new Alumno("Carlos", "Sanchez"));
            foreach (var item in alumnos) {
                Console.WriteLine($"{item.Nombre} {item.Apellidos}");
            }
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"{alumnos[0].Nombre} {alumnos[0].Apellidos}");
            // alumnos.RemoveAt(0);
            alumnos.Add(new Alumno("Fernando", "Soto"));
            alumnos.Add(new Alumno("Antonio", "Martos"));
            alumnos.Add(new Alumno("Antonio", "Rodriguez"));
            Console.WriteLine($"----------------------------------");
            foreach (var item in alumnos) {
                Console.WriteLine($"{item.Nombre} {item.Apellidos}");
            }
            Console.WriteLine($"----------------------------------");
            var profesores = new Dictionary<string, Profesor>();
            profesores.Add("C#", new Profesor("Javier", "Martin"));
            var profe = profesores["C#"];
            profe.Edad = 33;
            profe = profesores.FirstOrDefault(o => 25 < o.Value.Edad && o.Value.Edad < 50).Value;

            profe.Alumnos.AddRange(alumnos);

            Console.WriteLine($"{profe.Nombre} {profe.Apellidos}");
            foreach (var item in profesores.Values
                .Where(p => p.Alumnos.Any(a => a.Nombre == "Carlos")).ToList()) {
                Console.WriteLine($"{item.Nombre} {item.Apellidos}");
            }

            Console.WriteLine($"----------------------------------");
            alumnos.Clear();
            CargaAlumnos(alumnos);
            foreach (var item in alumnos) {
                Console.WriteLine($"{item.Id}\t{item.Nombre}{(item.Nombre.Length < 8 ? "\t" : "")}\t{item.Apellidos}{(item.Apellidos.Length < 8 ? "\t" : "")}\t{item.Edad}");
            }
            foreach (var item in alumnos
                    .Where(o => o.Nombre.StartsWith("A"))
                    .OrderByDescending(o => o.Apellidos)
                    .Take(5)
                    .Select(o => new { nombre = $"{o.Nombre} {o.Apellidos}" })
                    .ToList()) {
                Console.WriteLine($"{item.nombre}");
            }
            GuardaAlumnos(alumnos
                    .Where(o => o.Nombre.StartsWith("A"))
                    .OrderByDescending(o => o.Apellidos).ToList());
            //var q = alumnos
            //        .Where(o => o.Nombre.StartsWith("A"));
            //q = q.OrderByDescending(o => o.Apellidos);
            ////q = q.Take(2)
            ////        .Select(o => new { nombre = $"{o.Nombre} {o.Apellidos}" });
            //foreach (var item in q.ToList()) {
            //    Console.WriteLine($"{item.Nombre}");
            //}

        }
        static void kkk(string[] args) {
            var ele = new Elemento<int>(1, "Algo");
            ele.Key = 1;
            var eleStr = new Elemento<string>("uno", "unos");
            var ele2 = new Elemento<int>(1, "Algo");

            //Tablero t = ...;
            //t.ponPieza(Fila, Columna, Pieza);
            //t[Fila, Columna] = Pieza;
            //p = t.damePieza(Fila, Columna);
            //p = t[Fila, Columna];

            int nuevo = 5; int año = 11, estado = 0;
            double d = 1;
            const int MAX = 5;
            const int PENDIENTE = MAX * 2;
            string cad = "";
            object o = null;
            string[] t = { "uno", "dos", "tres" };
            DiasLaborales dia = DiasLaborales.Lunes;
            if (dia == DiasLaborales.Lunes) { }

            if (estado == PENDIENTE) {
                nuevo = año * 5;
            } else if (estado == 1) {

            } else {

            }

            nuevo = Math.Abs(-5);
            nuevo = Abs(-5);

            switch (estado) {
                case 1:
                    //...
                    //break;
                    goto default;
                case 2:
                case 3:
                    // ...
                    break;

                default:

                    break;
            }
            o = "hola";
            try {
                d = d / 0;
                cad = o.ToString();
                //...
                cad = t[2];
                //kk();
            } catch (NullReferenceException e) {
                Console.WriteLine(e.Message);
            } catch (IndexOutOfRangeException e) {
                Console.WriteLine(e.Message);
                //} catch (Exception e) {
                //    Console.WriteLine(e.Message);
            } finally {
                Console.WriteLine("adios");
            }
            cad = "FIN";

            for (var i = 0; i < t.Length; i++) {
                Console.WriteLine(t[i]);
            }
            foreach (var item in t) {
                if (item.EndsWith("s")) {
                    Console.WriteLine(item.ToUpper());
                    continue;
                }
                Console.WriteLine(item);
            }

            corto.Persona persona = new Majorel.Demos.Cursos.Alumno("Carmelo", "Coton");
            persona.Id = 1;
            corto.Persona alumno = new Majorel.Demos.Cursos.Alumno("Carmeloooooo", "Coton");
            alumno.Id = 1;
            cad = "clase";
            persona.Saluda("tu");
            persona.Saluda(saludo: "Que hay", nombre: cad);
            persona.Saluda("cansino", 3, "Que hay");
            persona.Saluda("Carlos", "Antonio", "Alberto");
            persona.Saluda(t);
            Console.WriteLine(cad);
            persona.Cambia(ref cad);
            cad = persona.NombreCompleto();
            Console.WriteLine(cad);
            persona.NombreLargo = "Pepito Grillo";
            cad = persona.NombreCompleto();
            Console.WriteLine(cad);
            Console.WriteLine(persona.Nombre);
            Console.WriteLine(persona.ToString());
            if (alumno.Equals(persona))
                Console.WriteLine("Son iguales");
            else
                Console.WriteLine("Son distintos");
            //persona.Nombre = null;

            //            Color color = null;
            Biblioteca.Color color = null;

        }

        static void kk() {
            try {
                kk(null as string);
                Console.WriteLine("Hago algo");
            } finally {
                Console.WriteLine("Paso de todo");
            }
        }

        static void kk(string arg) {
            if (arg == null)
                throw new InvalidOperationException("Me falta la cadena");
            // ...
        }
        static void kk(string[] args) {
            int nuevo = 5; int año = 11;
#if DEBUG
            nuevo = 0;
#else
            nuevo = 11;
#endif
            Console.WriteLine("Hola mundo");
            Console.WriteLine(@"c:\nada\todo");
            Console.WriteLine("El valor " + (año > 0 ? año.ToString() : "sin año") + " es nuevo \x0169 \u00A9");
            Console.WriteLine($"El valor {nuevo + año} es nuevo  © ");
            var p = new Program();
            //p.AFichNom();
            //p.AbrirElFicheroDeNominas(1, 2);
            //p.abrirElFicheroDeNominas(1, 2);
            p.m((decimal)4);
            int i = 2;
            long l = 1111;
            i = (int)l;

            Nullable<int> ii = null;
            Object o = i; // o = new Int(4);
            i = (int)o; // i = o.value;
            var cad = i.ToString();
            o = cad;
            cad = (string)o;
            o = null;
            if (o != null && o.ToString() != null && o.ToString().ToUpper() != null
                && o.ToString().ToUpper().Trim() == "OK")
                cad = o.ToString();
            if (o?.ToString()?.ToUpper()?.Trim() == "OK")
                cad = o.ToString();
            if ((o ?? "").ToString()?.ToUpper()?.Trim() == "OK")
                cad = o.ToString();

            i = int.Parse(cad);

            if (o is string)
                cad = o as string;
            int j, estado = 1;
            i = 1;
            i = i + 1;
            i += 1;
            i++;
            j = ++i;
            j = i++;

            dynamic x = i / j;
            x.x();

            const int MAX = 5;
            const int PENDIENTE = MAX * 2;

            if (estado == PENDIENTE) {

            }

            if (estado == 1) {

            }



        }
        #region Propiedades
        #endregion
        #region Métodos
        // Abre El Fichero De Nominas
        public void AFichNom() {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Abre El Fichero De Nominas
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <param name="b">ssssss</param>
        /// <returns>dddd</returns>
        public string AbrirElFicheroDeNominas(int nombre, int b) {
            throw new System.NotImplementedException();
        }

        public void m(decimal i) { }
        public void m(int i, int j) { }
        public void m(float i) { }

        #endregion
    }
}
