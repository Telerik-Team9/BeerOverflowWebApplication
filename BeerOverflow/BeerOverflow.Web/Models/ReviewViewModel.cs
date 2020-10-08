using System;

namespace BeerOverflow.Web.Models
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public int Likes { get; set; }
         public Guid BeerId { get; set; }
        public string BeerName { get; set; }
        //  public UserDTO UserDTO

    }
}
