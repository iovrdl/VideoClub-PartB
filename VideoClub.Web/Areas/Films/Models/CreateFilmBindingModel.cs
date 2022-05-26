using System.ComponentModel.DataAnnotations;
using VideoClub.Core.Enumeration;

namespace VideoClub.Web.Areas.Films.Models
{
    public class CreateFilmBindingModel
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public Genre Genre { get; set; }
        
        [Required]
        [Range(1, 20, ErrorMessage = "{0} value must be between {1} and {2}.")]
        public int Copies { get; set; }

        public CreateFilmBindingModel()
        {
            Copies = 1;
        }
    }
}