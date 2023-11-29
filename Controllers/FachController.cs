using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StundenplanApp.Models;
using StundenplanApp.Services;

namespace StundenplanApp.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class FachController : Controller
    {
        public readonly IFachService fachService;
        public FachController(IFachService fachInterface)
        {
            fachService = fachInterface;
        }
        [HttpPost]
        public async Task<IActionResult> createSubject(Subjects newSubject)
        {
            return Ok(await fachService.createSubject(newSubject));
        }
        [HttpGet("{subjectID}")]
        public async Task<IActionResult> getSubject(int subjectID)
        {
            return Ok(await fachService.getSubject(subjectID));
        }
        [HttpPut]
        public async Task<IActionResult> editSubject(Subjects subjectToEdit)
        {
            return Ok(await fachService.editSubject(subjectToEdit));
        }
        [HttpDelete("{subjectID}")]
        public async Task<IActionResult> deleteSubject(int subjectID)
        {
            return Ok(await fachService.deleteSubject(subjectID));
        }
    }
}
