using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            Menu(hospital);
        }

        static void Menu(Hospital hospital)
        {
            while (true)
            {
                Console.WriteLine("----- Menu -----");
                Console.WriteLine("1. Crear Medico");
                Console.WriteLine("2. Crear Paciente");
                Console.WriteLine("3. Crear Personal Auxiliar");
                Console.WriteLine("4. Asignar Paciente a Medico");
                Console.WriteLine("5. Asignar Medico a Paciente");
                Console.WriteLine("6. Ver Pacientes de un Medico");
                Console.WriteLine("7. Ver Medicos de un Paciente");
                Console.WriteLine("8. Opciones de listado");
                Console.WriteLine("9. Desasignar Paciente de Médico");
                Console.WriteLine("10. Desasignar Médico de Paciente");
                Console.WriteLine("11. Eliminar Personal Auxiliar");
                Console.WriteLine("12. Eliminar Medico");
                Console.WriteLine("13. Eliminar Paciente");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        hospital.CrearMedico();
                        break;
                    case "2":
                        hospital.CrearPaciente();
                        break;
                    case "3":
                        hospital.CrearPersonalAuxiliar();
                        break;
                    case "4":
                        hospital.AsignarPacienteAMedico();
                        break;
                    case "5":
                        hospital.AsignarMedicoAPaciente();
                        break;
                    case "6":
                        hospital.VerPacientesDeMedico();
                        break;
                    case "7":
                        hospital.VerMedicosDePaciente();
                        break;
                    case "8":
                        hospital.OpcionesDeListado(); 
                        break;
                    case "9":
                        hospital.DesasignarPacienteDeMedico();
                        break;
                    case "10":
                        hospital.DesasignarMedicoDePaciente();
                        break;
                    case "11":
                        hospital.EliminarPersonalAuxiliar();
                        break;
                    case "12":
                        hospital.EliminarMedico();
                        break;
                    case "13":
                        hospital.EliminarPaciente();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }
        
        
    }
}
