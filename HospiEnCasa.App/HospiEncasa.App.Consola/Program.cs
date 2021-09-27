using System;
using System.Collections.Generic;
using System.Linq;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {

        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioEnfermera _repoEnfermera = new RepositorioEnfermera(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        private static IRepositorioFamiliarDesignado _repoFamiliarDesignado = new RepositorioFamiliarDesignado(new Persistencia.AppContext());
        private static IRepositorioSignoVital _repoSignoVital = new RepositorioSignoVital(new Persistencia.AppContext());


        static void Main(string[] args)
        {

            Console.WriteLine("Hello World Entity Framewerk!");

            // Pacientes
            // AddPaciente();
            BuscarPaciente(1);

            // Enfermeras
            // AddEnfermera();
            BuscarEnfermera(2);

            // Medicos
            // AddMedico();
            BuscarMedico(3);

            // FamiliaresDesignados
            // AddFamiliarDesignado();
            BuscarFamiliarDesignado(4);

            // SignosVitales
            // AddSignoVital();
            BuscarSignoVital(1);


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

        // Metodos de los FamiliaresDesignados
        private static void AddFamiliarDesignado()
        {
            var familiarDesignado = new FamiliarDesignado
            {
                Nombre = "Anna",
                Apellidos = "Petrovna",
                NumeroTelefono = "300654321",
                Genero = Genero.Femenino,
                Parentesco = "Madre",
                Correo = "ana.ptreovna@stpetesburg.com"
            };
            _repoFamiliarDesignado.AddFamiliarDesignado(familiarDesignado);
        }
        private static void BuscarFamiliarDesignado(int idFamiliarDesignado)
        {
            var familiarDesignado = _repoFamiliarDesignado.GetFamiliarDesignado(idFamiliarDesignado);
            Console.WriteLine(familiarDesignado.Nombre + " " + familiarDesignado.Apellidos);
        }

        // Métodos Signos Vitales
        private static void AddSignoVital()
        {
            var signoVital = new SignoVital
            {
                FechaHora = new DateTime(2021, 09, 27),
                Valor = 150.0F,
                TipoSigno = TipoSigno.TensionArterial
            };
            _repoSignoVital.AddSignoVital(signoVital);
        }
        private static void BuscarSignoVital(int idSignoVital)
        {
            var signoVital = _repoSignoVital.GetSignoVital(idSignoVital);
            Console.WriteLine($"{signoVital.TipoSigno}: {signoVital.Valor}");
        }
    }

}
