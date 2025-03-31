using ForumApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{

    public class Post
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DataConstants.Post.TitleMaxLength)]
        public string Title { get; set; }
       
        [Required]
        [MaxLength(DataConstants.Post.ContentMaxLength)]
        public string Content { get; set; }
    }
}
