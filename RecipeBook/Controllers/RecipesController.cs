using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;
using RecipeBook.Repositories;

namespace RecipeBook.Controllers
{
    //Student ID 00013674
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeBookDbContext _context;
        private readonly IRecipesRepository _recipesRepository;

        public RecipesController(IRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _recipesRepository.GetAllRecipes();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _recipesRepository.GetSingleRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            await _recipesRepository.UpdateRecipe(recipe);
            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            _recipesRepository.CreateRecipe(recipe);

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            _recipesRepository.DeleteRecipe(id);

            return NoContent();
        }
    }
}
