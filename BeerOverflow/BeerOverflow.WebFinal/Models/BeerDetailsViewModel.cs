namespace BeerOverflow.Web.Models
{
    public class BeerDetailsViewModel
    {
        public BeerViewModel Beer { get; set; } = new BeerViewModel();
        public ReviewViewModel Review { get; set; } = new ReviewViewModel();
        public RatingViewModel Rating { get; set; } = new RatingViewModel();
    }
}
