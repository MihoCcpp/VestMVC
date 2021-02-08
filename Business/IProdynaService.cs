using System.Collections.Generic;
using Prodyna.Models.Domain;

namespace Prodyna.Business
{
    public interface IProdynaService
    {
        List<Models.Domain.Vesti> GetAllVesti();

        Vesti GetVest(int id);

        bool AddVest(Vesti vest);

        bool UpdateVest(Vesti vestUpdate);
    }
}
