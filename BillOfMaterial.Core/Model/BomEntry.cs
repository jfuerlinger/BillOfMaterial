using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterial.Core.Model
{
  public class BomEntry
  {
    public int Item { get; set; }
    public string Manufacturer { get; set; }
    public string PartId { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

  }
}
