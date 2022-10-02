using Shipping_Project.Models;

namespace Shipping_Project.Repository.Weight
{
    public class Weight:IWeight
    {
        private readonly ShippingDbContext context;

        public Weight(ShippingDbContext db)
        {
            context = db;
        }


        public Weights GetWeight()
        {
            return context.Weights.FirstOrDefault(w=>w.Id ==1);
        }

        public void Update(Weights newWeight)
        {
            
            Weights oldWeight = GetWeight();
            
            oldWeight.NormalWeight = newWeight.NormalWeight;
            oldWeight.NormalCost = newWeight.NormalCost;
            oldWeight.ExtraCostPerKG = newWeight.ExtraCostPerKG;
            
            
            context.SaveChanges();
        }

    }
}
