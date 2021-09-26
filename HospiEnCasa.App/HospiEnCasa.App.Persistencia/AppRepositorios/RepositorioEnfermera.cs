using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioEnfermera : IRepositorioEnfermera
    {

        private readonly AppContext _appContext;

        public RepositorioEnfermera(AppContext appContext)
        {
            _appContext = appContext;
        }

        Enfermera IRepositorioEnfermera.AddEnfermera(Enfermera enfermera)
        {
            var enfermeraAdicionada = _appContext.Enfermeras.Add(enfermera);
            _appContext.SaveChanges();
            return enfermeraAdicionada.Entity;
        }

        void IRepositorioEnfermera.DeleteEnfermera(int idEnfermera)
        {
            var enfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(p => p.Id == idEnfermera);
            if (enfermeraEncontrada == null)
                return;

            _appContext.Enfermeras.Remove(enfermeraEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Enfermera> IRepositorioEnfermera.GetAllEnfermera()
        {
            return _appContext.Enfermeras;
        }

        Enfermera IRepositorioEnfermera.GetEnfermera(int idEnfermera)
        {
            var enfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(p => p.Id == idEnfermera);
            return enfermeraEncontrada;
        }

        Enfermera IRepositorioEnfermera.UpdateEnfermera(Enfermera enfermera)
        {

            var enfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(p => p.Id == enfermera.Id);
            if (enfermeraEncontrada != null)
            {
                enfermeraEncontrada.Nombre = enfermera.Nombre;
                enfermeraEncontrada.Apellidos = enfermera.Apellidos;
                enfermeraEncontrada.NumeroTelefono = enfermera.NumeroTelefono;
                enfermeraEncontrada.Genero = enfermera.Genero;
                enfermeraEncontrada.TarjetaProfesional = enfermera.TarjetaProfesional;
                enfermeraEncontrada.HorasLaborales = enfermera.HorasLaborales;

                _appContext.SaveChanges();
            }
            return enfermeraEncontrada;
        }

    }
}