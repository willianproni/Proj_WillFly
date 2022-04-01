using System;

namespace RoboApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random aeronave = new Random();
            string[] nomeAviao =
            {
                "T-25 Universal", "T-27 Tucano", "C-95 Bandeirante", "C-97 Brasília", "C-98 Caravan",
                "C-99", "C-130 Hércules", "KC-390 Millennium", "A-29 Super Tucano", "P-95 Bandeirulha"
            };


            Console.WriteLine("Generating 10 random numbers:");

            for (int ctr = 1; ctr <= 10; ctr++)
                Console.WriteLine($"{aeronave.Next(nomeAviao.Length)}");
        }
    }
}
