using System.Threading.Tasks;

namespace BankOfMallorca.Customer
{
    public interface ICustomerRepository
    {
        Task Save(Customer customer);
    }
}