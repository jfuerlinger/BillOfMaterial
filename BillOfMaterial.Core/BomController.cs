using System;
using System.IO;
using System.Linq;
using System.Text;
using BillOfMaterial.Core.Model;

namespace BillOfMaterial.Core
{
  public class BomController
  {
    private const string BomFileName = "PCBAssemblyBOM.csv";

    public BomEntry[] ReadBomFile()
    {
      return File.ReadAllLines(BomFileName)
        .Skip(1)
        .Select(line =>
        {
          string[] parts = line.Split(';');
          return new BomEntry()
          {
            Item = int.Parse(parts[0]),
            Manufacturer = parts[1],
            PartId = parts[2],
            Quantity =  int.Parse(parts[3]),
            Description = parts[4],
            Type = parts[5]
          };
        })
        .ToArray();
    }

    public string GetManufacturer(BomEntry[] bomEntries)
    {
      Console.WriteLine("Please enter the manufacturer for which the order shall be created: ");

      bool isValidManufacturer;
      string userInput;
      do
      {
        userInput = Console.ReadLine();
        isValidManufacturer = bomEntries.Any(manufacturer => manufacturer.Manufacturer == userInput);
        if (!isValidManufacturer)
        {
          Console.WriteLine("Manufacturer entered not found! Try again!");
        }
      } while (!isValidManufacturer);


      return userInput;
    }

    public void WriteOrder(BomEntry[] bomEntries, string manufacturer)
    {
      BomEntry[] entriesOfManufacturer = GetOrdersForManufacturer(bomEntries, manufacturer);
      File.WriteAllText(
        $@"c:\temp\OrderFor{manufacturer}.csv", 
        BuildOutputForBoms(entriesOfManufacturer)); 
    }

    public BomEntry[] GetOrdersForManufacturer(BomEntry[] bomEntries, string manufacturer)
      => bomEntries
          .Where(entry => 
              entry.Manufacturer.Equals(manufacturer, StringComparison.InvariantCultureIgnoreCase))
          .ToArray();

    public string BuildOutputForBoms(BomEntry[] bomEntries)
    {
      StringBuilder sb = new StringBuilder("item;manufacturer;partId;quantity;description;type\n");

      foreach (BomEntry entry in bomEntries)
      {
        sb.AppendLine($"{entry.Item};{entry.Manufacturer};{entry.PartId};{entry.Quantity};{entry.Description};{entry.Type}");
      }

      return sb.ToString();
    }
  }
}
