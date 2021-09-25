using System;
using System.Collections.Generic;

using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        Paciente AddPaciente(Paciente paciente);
        void DeletePaciente(int idPaciente);
        IEnumerable<Paciente> GetAllPaciente();
        Paciente GetPaciente(int idPaciente);
        Paciente UpdatePaciente(Paciente paciente);
    }
}
