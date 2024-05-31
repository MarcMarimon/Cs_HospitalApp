using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Medico : Empleado
    {
       
        public List<Paciente> Pacientes { get; set; }

        public Medico (string nombre, string apellido) :base(nombre, apellido)
        {
            Pacientes = new List<Paciente>();
            
        }

        public void AsignarPaciente (Paciente paciente)
        {
            if(!Pacientes.Contains(paciente))
            {
                Pacientes.Add(paciente);
                paciente.AsignarMedico(this);
            }
        }
        public void DesasignarPaciente(Paciente paciente)
        {
            if (Pacientes.Contains(paciente))
            {
                Pacientes.Remove(paciente);
                paciente.DesasignarMedico(this);
            }
        }
        public override string ToString()
        {
            return $"Medico: {Nombre} {Apellido}, ID: {NumeroEmpleado}";
        }
    }
}
