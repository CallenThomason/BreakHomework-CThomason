using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakHomework_CThomason.Models;

namespace BreakHomework_CThomason.Repository
{
    public interface IWrestlerRepository
    {
        List<WrestlerModel> GetAll(); 
        WrestlerModel? GetById(int id);
        WrestlerModel Add(WrestlerModel newWrestler); 
        void Update(WrestlerModel changedWrestler);
        void Delete(WrestlerModel wrestler); 

    }
}