using BillOfMaterial.Core;
using BillOfMaterial.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BillOfMaterial.Test
{
  [TestClass]
  public class BomControllerTests
  {
    [TestMethod]
    public void ReadBomFile_Call_ShouldReturn19Entries()
    {
      // Arrange
      BomController ctrl = new BomController();

      // Act
      BomEntry[] entries = ctrl.ReadBomFile();

      // Assert
      Assert.IsNotNull(entries);
      Assert.AreEqual(15, entries.Length);
    }

    [TestMethod]
    public void GetOrdersForManufacturer_CallForPanasonic_ShouldReturnTwoEntries()
    {
      // Arrange
      BomController ctrl = new BomController();
      BomEntry[] entries = ctrl.ReadBomFile();

      // Act
      BomEntry[] entriesForPanasonic = ctrl.GetOrdersForManufacturer(entries, "Panasonic");

      // Assert
      Assert.IsNotNull(entriesForPanasonic);
      Assert.AreEqual(2, entriesForPanasonic.Length);
    }

    [TestMethod]
    public void GetOrdersForManufacturer_CallForInvalidManufacturer_ShouldNotReturnAnyEntries()
    {
      // Arrange
      BomController ctrl = new BomController();
      BomEntry[] entries = ctrl.ReadBomFile();

      // Act
      BomEntry[] entriesForXxx = ctrl.GetOrdersForManufacturer(entries, "XXX");

      // Assert
      Assert.IsNotNull(entriesForXxx);
      Assert.AreEqual(0, entriesForXxx.Length);
    }
  }
}
