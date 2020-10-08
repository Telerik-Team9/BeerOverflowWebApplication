//using System;
//using System.Collections.Generic;
//using System.Linq;
//using BeerOverflow.Database.Seed;
//using BeerOverflow.Services.Contracts;
//using BeerOverflow.Services.DTOMappers;
//using BeerOverflow.Services.DTOs;

//namespace BeerOverflow.Services.Services
//{
//    public class ReviewService : IReviewService
//    {
//        //TODO: Register in services
//        public ReviewDTO Create(ReviewDTO DTO)
//        {
//            //var reviewToAdd = new Review
//            //{
//            //    Id = DTO.Id,
//            //    Content = DTO.Content,
//            //    Rating = DTO.Rating,
//            //    Likes = DTO.Likes,
//            //    CreatedOn = DTO.CreatedOn
//            //};

//            //Seeder.Reviews.Add(reviewToAdd);
//            //return DTO;
//            throw new NotImplementedException();
//        }

//        public IEnumerable<ReviewDTO> RetrieveAll()
//            => Seeder.Reviews
//                     .Where(r => !r.IsDeleted)
//                     .Select(r => r.GetDTO());

//        public ReviewDTO RetrieveById(Guid id)
//            => Seeder.Reviews
//                     .Where(c => !c.IsDeleted)
//                     .FirstOrDefault(r => r.Id == id)
//                     .GetDTO();

//        public ReviewDTO Update(Guid id, ReviewDTO DTO)
//        {
//            var review = Seeder.Reviews
//               .FirstOrDefault(r => r.Id == id);

//            if (review == null)
//                throw new ArgumentException();      //TODO: ex

//            review.Content = DTO.Content; // Extension method for country = countryDTo
//            review.Rating = DTO.Rating;
//            review.Likes = DTO.Likes;
//            review.ModifiedOn = DateTime.Now;

//            return DTO;
//        }

//        public bool Delete(Guid id)
//        {
//            try
//            {
//                var reviewToDelete = Seeder.Reviews
//                    .FirstOrDefault(c => c.Id == id);

//                reviewToDelete.IsDeleted = true;
//                reviewToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?

//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }
//}
