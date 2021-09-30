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
        Medico AsignarMedico(int idPaciente, int idMedico);
        Enfermera AsignarEnfermera(int idPaciente, int idEnfermera);
        FamiliarDesignado AsignarFamiliar(int idPaciente, int idFamiliarDesignado);
        SignoVital AsignarSignoVital(int idPaciente, int idSignoVital);
        Historia AsignarHistoria(int idPaciente, int idHistoria);
    }
}
