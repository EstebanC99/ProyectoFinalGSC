using Microsoft.EntityFrameworkCore;
using YouOweMe.Entities;

namespace YouOweMe.Repositories.Things
{
    public class ThingRepository : BaseRepository, IThingRepository
    {
        public ThingRepository(IYouOweMeContext context) : base(context)
        {

        }

        public List<Thing> GetAll()
        {
            return this.Context.Things
                       .Include(p => p.Category)
                       .ToList();
        }

        public Thing GetByID(int id)
        {
            return this.Context.Things
                       .Include(p => p.Category)
                       .FirstOrDefault(p => p.ID == id);
        }

        public void Add(Thing newThing)
        {
            this.Context.Things.Add(newThing);

            this.Context.SaveChanges();
        }

        public void Update(Thing thing)
        {
            this.Context.Things.Update(thing);

            this.Context.SaveChanges();
        }

        public void Delete(Thing thing)
        {
            this.Context.Things.Remove(thing);

            this.Context.SaveChanges();
        }

        public int? GetBorrowedAmount(Thing thing)
        {
            return this.Context.Loans.Where(l => l.Thing != null &&
                                                 l.Thing.ID == thing.ID &&
                                                 !l.ReturnDate.HasValue)
                                     .Sum(l => l.BorrowedAmount);
        }
    }
}
