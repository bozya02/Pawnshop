using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.DB
{
    public class DataAccess
    {
        public static List<Client> GetClients() => PawnshopEntities.GetContext().Clients.ToList();
        public static List<Product> GetProducts() => PawnshopEntities.GetContext().Products.ToList();
        public static List<Contract> GetContracts() => PawnshopEntities.GetContext().Contracts.ToList();

        public void SaveClient(Client client)
        {
            if (client.Id == 0)
                PawnshopEntities.GetContext().Clients.Add(client);

            PawnshopEntities.GetContext().SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
                PawnshopEntities.GetContext().Products.Add(product);

            PawnshopEntities.GetContext().SaveChanges();
        }

        public void SaveContract(Contract contract)
        {
            if (contract.Id == 0)
                PawnshopEntities.GetContext().Contracts.Add(contract);

            PawnshopEntities.GetContext().SaveChanges();
        }
    }
}
