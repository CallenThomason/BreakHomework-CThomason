using BreakHomework_CThomason.Services;
using BreakHomework_CThomason.Dtos; 
using Microsoft.AspNetCore.Mvc;


namespace BreakHomework_CThomason.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WrestlerController : ControllerBase
    {
        private readonly IWrestlerService _wrestlerService;

        public WrestlerController(IWrestlerService wrestlerService)
        {
            _wrestlerService = wrestlerService;
        }//end of constructor
        [HttpGet("GetAll")]
        public ActionResult<List<WrestlerResponseDto>> GetAll()
        {
            
            return Ok(_wrestlerService.GetAll());
        }//end of GetAll
        [HttpGet("GetById/{id}")]
        public ActionResult<WrestlerResponseDto> GetById(int id)
        {
            WrestlerResponseDto? wrestler = _wrestlerService.GetById(id);
            if(wrestler is null)
            {
                return NotFound($"No Wrestler with Id {id} was found.");
            }
            return Ok(wrestler);
        }//end of GetById
        [HttpPost("Add")]
        public ActionResult<WrestlerResponseDto> Add([FromBody] CreateWrestlerDto newWrestler)
        {

            WrestlerResponseDto? wrestler = _wrestlerService.Add(newWrestler);
            if (_wrestlerService.Exists(newWrestler))
            {
                return Conflict($"A wrestler with the name {newWrestler.RingName} already exists.");
            }
            if(wrestler is null)
            {
                return BadRequest("Failed to add wrestler. Make sure weightclass is 'Cruiseweight', 'Heavyweight', or 'Super Heavyweight'. Alignment is either 'Face' or 'Heel'. Status is either 'Active', 'Injured', or 'Retired'.");
            }
            return CreatedAtAction(nameof(GetById), new { id = wrestler.Id }, wrestler);
        }//end of post

        [HttpPut("Update/{id}")]
        public ActionResult<bool> Update(int id, [FromBody]UpdateWrestlerDto wrestler)
        {
             WrestlerResponseDto? wrestlerId = _wrestlerService.GetById(id);
            if(wrestlerId is null){
                return NotFound($"No Wrestler with Id {id} was found.");  
            }
           
            if (_wrestlerService.Exists2(wrestler))
            {
                return Conflict($"A wrestler with the name {wrestler.RingName} already exists.");
            }
             bool update = _wrestlerService.Update(id, wrestler);
            if(!update)
            {
                return BadRequest("Failed to update wrestler. Make sure weightclass is 'Cruiseweight', 'Heavyweight', or 'Super Heavyweight'. Alignment is either 'Face' or 'Heel'. Status is either 'Active', 'Injured', or 'Retired'.");
            }
            return NoContent(); 
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool delete = _wrestlerService.Delete(id);
            if (!delete)
            {
                return NotFound($"No Wrestler with Id {id} was found.");
            }
            return NoContent();
        }

        [HttpPatch("{id}/turn")]
        public ActionResult<bool> Turn(int id)
        {
            WrestlerResponseDto? wrestler = _wrestlerService.GetById(id);
            if(wrestler is null){
                return NotFound($"No Wrestler with Id {id} was found.");  
            }
            bool turn = _wrestlerService.Turn(id);
            if (!turn)
            {
              return Conflict($"{wrestler.RingName} is not active and cannot turn.");
            }
            return NoContent();
        }
    }
}