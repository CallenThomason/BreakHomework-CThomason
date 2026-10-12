
using BreakHomework_CThomason.Dtos; 
using BreakHomework_CThomason.Models;
using BreakHomework_CThomason.Repository; 

namespace BreakHomework_CThomason.Services
{
    public class WrestlerService : IWrestlerService
    {
        private readonly IWrestlerRepository _repository; 
        public WrestlerService(IWrestlerRepository repository)
        {
            _repository = repository; 
        }//end of constructor
        private static WrestlerResponseDto ToReadDto(WrestlerModel wrestler)
        {
            WrestlerResponseDto dto = new WrestlerResponseDto(); 
            dto.Id = wrestler.Id; 
            dto.RingName = wrestler.RingName; 
            dto.RealName = wrestler.RealName; 
            dto.Brand = wrestler.Brand; 
            dto.WeightClass = wrestler.WeightClass; 
            dto.Alignment = wrestler.Alignment; 
            dto.Finisher = wrestler.Finisher; 
            dto.Wins = wrestler.Wins; 
            dto.Losses = wrestler.Losses; 
            dto.DebutYear = wrestler.DebutYear; 
            dto.Status = wrestler.Status; 
            return dto; 
        }//end of ToReadDto
        public List<WrestlerResponseDto> GetAll()
        {
            return _repository.GetAll().Select(w => ToReadDto(w)).ToList(); 
        }//end of getall
        public WrestlerResponseDto? GetById(int id)
        {
            WrestlerModel? wrestler = _repository.GetById(id); 
            if(wrestler is null)
            {
                return null; 
            } //end if
            return ToReadDto(wrestler); 

        }//end of GetById

        public WrestlerResponseDto? Add(CreateWrestlerDto newWrestler)
        {
           
            if(
            (newWrestler.WeightClass != "Cruiseweight" && newWrestler.WeightClass != "Heavyweight" && newWrestler.WeightClass != "Super Heavyweight")
            ||(newWrestler.Alignment != "Face" && newWrestler.Alignment != "Heel")
            ||(newWrestler.Status != "Active" && newWrestler.Status != "Injured" && newWrestler.Status != "Retired")
            )
            {
                return null; 
            }
            WrestlerModel wrestler = new WrestlerModel();
            
           
            wrestler.RingName = newWrestler.RingName;
            wrestler.RealName = newWrestler.RealName;
            wrestler.Brand = newWrestler.Brand;
           
            wrestler.WeightClass = newWrestler.WeightClass;
            wrestler.Alignment = newWrestler.Alignment;
            wrestler.Finisher = newWrestler.Finisher;
            wrestler.Wins = newWrestler.Wins;
            wrestler.Losses = newWrestler.Losses;
            wrestler.DebutYear = newWrestler.DebutYear;
            wrestler.Status = newWrestler.Status;

           WrestlerModel addWrestler = _repository.Add(wrestler);
            return ToReadDto(addWrestler);
        }//end of create

        public bool Update(int id, UpdateWrestlerDto updatedWrestler)
        {
            WrestlerModel? wrestler = _repository.GetById(id);
            if(
            (updatedWrestler.WeightClass != "Cruiseweight" && updatedWrestler.WeightClass != "Heavyweight" && updatedWrestler.WeightClass != "Super Heavyweight")
            ||(updatedWrestler.Alignment != "Face" && updatedWrestler.Alignment != "Heel")
            ||(updatedWrestler.Status != "Active" && updatedWrestler.Status != "Injured" && updatedWrestler.Status != "Retired"))
            {
                return false; 
            }
            wrestler.RingName = updatedWrestler.RingName;
            wrestler.RealName = updatedWrestler.RealName;
            wrestler.Brand = updatedWrestler.Brand;
            wrestler.WeightClass = updatedWrestler.WeightClass;
            wrestler.Alignment = updatedWrestler.Alignment;
            wrestler.Finisher = updatedWrestler.Finisher;
            wrestler.Wins = updatedWrestler.Wins;
            wrestler.Losses = updatedWrestler.Losses;
            wrestler.DebutYear = updatedWrestler.DebutYear;
            wrestler.Status = updatedWrestler.Status;

            _repository.Update(wrestler);
            return true;
        } //end of update

        public bool Delete(int id)
        {
            WrestlerModel? wrestler = _repository.GetById(id);
            if (wrestler != null)
            {
                _repository.Delete(wrestler);
                return true;
            }
            return false;
        }//end of delete
        public bool Turn(int id)
        {
            WrestlerModel? wrestler = _repository.GetById(id);
           
            if(wrestler.Status != "Active")
            {
                return false;
            }
            if(wrestler.Alignment == "Face")
            {
                wrestler.Alignment = "Heel";
            }
            else if(wrestler.Alignment == "Heel")
            {
                wrestler.Alignment = "Face";
            }
            _repository.Update(wrestler);
            return true;
        }//end of turn

       public bool Exists(CreateWrestlerDto wrestler)
        {
             bool exists = _repository.GetAll().Any(w => w.RingName.ToLower() == wrestler.RingName.ToLower() );
            if (exists)
            {
                return true; 
            }
            return false;
        }
         public bool Exists2(UpdateWrestlerDto wrestler)
        {
             bool exists = _repository.GetAll().Any(w => w.RingName.ToLower() == wrestler.RingName.ToLower() );
            if (exists)
            {
                return true; 
            }
            return false;
        }

    }//end of class
}//end of namespace