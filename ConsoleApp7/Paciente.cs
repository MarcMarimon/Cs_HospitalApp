using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Paciente : Persona
    {
        private static int ContadorPacientes = 0;
        public int NumeroPaciente;
        public List<Medico> Medicos { get; set; }

        public Paciente(string nombre, string apellido) :base(nombre,apellido)
        {
            Medicos = new List<Medico>();
            NumeroPaciente = ++ContadorPacientes;
        }

        public void AsignarMedico(Medico medico)
        {
            if (!Medicos.Contains(medico))
            {
                Medicos.Add(medico);
                medico.AsignarPaciente(this);
            }
        }
        public void DesasignarMedico(Medico medico)
        {
            if (Medicos.Contains(medico))
            {
                Medicos.Remove(medico);
                medico.DesasignarPaciente(this);
            }
        }

        public override string ToString()
        {
            return $"Paciente: {Nombre} {Apellido}, ID: {NumeroPaciente}";
        }
    }
}
