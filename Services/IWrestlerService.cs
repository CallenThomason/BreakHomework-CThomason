using BreakHomework_CThomason.Dtos; 

namespace BreakHomework_CThomason.Services
{
    public interface IWrestlerService
    {
         List<WrestlerResponseDto> GetAll();
         WrestlerResponseDto? GetById(int id);
         WrestlerResponseDto Add(CreateWrestlerDto newWrestler); 
        bool Update(int id, UpdateWrestlerDto updatedWrestler); 
        bool Delete(int id); 
         bool Turn(int id); 
         bool Exists(CreateWrestlerDto wrestler); 
         bool Exists2(UpdateWrestlerDto wrestler);
    }
}