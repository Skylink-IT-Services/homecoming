using homecoming.api.Abstraction;
using homecoming.api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homecoming.api.Repo
{
    public class ReviewRepo : IDataStore<Review>
    {
        HomecomingDbContext db;
        public ReviewRepo(HomecomingDbContext dbContext)
        {
            db = dbContext;
        }
        public void Add(Review Params)
        {
            throw new NotImplementedException();
        }

        public List<Review> FindAll()
        {
            return db.Reviews.Include(o => o.Customer).Include(o => o.Booking).Include(o => o.Rating).ToList();
        }

        public Review GetById(int id)
        {
            return db.Reviews.SingleOrDefault(o => o.ReviewId.Equals(id));
        }

        public void RemoveById(int id)
        {
            Review review = db.Reviews.SingleOrDefault(o => o.ReviewId.Equals(id));
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void Update(int id, Review Params)
        {
            throw new NotImplementedException();
        }
    }
}
