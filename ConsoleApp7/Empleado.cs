using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Empleado : Persona
    {
        private static int ContadorEmpleados = 0;

        public int NumeroEmpleado;
        public Empleado(string nombre, string apellido) : base(nombre, apellido)
        {
            NumeroEmpleado = ++ContadorEmpleados;
        }
    }
}