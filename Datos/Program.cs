using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos {
    class Program {
        static void Main(string[] args) {
            var db = new AdventureWorks2017Entities();

            foreach(var item in 
                db.Productos
                //.Where(p => p.MakeFlag && p.SafetyStockLevel == 800)
                //.Where(p => p.Subcategoria != null && p.Subcategoria.Categoria.Nombre.StartsWith("Clo") == true)
                .Where(p => p.Style != null)
                .OrderByDescending(p => p.ProductNumber)
                //.Skip(10)
                //.Take(10)
                .ToList()) {
                Console.WriteLine($"{item.ProductID}\t{item.Estilo}\t{item.Nombre}\t{item.ProductNumber} S->{item?.Subcategoria?.Name} C->{item?.Subcategoria?.Categoria?.Nombre}");
                //item.Descatalogar();
            }
            var cat = db.Categorias.FirstOrDefault(c => c.ProductCategoryID == 5);
            if(cat != null) {
                cat.Nombre = "esto se termina".ToUpper();
                //db.Categorias.Add(new Categoria() { Nombre = "ORM", ModifiedDate = DateTime.Now });
                db.SaveChanges();
            }
            Console.ReadLine();
        }
    }
}
