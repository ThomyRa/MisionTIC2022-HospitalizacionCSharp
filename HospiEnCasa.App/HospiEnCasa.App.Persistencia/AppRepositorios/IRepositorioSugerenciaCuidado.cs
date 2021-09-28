using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSugerenciaCuidado
    {
        SugerenciaCuidado AddSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado);
        void DeleteSugerenciaCuidado(int idSugerenciaCuidado);
        IEnumerable<SugerenciaCuidado> GetAllSugerenciaCuidado();
        SugerenciaCuidado GetSugerenciaCuidado(int idSugerenciaCuidado);
        SugerenciaCuidado UpdateSugerenciaCuidado(SugerenciaCuidado sugerenciaCuidado);
    }
}