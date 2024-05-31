using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class PersonalAuxiliar : Empleado
    {
        public Departamento Departamento {  get; set; }

        public PersonalAuxiliar(string nombre, string apellido, Departamento departamento) : base(nombre, apellido)
        {
            Departamento = departamento;
        }

        public override string ToString()
        {
            return $"Personal Auxiliar: {Nombre} {Apellido}, ID: {NumeroEmpleado}, Departamento: {Departamento}";
        }
    }
}
