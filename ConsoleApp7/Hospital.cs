using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Hospital
    {
        private List<Medico> medicos;
        private List<Paciente> pacientes;
        private List<PersonalAuxiliar> personalAuxiliar;

        public Hospital()
        {
            medicos = new List<Medico>();
            pacientes = new List<Paciente>();
            personalAuxiliar = new List<PersonalAuxiliar>();
        }

        public void CrearMedico()
        {
            Console.WriteLine("Ingrese el nombre del medico");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del medico");
            string apellido = Console.ReadLine();

            while (true)
            {
                if (!EsNombreApellidoValido(nombre) || !EsNombreApellidoValido(apellido))
                {
                    Console.WriteLine("Nombre o apellido no válido. Por favor, intente de nuevo.");
                    Console.Write("Ingrese el nombre del médico: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido del médico: ");
                    apellido = Console.ReadLine();
                }
                else if (medicos.Exists(m => m.Nombre == nombre && m.Apellido == apellido))
                {
                    Console.WriteLine("Ya existe un médico con ese nombre y apellido. Por favor, ingrese uno diferente.");
                    Console.Write("Ingrese el nombre del médico: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido del médico: ");
                    apellido = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Medico nuevoMedico = new Medico(nombre, apellido);
            medicos.Add(nuevoMedico);
            Console.WriteLine($"Medico {nombre} {apellido} creado con ID: {nuevoMedico.NumeroEmpleado}");

        }

        public void CrearPaciente()
        {
            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del paciente: ");
            string apellido = Console.ReadLine();

            while (true)
            {
                if (!EsNombreApellidoValido(nombre) || !EsNombreApellidoValido(apellido))
                {
                    Console.WriteLine("Nombre o apellido no válido. Por favor, intente de nuevo.");
                    Console.Write("Ingrese el nombre del paciente: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido del paciente: ");
                    apellido = Console.ReadLine();
                }
                else if (pacientes.Exists(p => p.Nombre == nombre && p.Apellido == apellido))
                {
                    Console.WriteLine("Ya existe un paciente con ese nombre y apellido. Por favor, ingrese uno diferente.");
                    Console.Write("Ingrese el nombre del paciente: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido del paciente: ");
                    apellido = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Paciente nuevoPaciente = new Paciente(nombre, apellido);
            pacientes.Add(nuevoPaciente);
            Console.WriteLine($"Paciente {nombre} {apellido} creado con ID: {nuevoPaciente.NumeroPaciente}");
        }

        public void CrearPersonalAuxiliar()
        {
            Console.Write("Ingrese el nombre del personal auxiliar: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del personal auxiliar: ");
            string apellido = Console.ReadLine();

            while (true)
            {
                if (!EsNombreApellidoValido(nombre) || !EsNombreApellidoValido(apellido))
                {
                    Console.WriteLine("Nombre o apellido no válido. Por favor, intente de nuevo.");
                    Console.Write("Ingrese el nombre del personal auxiliar: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido del personal auxiliar: ");
                    apellido = Console.ReadLine();
                }
                else if (personalAuxiliar.Exists(p => p.Nombre == nombre && p.Apellido == apellido))
                {
                    Console.WriteLine("Ya existe un personal auxiliar con ese nombre y apellido. Por favor, ingrese uno diferente.");
                    Console.Write("Ingrese el nombre del personal auxiliar: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido del personal auxiliar: ");
                    apellido = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Seleccione el departamento del personal auxiliar:");
            foreach (var dept in Enum.GetValues(typeof(Departamento)))
            {
                Console.WriteLine($"{(int)dept}. {dept}");
            }

            if (!int.TryParse(Console.ReadLine(), out int deptSelection) ||
                !Enum.IsDefined(typeof(Departamento), deptSelection))
            {
                Console.WriteLine("Selección de departamento no válida. Operación cancelada.");
                return;
            }

            Departamento departamento = (Departamento)deptSelection;

            PersonalAuxiliar nuevoPersonalAuxiliar = new PersonalAuxiliar(nombre, apellido, departamento);
            personalAuxiliar.Add(nuevoPersonalAuxiliar);
            Console.WriteLine($"Personal auxiliar {nombre} {apellido} creado con ID: {nuevoPersonalAuxiliar.NumeroEmpleado}, Departamento: {departamento}");
        }


        public void AsignarPacienteAMedico()
        {
            Paciente paciente = EncontrarPaciente();
            Medico medico = EncontrarMedico();

            if (medico.Pacientes.Contains(paciente))
                Console.WriteLine("Este paciente ya está siendo atendido por este médico.");

            else
            {
                medico.AsignarPaciente(paciente);
                Console.WriteLine("Paciente asignado al medico correctamente.");
            }
        }

        public void AsignarMedicoAPaciente()
        {
            Medico medico = EncontrarMedico();
            Paciente paciente = EncontrarPaciente();

            if (paciente.Medicos.Contains(medico))
                Console.WriteLine("Este médico ya esta atendiendo a este paciente");
            else
            {
                paciente.AsignarMedico(medico);
                Console.WriteLine("Medico asignado al paciente");
            }
        }

        public void VerPacientesDeMedico()
        {
            Medico medico = EncontrarMedico();

            if (medico != null)
            {
                Console.WriteLine($"Pacientes atendidos por {medico.Nombre} {medico.Apellido}: ");
                foreach (var paciente in medico.Pacientes)
                {
                    Console.WriteLine($"\t{paciente.Nombre} {paciente.Apellido} (ID: {paciente.NumeroPaciente})");
                }
            }
        }

        public void VerMedicosDePaciente()
        {
            Paciente paciente = EncontrarPaciente();

            if (paciente != null)
            {
                Console.WriteLine($"Medicos que atienden al paciente {paciente.Nombre} {paciente.Apellido}:");
                foreach (var medico in paciente.Medicos)
                {
                    Console.WriteLine($"\t{medico.Nombre} {medico.Apellido} (ID: {medico.NumeroEmpleado})");
                }
            }
        }

        public void DesasignarPacienteDeMedico()
        {
            Medico medico = EncontrarMedico();
            if (medico != null)
            {
                Paciente paciente = EncontrarPacienteEnMedico(medico);
                if (paciente != null)
                {
                    medico.DesasignarPaciente(paciente);
                    Console.WriteLine($"Paciente {paciente.Nombre} {paciente.Apellido} desasignado del médico {medico.Nombre} {medico.Apellido} correctamente.");
                }
            }
        }

        public void DesasignarMedicoDePaciente()
        {
            Paciente paciente = EncontrarPaciente();
            if(paciente != null)
            {
                Medico medico = EncontrarMedicoEnPaciente(paciente);
                if (medico != null)
                {
                    paciente.DesasignarMedico(medico);
                    Console.WriteLine($"Medico {medico.Nombre} {medico.Apellido} desasignado del paciente {paciente.Nombre} {paciente.Apellido} correctamente.");
                }
            }
        }
        private Medico EncontrarMedico()
        {
            Medico medico = null;
            while (medico == null)
            {
                Console.WriteLine("¿Cómo desea buscar al médico?");
                Console.WriteLine("1. Por ID");
                Console.WriteLine("2. Por nombre y apellido");
                Console.Write("Seleccione una opción: ");
                string opcionMedico = Console.ReadLine();

                if (opcionMedico == "1")
                {
                    Console.Write("Ingrese el ID del médico: ");
                    if (int.TryParse(Console.ReadLine(), out int idMedico))
                    {
                        medico = medicos.Find(m => m.NumeroEmpleado == idMedico);
                        if (medico == null)
                        {
                            Console.WriteLine("Médico no encontrado. Por favor, intente de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID del médico no válido. Por favor, intente de nuevo.");
                    }
                }
                else if (opcionMedico == "2")
                {
                    Console.Write("Ingrese el nombre del médico: ");
                    string nombreMedico = Console.ReadLine();
                    Console.Write("Ingrese el apellido del médico: ");
                    string apellidoMedico = Console.ReadLine();

                    medico = medicos.Find(m => m.Nombre == nombreMedico && m.Apellido == apellidoMedico);
                    if (medico == null)
                    {
                        Console.WriteLine("Médico no encontrado. Por favor, intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                }
            }
            return medico;
        }
        private Paciente EncontrarPaciente()
        {
            Paciente paciente = null;
            while (paciente == null)
            {
                Console.WriteLine("¿Cómo desea buscar al paciente?");
                Console.WriteLine("1. Por ID");
                Console.WriteLine("2. Por nombre y apellido");
                Console.Write("Seleccione una opción: ");
                string opcionPaciente = Console.ReadLine();

                if (opcionPaciente == "1")
                {
                    Console.Write("Ingrese el ID del paciente: ");
                    if (int.TryParse(Console.ReadLine(), out int idPaciente))
                    {
                        paciente = pacientes.Find(p => p.NumeroPaciente == idPaciente);
                        if (paciente == null)
                        {
                            Console.WriteLine("Paciente no encontrado. Por favor, intente de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID del paciente no válido. Por favor, intente de nuevo.");
                    }
                }
                else if (opcionPaciente == "2")
                {
                    Console.Write("Ingrese el nombre del paciente: ");
                    string nombrePaciente = Console.ReadLine();
                    Console.Write("Ingrese el apellido del paciente: ");
                    string apellidoPaciente = Console.ReadLine();

                    paciente = pacientes.Find(p => p.Nombre == nombrePaciente && p.Apellido == apellidoPaciente);
                    if (paciente == null)
                    {
                        Console.WriteLine("Paciente no encontrado. Por favor, intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                }
            }
            return paciente;
        }

        private PersonalAuxiliar EncontrarPersonalAuxiliar()
        {
            PersonalAuxiliar personal = null;
            while (personal == null)
            {
                Console.WriteLine("¿Cómo desea buscar al personal auxiliar?");
                Console.WriteLine("1. Por ID");
                Console.WriteLine("2. Por nombre y apellido");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.Write("Ingrese el ID del personal auxiliar: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        personal = personalAuxiliar.Find(p => p.NumeroEmpleado == id);
                        if (personal == null)
                        {
                            Console.WriteLine("Personal auxiliar no encontrado. Por favor, intente de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID del personal auxiliar no válido. Por favor, intente de nuevo.");
                    }
                }
                else if (opcion == "2")
                {
                    Console.Write("Ingrese el nombre del personal auxiliar: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el apellido del personal auxiliar: ");
                    string apellido = Console.ReadLine();

                    personal = personalAuxiliar.Find(p => p.Nombre == nombre && p.Apellido == apellido);
                    if (personal == null)
                    {
                        Console.WriteLine("Personal auxiliar no encontrado. Por favor, intente de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                }
            }
            return personal;
        }

        private Medico EncontrarMedicoEnPaciente(Paciente paciente)
        {
            Console.WriteLine("Seleccione el médico a desasignar:");
            for (int i = 0; i < paciente.Medicos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {paciente.Medicos[i].Nombre} {paciente.Medicos[i].Apellido} (ID: {paciente.Medicos[i].NumeroEmpleado})");
            }
            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= paciente.Medicos.Count)
            {
                return paciente.Medicos[seleccion - 1];
            }
            Console.WriteLine("Selección no válida. Por favor, intente de nuevo.");
            return null;
        }

        private Paciente EncontrarPacienteEnMedico(Medico medico)
        {
            Console.WriteLine("Seleccione el paciente a desasignar:");
            for (int i = 0; i < medico.Pacientes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {medico.Pacientes[i].Nombre} {medico.Pacientes[i].Apellido} (ID: {medico.Pacientes[i].NumeroPaciente})");
            }
            if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= medico.Pacientes.Count)
            {
                return medico.Pacientes[seleccion - 1];
            }
            Console.WriteLine("Selección no válida. Por favor, intente de nuevo.");
            return null;
        }

        public void EliminarMedico()
        {
            Medico medico = EncontrarMedico();
            if (medico != null)
            {
                medicos.Remove(medico);
                Console.WriteLine($"Médico {medico.Nombre} {medico.Apellido} eliminado correctamente.");
            }
        }

        public void EliminarPaciente()
        {
            Paciente paciente = EncontrarPaciente();
            if (paciente != null)
            {
                pacientes.Remove(paciente);
                Console.WriteLine($"Paciente {paciente.Nombre} {paciente.Apellido} eliminado correctamente.");
            }
        }

        public void EliminarPersonalAuxiliar()
        {
            PersonalAuxiliar personal = EncontrarPersonalAuxiliar();
            if (personal != null)
            {
                personalAuxiliar.Remove(personal);
                Console.WriteLine($"Personal auxiliar {personal.Nombre} {personal.Apellido} eliminado correctamente.");
            }
        }

        public void OpcionesDeListado()
        {
            Console.WriteLine("Opciones de Listado");
            Console.WriteLine("1. Listar todos los médicos");
            Console.WriteLine("2. Listar todos los pacientes");
            Console.WriteLine("3. Listar todo el personal auxiliar");
            Console.WriteLine("4. Listar todos los empleados");
            Console.WriteLine("5. Listar todas las personas");
            Console.Write("Seleccione una opción: ");

            string opcionListado = Console.ReadLine();

            switch (opcionListado)
            {
                case "1":
                    ListarMedicos();
                    break;
                case "2":
                    ListarPacientes();
                    break;
                case "3":
                    ListarPersonalAuxiliar();
                    break;
                case "4":
                    ListarEmpleados();
                    break;
                case "5":
                    ListarPersonas();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }

        public void ListarMedicos()
        {
            Console.WriteLine("Listado de Médicos:");
            foreach (var medico in medicos)
            {
                Console.WriteLine(medico);
            }
        }

        public void ListarPacientes()
        {
            Console.WriteLine("Listado de Pacientes:");
            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente);
            }
        }

        public void ListarPersonalAuxiliar()
        {
            Console.WriteLine("Listado de Personal Auxiliar:");
            foreach (var auxiliar in personalAuxiliar)
            {
                Console.WriteLine(auxiliar);
            }
        }

        public void ListarEmpleados()
        {
            Console.WriteLine("Listado de Empleados:");
            Console.WriteLine("MEDICOS:");
            foreach (var medico in medicos)
            {
                Console.WriteLine(medico);
            }
            Console.WriteLine("PERSONAL AUXILIAR:");
            foreach (var auxiliar in personalAuxiliar)
            {
                Console.WriteLine(auxiliar);
            }
        }

        public void ListarPersonas()
        {
            Console.WriteLine("Listado de Personas:");
            Console.WriteLine("MEDICOS:");
            foreach (var medico in medicos)
            {
                Console.WriteLine(medico);
            }
            Console.WriteLine("PERSONAL AUXILIAR:");
            foreach (var auxiliar in personalAuxiliar)
            {
                Console.WriteLine(auxiliar);
            }
            Console.WriteLine("PACIENTES:");
            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente);
            }
        }

        private bool EsNombreApellidoValido(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }
    }
}
