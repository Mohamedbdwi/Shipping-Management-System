using Shipping_Project.Models;

namespace Shipping_Project.Repository.Weight
{
    public interface IWeight
    {
        Weights GetWeight();
        void Update(Weights newWeight);
    }
}
