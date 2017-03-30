namespace BankOfMallorca.Account
{
    public interface IAccountRepository
    {
        Account Save(System.Guid customerId);
    }
}