using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {

        private readonly AppContext _appContext;

        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }

        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado == null)
                return;

            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetAllPaciente()
        {
            return _appContext.Pacientes;
        }

        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            return pacienteEncontrado;
        }

        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;

                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }

        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
                if (medicoEncontrado != null)
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _appContext.SaveChanges();
                }
                return medicoEncontrado;
            }
            return null;
        }

        Enfermera IRepositorioPaciente.AsignarEnfermera(int idPaciente, int idEnfermera)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var enfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(e => e.Id == idEnfermera);
                if (enfermeraEncontrada != null)
                {
                    pacienteEncontrado.Enfermera = enfermeraEncontrada;
                    _appContext.SaveChanges();
                }
                return enfermeraEncontrada;
            }
            return null;
        }

        FamiliarDesignado IRepositorioPaciente.AsignarFamiliar(int idPaciente, int idFamiliarDesignado)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var familiarDesignadoEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == idFamiliarDesignado);
                if (familiarDesignadoEncontrado != null)
                {
                    pacienteEncontrado.Familiar = familiarDesignadoEncontrado;
                    _appContext.SaveChanges();
                }
                return familiarDesignadoEncontrado;
            }
            return null;
        }

        SignoVital IRepositorioPaciente.AsignarSignoVital(int idPaciente, int idSignoVital)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var signoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(s => s.Id == idSignoVital);
                if (signoVitalEncontrado != null)
                {
                    pacienteEncontrado.SignoVital = signoVitalEncontrado;
                    _appContext.SaveChanges();
                }
                return signoVitalEncontrado;
            }
            return null;
        }

        Historia IRepositorioPaciente.AsignarHistoria(int idPaciente, int idHistoria)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var historiaEncontrada = _appContext.Historias.FirstOrDefault(s => s.Id == idHistoria);
                if (historiaEncontrada != null)
                {
                    pacienteEncontrado.Historia = historiaEncontrada;
                    _appContext.SaveChanges();
                }
                return historiaEncontrada;
            }
            return null;
        }

    }

}
