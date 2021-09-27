
using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSignoVital
    {
        SignoVital AddSignoVital(SignoVital signoVital);
        void DeleteSignoVital(int idSignoVital);
        IEnumerable<SignoVital> GetAllSignoVital();
        SignoVital GetSignoVital(int idSignoVital);
        SignoVital UpdateSignoVital(SignoVital signoVital);
    }
}