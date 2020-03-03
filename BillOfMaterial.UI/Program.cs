using System;
using BillOfMaterial.Core;
using BillOfMaterial.Core.Model;

namespace BillOfMaterial.UI
{
  class Program
  {
    static void Main(string[] args)
    {
      BomController ctrl = new BomController();
      BomEntry[] entries = ctrl.ReadBomFile();
      string manufacturer = ctrl.GetManufacturer(entries);
      ctrl.WriteOrder(entries, manufacturer);
    }
  }
}
