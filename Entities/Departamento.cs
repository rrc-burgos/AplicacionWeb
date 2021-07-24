﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationPrueba.Entities
{
    public class Departamento
    {
        public int DepartamentoId {get; set;}
        public string Nombre {get; set;}
        public float Presupuesto {get; set;}
        public List<Empleado> Empleados {get; set;}
    }
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public int Cedula { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [NotMapped]
        public string NombreCompleto { get { return $"{Nombre} {Apellido},{Titulo}"; } }
        public float Salario { get; set; }
        public DateTime Nacimiento { get; set; }
        [NotMapped]
        public double Edad { get { return DateTime.Now.Subtract(Nacimiento).TotalDays / 365; } }
        [ForeignKey("Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }        
        public Conyuge Conyuge { get; set; }
        public List<Hijo> Hijo { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
