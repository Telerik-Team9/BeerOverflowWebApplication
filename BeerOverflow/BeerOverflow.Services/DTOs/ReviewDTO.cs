using System;

namespace BeerOverflow.Services.DTOs
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedOn { get; set; } // Is this necessary?

        //  public Guid BeerDTOId { get; set; }
        //  public BeerDTO BeerDTO { get; set; }
        //  public UserDTO UserDTO
    }
}
