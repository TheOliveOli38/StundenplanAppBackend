using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StundenplanApp.Models;
using StundenplanApp.Services;

namespace StundenplanApp.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        public readonly ITagService tagService;
        public TagController(ITagService tagInterface)
        {
            tagService = tagInterface;
        }
        [HttpPost]
        public async Task<IActionResult> createDay(Days newday)
        {
            return Ok(await tagService.createDay(newday));
        }
        [HttpGet("{dayID}")]
        public async Task<IActionResult> getDay(int dayID)
        {
            return Ok(await tagService.getDay(dayID));
        }
        [HttpDelete("{dayID}")]
        public async Task<IActionResult> deleteDay(int dayID)
        {
            return Ok(await tagService.deleteDay(dayID));
        }
        [HttpPut]
        public async Task<IActionResult> editDay(Days dayToEdit)
        {
            return Ok(await tagService.editDay(dayToEdit));
        }
        [HttpGet("getDaysByUserID/{userID}")]
        public async Task<IActionResult> getDaysByUserID(int userID)
        {
            return Ok(await tagService.getDaysByUserID(userID));
        }
        [HttpGet("getSubjectsByDay/{dayID}")]
        public async Task<IActionResult> getSubjectsByDay(int dayID)
        {
            return Ok(await tagService.getSubjectsByDay(dayID));
        }
        [HttpGet("getSubjectsByStd/{stdNumber}")]
        public async Task<IActionResult> getSubjectsByStd(int stdNumber)
        {
            return Ok(await tagService.getSubjectsByStd(stdNumber));
        }
    }
}
