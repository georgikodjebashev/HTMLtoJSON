using HTMLtoJSON.DTOs;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace HTMLtoJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XDocument xmlDoc = XDocument.Load("../../../data.html");

            var products = xmlDoc.Root.Elements();
            List<ImportXmlProductDto> productsList = new List<ImportXmlProductDto>();

            foreach (var product in products)
            {
                var rating = product.FirstAttribute.NextAttribute.Value;

                string productName = product.Element("div").Element("h4").Value.ToString();

                var price = product.Element("div").Element("div").Element("p").Element("span").Element("span").Value.Trim('$');

                Console.WriteLine($"productName: {productName}, price: {price}, rsting: {rating}", "\n");

                ImportXmlProductDto productDto = new ImportXmlProductDto()
                {
                    ProductName = productName,
                    Price = Convert.ToDecimal(price),
                    Rating = Convert.ToDecimal(rating)
                };
                productsList.Add(productDto);
            }
            string json = JsonConvert.SerializeObject(productsList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("../../../result.js", json);
        }
    }
}