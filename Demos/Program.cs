using System;

namespace Demos {
    /// <summary>
    /// Mi primera clase
    /// </summary>
#if DEBUG
    public class Program {
#else
    class Program {
#endif
        static void Main(string[] args) {
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
            if(o != null && o.ToString() != null && o.ToString().ToUpper() != null 
                && o.ToString().ToUpper().Trim() == "OK")
                cad = o.ToString();
            if(o?.ToString()?.ToUpper()?.Trim() == "OK")
                cad = o.ToString();
            if((o ?? "").ToString()?.ToUpper()?.Trim() == "OK")
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

            if(estado == PENDIENTE) {

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
