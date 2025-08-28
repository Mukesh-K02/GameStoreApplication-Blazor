using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GameStore.Frontend.Converters;

namespace GameStore.Frontend.Models;
public class GameDetails
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]            //Validations using Annotations     
    public required string Name { get; set; }

    //Customizing error messages
    [Required(ErrorMessage = "The Genre field is required.")]
    
    /*creating attribute through type converter class
    which converts int to string*/
    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }
    /*in the backend model this is of type int*/ 

    [Range(1, 100)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}



