using Microsoft.EntityFrameworkCore;
using ReceitasBE.Data;
using ReceitasBE.DTOs;
using ReceitasBE.Models;

namespace ReceitasBE.Services
{
    public class CommentsService
    {
        private readonly RecipesDbContext _context;
        private readonly UsersService _usersService;
        private readonly RecipesService _recipesService;

        public CommentsService(RecipesDbContext recipesDbContext, UsersService usersService, RecipesService recipesService)
        {
            _context = recipesDbContext;
            _usersService = usersService;
            _recipesService = recipesService;
        }

        public Comment createComment(CommentDTO commentDTO)
        {
            User user = _usersService.findUserById(commentDTO.UserId);
            Recipe recipe = _recipesService.findRecipeById(commentDTO.RecipeId);
            Comment comment = new Comment();
          
            comment.Text = commentDTO.Text;

            comment.Id = Guid.NewGuid();
            comment.User = user;
            comment.Recipe = recipe;
            comment.Date_created = DateTime.Now;
            comment.Deleted = false;

            _context.Comment.Add(comment);
            _context.SaveChanges();

            return comment;

        }

        public IEnumerable<Comment> GetAllCommentsForRecipe(Guid recipeId)
        {
            return _context.Comment.Where(comment => comment.Recipe.Id.Equals(recipeId) && comment.Deleted == false);
        }

        public Comment deleteComment(Guid commentId) 
        {
            Comment comment = findCommentById(commentId);

            if (comment != null)
            {
                comment.Deleted = true;

                _context.Entry(comment).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return comment;
        }

        private Comment findCommentById(Guid commentId) 
        {
            return _context.Comment.Find(commentId);
        }
    }
}
