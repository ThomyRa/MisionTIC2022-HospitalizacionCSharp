using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {

        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioEnfermera _repoEnfermera = new RepositorioEnfermera(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World Entity Framewerk!");

            // Pacientes
            // AddPaciente();
            // BuscarPaciente(1);

            // Enfermeras
            // AddEnfermera();
            // BuscarEnfermera(2);

            // Medicos
            // AddMedico();
            BuscarMedico(4);


        }

        // Metodos de los pacientes
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Nicolay",
                Apellidos = "Perez",
                NumeroTelefono = "300123456",
                Genero = Genero.Masculino,
                Direccion = "Av. Siempre Viva 123",
                Longitud = 5.07062F,
                Latitud = -75.52290F,
                Ciudad = "Manizales",
                FechaNacimiento = new DateTime(1990, 04, 12)
            };
            _repoPaciente.AddPaciente(paciente);
        }
        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
        }

        // Metodos de las Enfermeras
        private static void AddEnfermera()
        {
            var enfermera = new Enfermera

            {
                Nombre = "Florence",
                Apellidos = "Nightingale",
                NumeroTelefono = "3000000000",
                Genero = Genero.Femenino,
                TarjetaProfesional = "0123",
                HorasLaborales = 40

            };
            _repoEnfermera.AddEnfermera(enfermera);
        }
        private static void BuscarEnfermera(int idEnfermera)
        {
            var enfermera = _repoEnfermera.GetEnfermera(idEnfermera);
            Console.WriteLine(enfermera.Nombre + " " + enfermera.Apellidos);
        }

        // Metodos de los doctores
        private static void AddMedico()
        {
            var medico = new Medico
            {
                Nombre = "John",
                Apellidos = "Snow",
                NumeroTelefono = "3000000000",
                Genero = Genero.Masculino,
                Especialidad = "Epidemiologo",
                Codigo = "001",
                RegistroRethus = "123456789"

            };
            _repoMedico.AddMedico(medico);
        }

        private static void BuscarMedico(int idMedico)
        {
            var medico = _repoMedico.GetMedico(idMedico);
            Console.WriteLine(medico.Nombre + " " + medico.Apellidos);
        }
    }

}
