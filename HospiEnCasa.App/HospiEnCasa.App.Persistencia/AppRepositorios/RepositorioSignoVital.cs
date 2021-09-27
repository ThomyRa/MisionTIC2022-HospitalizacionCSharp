using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSignoVital : IRepositorioSignoVital
    {
        private readonly AppContext _appContext;

        public RepositorioSignoVital(AppContext appContext)
        {
            _appContext = appContext;
        }

        SignoVital IRepositorioSignoVital.AddSignoVital(SignoVital signoVital)
        {
            var signoVitalAdicionado = _appContext.SignosVitales.Add(signoVital);
            _appContext.SaveChanges();
            return signoVitalAdicionado.Entity;
        }
        void IRepositorioSignoVital.DeleteSignoVital(int idSignoVital)
        {
            var signoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(p => p.Id == idSignoVital);
            if (signoVitalEncontrado == null)
                return;

            _appContext.SignosVitales.Remove(signoVitalEncontrado);
            _appContext.SaveChanges();
        }
        IEnumerable<SignoVital> IRepositorioSignoVital.GetAllSignoVital()
        {
            return _appContext.SignosVitales;
        }

        SignoVital IRepositorioSignoVital.GetSignoVital(int idSignoVital)
        {
            var signoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(p => p.Id == idSignoVital);
            return signoVitalEncontrado;
        }
        SignoVital IRepositorioSignoVital.UpdateSignoVital(SignoVital signoVital)
        {
            var signoVitalEncontrado = _appContext.SignosVitales.FirstOrDefault(p => p.Id == signoVital.Id);
            if (signoVitalEncontrado != null)
            {
                signoVitalEncontrado.FechaHora = signoVital.FechaHora;
                signoVitalEncontrado.Valor = signoVital.Valor;
                signoVitalEncontrado.TipoSigno = signoVital.TipoSigno;

                _appContext.SaveChanges();
            }
            return signoVitalEncontrado;
        }
    }
}