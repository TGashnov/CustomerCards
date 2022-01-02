using CustomerCards.DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Linq;

namespace CustomerCards
{
    class Program
    {
        static readonly string connectionString = new ConnectionStringManager().ConnectionString;

        static CustomersCardsContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomersCardsContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            return new CustomersCardsContext(options);
        }

        static void Main(string[] args)
        {
            AddMockData();
            PrintUsersAndDisc();
        }

        static void PrintUsersAndDisc()
        {
            using(var context = CreateContext())
            {
                var customers = context.PersonalCards
                    .Select(card => new
                    {
                        card.UserProfile.LastName,
                        card.UserProfile.FirstName,
                        card.Discount
                    })
                    .ToArray();
                foreach (var customer in customers)
                {
                    Console.WriteLine("У пользователя {0} {1} суммарная скидка равна {2}", 
                        customer.LastName, customer.FirstName, customer.Discount);
                }
            }
        }

        static void AddMockData()
        {
            var personalCards = GetMockPersonalCards();
            using (var context = CreateContext())
            {
                context.PersonalCards.AddRange(personalCards);
                context.SaveChanges();
            }
        }

        static UserProfile[] GetMockUsers()
        {            
            var userProfiles = new UserProfile[3];

            for (int i = 0; i < userProfiles.Length; i++)
            {
                string fName = firstName[random.Next(userProfiles.Length)];
                string lName = lastName[random.Next(userProfiles.Length)];
                string em = lName.ToLower() + "_" + fName.ToLower().Substring(0,1) + email[random.Next(userProfiles.Length)];
                userProfiles[i] = new UserProfile()
                {
                    FirstName = fName,
                    LastName = lName,
                    Email = em,
                    Birthdate = new DateTime(random.Next(1950, 2004), random.Next(1, 13), random.Next(1, 29))
                };
            }
            return userProfiles;
        }

        static Purchase[] GetMockPurchases()
        {
            var purchases = new Purchase[7];
            for (int i = 0; i < purchases.Length; i++)
            {
                purchases[i] = new Purchase()
                {
                    PurchaseSum = random.Next()
                };
            }
            return purchases;
        }

        static PersonalCard[] GetMockPersonalCards()
        {
            var personalCards = new PersonalCard[3];
            var users = GetMockUsers();
            for (int i = 0; i < personalCards.Length; i++)
            {
                personalCards[i] = new PersonalCard()
                {
                    Discount = (float) Math.Round(random.NextDouble()*50),
                    UserProfile = users[i],
                    Purchases = GetMockPurchases()
                };
            }
            return personalCards;
        }

        static string[] firstName = new string[3] { "Viktor", "Andrey", "Roman" };
        static string[] lastName = new string[3] { "Pupkin", "Grudkin", "Bolshakov" };
        static string[] email = new string[3] { "@mail.ru", "@yandex.ru", "@gmail.ru" };
        static Random random = new Random();
    }
}
