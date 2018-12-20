using Pizza.Abstract;
using System.Linq;
using System.Net.Http;

namespace Pizza.PappaJones
{
    internal class PappaJonesRestApiClient : IOrderSender
    {
        private readonly HttpClient httpClient;

        public PappaJonesRestApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void Send(IOrder order)
        {
            //httpClient.PostAsync("ppj.com/api/v1/");

            var color = System.Console.ForegroundColor;
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("Order  Recieved");
            System.Console.WriteLine("________________");
            order
                .Positions
                .GroupBy(x => x.PizzaName)
                .Select(group =>
                {
                    System.Console.WriteLine($"> {group.Key}: {group.Sum(p => p.Pieces) / 8.0}");
                    return group.Key;
                }).ToList();
            System.Console.WriteLine("________________");
            System.Console.ForegroundColor = color;
        }
    }
}
