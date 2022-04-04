using FizzWare.NBuilder;
using System.Linq;
using TP4.Models;

namespace Seeder
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = DbContextFactory.CreateDbContext();
            context.Clients.RemoveRange(context.Clients);
            context.SaveChanges();

            var abonnements = context.Abonnements.ToList();
            var generator = new RandomGenerator();
            var clients = Builder<Client>.CreateListOfSize(15)
            .All()
                .With(c => c.ClientId = 0)
                .With(c => c.AbonnementId = 0)
                .With(c => c.Nom = Faker.Name.FullName())
                .With(c => c.Age = generator.Next(20, 75))
                .With(c => c.Courriel = Faker.Internet.Email())
                .With(c => c.NoTelephone = generator.Next(111, 999).ToString("000") + generator.Next(111, 999).ToString("000") + generator.Next(0000, 9999).ToString("0000"))
                .With(c => c.Abonnement = Pick<Abonnement>.RandomItemFrom(abonnements))
            .Build();

            context.Clients.AddRange(clients);
            context.SaveChanges();

        }
    }
}
