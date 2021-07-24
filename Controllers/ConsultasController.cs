using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPrueba.Data;
using WebApplicationPrueba.Entities;

namespace WebApplicationPrueba.Controllers
{
    public class ConsultasController : Controller
    {
        readonly ApplicationDbContext _context;

        public ConsultasController(ApplicationDbContext applicarionDbContext)
        {
            _context = applicarionDbContext;
        }

        public IEnumerable<Departamento> Departamentos()
        {
            return _context.Departamentos;
        }
        public IEnumerable<Empleado> Empleados() 
        {
           

            IOrderedQueryable<Empleado> consulta = _context.Empleados.OrderBy(x=>x.Nombre); 
            List<Empleado> empleados = consulta.ToList(); //List<Empleado>
            var Sebas = empleados.Where(x => x.Nombre == "Rommel");   
            var menor = empleados[0].Salario; 
            foreach(var item in empleados) 
            {
                if(item.Salario < menor)
                {
                    menor = item.Salario;
                }
            }
            var menorRapido = empleados.Min(e => e.Salario);    
            var mayor = empleados.Min(e => e.Nacimiento);

            return empleados.OrderBy(e => e.NombreCompleto);
        }
        public IEnumerable<Empleado> EmpleadosPaginados(int pagina,int registrosPorPagina)
        {
            var salto = (pagina - 1) * registrosPorPagina; 
           return this._context.Empleados.Skip(salto).Take(registrosPorPagina);

        }
        public object Ejemplo1()
        {
            System.DateTime fechaConsulta = new System.DateTime(1999, 1, 1);

            var consulta1 = from e in _context.Empleados
                            where e.Nacimiento > fechaConsulta
                            select e;

            var consulta2 = _context.Empleados 
                .Where(e => e.Nacimiento > fechaConsulta)
                .Select(e => e);

            return null;
            
        }

        public void Ejemplo2()
        {
            var persona = new 
            {
                Saludo = "Hola Mundo",
                Estado = "Me Encuentro Muy BIen"
            };

            var consulta = from e in _context.Empleados
                           join d in _context.Departamentos
                           on e.DepartamentoId equals d.DepartamentoId
                           select new { 
                           NombreCompleto = $"{e.Nombre} {e.Apellido}",
                           Departamento = d.Nombre
                           };
            var consulta1 = _context.Empleados
                .Include(e => e.Departamento)
                .Select(e=> new { 
                 Name =e.Nombre, 
                 Department = e.Departamento.DepartamentoId 
                });
           
                          
        }

        public void Ejemplo3()
        {
            using (ApplicationDbContext mainContext= new ApplicationDbContext())  
            {
                mainContext.Empleados
                    .Include(e=> e.Departamento)
                    .Select()
            }
        }
    }
}

/*class LINQQueryExpressions
{
    static void Main(string[]args)
    {
        List<string> nombres = new List<string> { "david", "marcos", "Andrea", "Julio" };
        List<string> nombres1 = new List<string> { "santiago", "David", "blanca", "marcos" };

        var query = from n in nombres
                    join n1 in nombres1
                    on n equals n1
                    select n;

        var query1 = nombres.Select(n => n);

        foreach (var item in query)
        {
            Console.WriteLine("Nombre: " + item);

        }
        Console.ReadLine();
    }*/


