using BreakHomework_CThomason.Data;
using BreakHomework_CThomason.Models;

namespace BreakHomework_CThomason.Repository
{
    public class WrestlerRepository : IWrestlerRepository
    {
        private readonly AppDbContext _db; 

        public WrestlerRepository(AppDbContext db)
        {
            _db = db; 
        }
        public List<WrestlerModel> GetAll()
        {
            return _db.Wrestlers.ToList(); 
        }
        public WrestlerModel? GetById(int id)
        {
            return _db.Wrestlers.FirstOrDefault(w => w.Id == id);
        }
        public WrestlerModel Add(WrestlerModel newWrestler)
        {
            _db.Wrestlers.Add(newWrestler);
            _db.SaveChanges();
            return newWrestler;
        }
        public void Update(WrestlerModel changedWrestler)
        {
            _db.SaveChanges(); 
        }

        public void Delete(WrestlerModel wrestler)
        {
            _db.Wrestlers.Remove(wrestler);
            _db.SaveChanges(); 
        }


    }
}