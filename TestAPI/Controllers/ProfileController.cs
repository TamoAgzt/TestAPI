using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Contexts;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly DataContext _ctx;

        public ProfileController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetAllProfiles()
        {
            return Ok(await _ctx.tb_Profiles.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            var person = await _ctx.tb_Profiles.FindAsync(id);
            if (person == null)
            {
                return BadRequest("Not found");

            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Profile>>> CreateProfile(Profile profile)
        {
            _ctx.tb_Profiles.Add(profile);
            await _ctx.SaveChangesAsync();

            return Ok(await _ctx.tb_Profiles.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, Profile updatedProfile)
        {
            var profile = await _ctx.tb_Profiles.FindAsync(id);
            if (profile == null)
            {
                return BadRequest("Profile not found");
            }

            profile.Name = updatedProfile.Name;
            profile.Role = updatedProfile.Role;
            profile.Score = updatedProfile.Score;
            profile.UpdatedAt = updatedProfile.UpdatedAt;

            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _ctx.tb_Profiles.FindAsync(id);
            if (profile == null)
            {
                return BadRequest("Profile not found");
            }

            _ctx.tb_Profiles.Remove(profile);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}