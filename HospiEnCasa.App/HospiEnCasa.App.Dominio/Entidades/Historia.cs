using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Dominio
{
    public class Historia
    {
        public int Id { get; set; }
        public string Diagnostico { get; set; }
        public string Entorno { get; set; }
        public List<SugerenciaCuidado> SugerenciasCuidado { get; set; }
    }
}