using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.Models;
using ReceitasBE.DTOs;
using ReceitasBE.Services;

namespace ReceitasBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly RecipesDbContext _context;
        private readonly CommentsService _commentsService;

        public CommentsController(RecipesDbContext context)
        {
            UsersService usersService = new UsersService(context);
            RecipesService recipesService = new RecipesService(context, usersService, new IngredientsService(context));
            _commentsService = new CommentsService(context, usersService, recipesService);
        }

        // GET: api/Comments/Recipes/guid_receita
        [HttpGet("Recipes/{guid_receita}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsForRecipe(Guid guid_receita)
        {
            return Ok(_commentsService.GetAllCommentsForRecipe(guid_receita));
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(CommentDTO commentDTO)
        {
           Comment comment = _commentsService.createComment(commentDTO);

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            Comment comment = _commentsService.deleteComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            return NoContent();
        }
       
    }
}
