using System;
using System.Collections.Generic;
using System.Linq;
using BeerOverflow.Database;
using BeerOverflow.Database.Seed;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTOMappers;
using BeerOverflow.Services.DTOs;

namespace BeerOverflow.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly BeerOverflowDbContext context;

        public ReviewService(BeerOverflowDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ReviewDTO Create(ReviewDTO DTO)
        {
            var reviewToAdd = DTO.GetModel();

            this.context.Reviews.Add(reviewToAdd);
            this.context.SaveChanges();
            return DTO;
        }

        public IEnumerable<ReviewDTO> RetrieveAll()
            => this.context.Reviews
                     .Where(r => !r.IsDeleted)
                     .Select(r => r.GetDTO());

        public ReviewDTO RetrieveById(Guid id)
            => this.context.Reviews
                     .Where(c => !c.IsDeleted)
                     .FirstOrDefault(r => r.Id == id)
                     .GetDTO();

        public ReviewDTO Update(Guid id, ReviewDTO DTO)
        {
            var review = this.context.Reviews
                        .FirstOrDefault(r => r.Id == id);

            if (review == null)
            {
                throw new ArgumentException(); //TODO: ex
            }

            review.Content = DTO.Content;
            review.Likes = DTO.Likes;
            review.ModifiedOn = DateTime.Now;
            this.context.SaveChanges();
            return DTO;
        }

        public bool Delete(Guid id)
        {
            try
            {
                var reviewToDelete = this.context.Reviews
                    .FirstOrDefault(c => c.Id == id);

                reviewToDelete.IsDeleted = true;
                reviewToDelete.DeletedOn = DateTime.Now; // TODO: Should we use provider here?
                this.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
