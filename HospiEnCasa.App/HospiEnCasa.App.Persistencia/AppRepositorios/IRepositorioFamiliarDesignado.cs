using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioFamiliarDesignado
    {
        FamiliarDesignado AddFamiliarDesignado(FamiliarDesignado familiarDesignado);
        void DeleteFamiliarDesignado(int idFamiliarDesignado);
        IEnumerable<FamiliarDesignado> GetAllFamiliarDesignado();
        FamiliarDesignado GetFamiliarDesignado(int idFamiliarDesignado);
        FamiliarDesignado UpdateFamiliarDesignado(FamiliarDesignado familiarDesignado);
    }
}