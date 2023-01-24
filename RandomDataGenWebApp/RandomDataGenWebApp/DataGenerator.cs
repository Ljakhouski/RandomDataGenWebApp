using RandomDataGenWebApp.Models;
using System;
using System.Text.Json;

namespace RandomDataGenWebApp
{
    public class DataGenerator
    {
        private SourceDataModel model;
        public DataGenerator()
        {
            using (FileStream fs = new FileStream("DATABASE.json", FileMode.OpenOrCreate))
            {
                model = JsonSerializer.Deserialize<SourceDataModel>(fs);
            }
        }
        public TableRowModel GetRow(int seed, int page, int number, string country, double errSmooth)
        {
            var t = MakeRow(seed, page, number, country);
            return t;
        }

        public TableRowModel MakeRow(int seed, int page, int number, string country)
        {
            var row = new TableRowModel();
            row.RandomId = new Random(seed * (page + 1) * (number + 1)).Next();
            row.Number = page * 10 + number;

            var rand = new Random(seed * (page + 1) * (number + 1));
            switch (country)
            {
                case "Russia":
                    if (rand.Next() % 2 == 0)
                        row.Address = "г. " + model.RU_cities[rand.Next(model.RU_cities.Length - 1)] + " "
                            +
                            model.RU_streets[rand.Next(model.RU_streets.Length - 1)]
                            +
                            " д. " + rand.Next(255) + " кв. " + rand.Next(400);
                    else
                        row.Address = " п. " + model.RU_villages[rand.Next(model.RU_villages.Length - 1)]
                            +
                            " д. " + rand.Next(255).ToString();

                    if (rand.Next(3567) % 2 == 0)
                        row.Address += " к. " + rand.Next(5).ToString();


                    row.Name =
                        model.RU_surenames[rand.Next(model.RU_surenames.Length - 1)] + " "
                        +
                        model.RU_names[rand.Next(model.RU_names.Length - 1)] + " "
                        +
                        model.RU_middlenames[rand.Next(model.RU_middlenames.Length - 1)]
                        ;

                    row.PhoneNumber = "+7" + rand.Next(100000000, 999999999);
                    break;
                case "USA":
                    row.Address =
                        rand.Next(2550)
                        +
                        model.USA_streets[rand.Next(model.USA_streets.Length - 1)]
                        +
                        model.USA_cities[rand.Next(model.USA_cities.Length - 1)];


                    row.Name =
                        model.USA_names[rand.Next(model.USA_names.Length - 1)] + " "
                        +
                        model.USA_surenames[rand.Next(model.USA_surenames.Length - 1)] + " "
                        +
                        model.USA_middlenames[rand.Next(model.USA_middlenames.Length - 1)]
                        ;

                    row.PhoneNumber = "+1" + $" ({rand.Next(666)}) " + rand.Next(1000000, 9999999);
                    break;
                case "UK":
                    row.Address =
                        rand.Next(2550)
                        +
                        model.UK_streets[rand.Next(model.UK_streets.Length - 1)] + " "
                        +
                        model.UK_cities[rand.Next(model.UK_cities.Length - 1)];


                    row.Name =
                        model.UK_names[rand.Next(model.UK_names.Length - 1)] + " "
                        +
                        model.UK_surenames[rand.Next(model.UK_surenames.Length - 1)] + " "
                        +
                        model.UK_middlenames[rand.Next(model.UK_middlenames.Length - 1)]
                        ;

                    row.PhoneNumber = "+44" + rand.Next(1000000, 9999999);
                    break;
                default:
                    break;
            }
            return row;
        }
    }
}
