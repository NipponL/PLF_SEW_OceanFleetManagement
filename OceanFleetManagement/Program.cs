using Shipping;
using OceanFleetManagement;


SqliteDataAccess da = new SqliteDataAccess();
Dictionary<int, ContainerShip> ships = da.GetContainerShips();

// TODO
// 3m³ Ladegut zum Container auf dem Schiff "MSC Oscar" vom Mieter(Renter) "Magna" mit der Methode "AddSpace" hinzufügen

// TODO
// Versuche noch einmal dort 3m³ Ladegut hinzuzufügen

foreach (var ship in ships.Values)
{
    Console.WriteLine("*****************");
    Console.WriteLine($"{ship.ShipName}");
    Console.WriteLine("*****************");
    Console.Write(ship.PrintStatus());
    int availableContainers;
    float availableVolume;
    ship.AvailableCargoSpace(out availableContainers, out availableVolume);
    Console.WriteLine($"Left space: {availableContainers.ToString()}x full container(s) and additional free {availableVolume.ToString()}m³ volume");
    Console.WriteLine();
}












