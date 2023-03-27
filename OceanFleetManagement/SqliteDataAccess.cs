using Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace OceanFleetManagement
{
    internal class SqliteDataAccess : IDataAccess
    {
        public Dictionary<int, ContainerShip> GetContainerShips()
        {
            Dictionary<int, ContainerShip> ships = new Dictionary<int, ContainerShip>();
           
            using (SqliteConnection connection = new SqliteConnection(@"Data Source = ..\..\..\shipping.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select id, name, max_containers from container_ships";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ships.Add(reader.GetInt32(0), new ContainerShip(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                }
                command.CommandText = $"select * from storage_containers where container_ship_id = {ships[1].Id}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    ships[reader.GetInt32(3)].AddContainer(new StorageContainer() { Id = reader.GetInt32(0), Renter = reader.GetString(1), MaxVolume = reader.GetFloat(2)});
                    }
                }
                command.CommandText = $"select * from storage_containers where container_ship_id = {ships[2].Id}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ships[reader.GetInt32(3)].AddContainer(new StorageContainer() { Id = reader.GetInt32(0), Renter = reader.GetString(1), MaxVolume = reader.GetFloat(2) });
                    }
                }
                command.CommandText = $"select * from storage_containers where container_ship_id = {ships[3].Id}";
                using (var reader = command.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        ships[reader.GetInt32(3)].AddContainer(new StorageContainer() { Id = reader.GetInt32(0), Renter = reader.GetString(1), MaxVolume = reader.GetFloat(2) });
                    }
                }
                command.CommandText = $"select * from storage_containers where container_ship_id = {ships[4].Id}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ships[reader.GetInt32(3)].AddContainer(new StorageContainer() { Id = reader.GetInt32(0), Renter = reader.GetString(1), MaxVolume = reader.GetFloat(2) });
                    }
                }

            }
           
                return ships;
        }
    }
}





