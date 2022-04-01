using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LunchChartWebAPI.Models;
using LunchChartWebAPI.Services;


namespace LunchChartWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menusService;

        public MenuController(MenuService menusService) =>
            _menusService = menusService;

        [HttpGet]
        public async Task<List<Menu>> Get() =>
            await _menusService.GetAsync();

        [HttpGet("{Day}")]
        public async Task<ActionResult<Menu>> Get(string Day)
        {
            var item = await _menusService.GetAsync(Day);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Menu newMenu)
        {
            await _menusService.CreateAsync(newMenu);

            return CreatedAtAction(nameof(Get), new { id = newMenu.Id }, newMenu);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Menu updatedMenu)
        {
            var item = await _menusService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            updatedMenu.Id = item.Id;

            await _menusService.UpdateAsync(id, updatedMenu);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _menusService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            await _menusService.RemoveAsync(id);

            return NoContent();
        }
    }
}
