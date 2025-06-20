using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace MaterialCalculator
{
    public class MaterialCalc
    {
        public static int MaterialCalculator(
            int productTypeId,
            int materialTypeId,
            int amount,
            double param1,
            double param2
            )
        {
            if ((productTypeId <= 0 || materialTypeId <= 0 || amount <= 0) || 
                (productTypeId == null || materialTypeId == null || amount == null || param1 == null || param2 == null))
            {
                return -1;
            }

            using (var context = new Context())
            {
                var product = context.ProductTypes.FirstOrDefault(pt => pt.Id == productTypeId);
                var material = context.MaterialTypes.FirstOrDefault(mt => mt.Id == materialTypeId);

                double materialPerProduct = product.Rate * param1 * param2;

                double materialWithDefect = materialPerProduct * (1 + material.RejectRate / 100);

                double expanses = materialWithDefect * amount;

                return (int)Math.Ceiling(expanses);
            }
        }

        public static void Main()
        {
            try
            {
                Console.WriteLine("Введите идентификатор типа продукции");
                int type = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите идентификатор типа материала");
                int material = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество продукции");
                int amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\"Введите первый параметр продукции\"");
                double param1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите второй параметр продукции");
                double param2 = Convert.ToDouble(Console.ReadLine());


                int res = MaterialCalculator(type, material, amount, param1, param2);

                if (res != -1)
                    Console.WriteLine($"Расход материала равен {res} единиц");
                else Console.WriteLine(res);
            }
            catch
            {
                Console.WriteLine("-1");
            }
        }
    }
}
