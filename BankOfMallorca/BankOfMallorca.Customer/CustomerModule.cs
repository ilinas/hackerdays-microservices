using Nancy;

namespace BankOfMallorca.Customer
{
    public class CustomerModule : NancyModule
    {
        public CustomerModule()
        {
            Get("/", _ => "ok");
        }
    }
}