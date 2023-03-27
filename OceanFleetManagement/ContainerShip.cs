using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping
{
    public class ContainerShip
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
        public int MaxContainers { get; set; }

        private Dictionary<int, StorageContainer> containers;

        public Dictionary<int, StorageContainer> Containers
        {
            get { return containers; }
            set { containers = value; }
        }    

        public ContainerShip(int id, string shipName, int maxContainers)
        {
            this.Id = id;
            ShipName = shipName;
            MaxContainers = maxContainers;
            containers = new Dictionary<int, StorageContainer>();
        }

        public bool AddContainer(StorageContainer container)
        {
            if (containers.Count < MaxContainers)
            {
                containers.Add(container.Id,container);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveContainer(StorageContainer container)
        {
            if (containers.ContainsKey(container.Id))
            {
                containers.Remove(container.Id);
                return true;
            }
            else
                return false;

        }

        public void AvailableCargoSpace(out int availableContainers, out float availableVolume)
        {
            float temp = 0f;
            availableContainers = MaxContainers - containers.Count ;
            foreach(StorageContainer item in Containers.Values)
            {
                temp += item.MaxVolume - item.UsedVolume;
            }
            availableVolume = temp;
        }
        public override string ToString()
        {
            return this.ShipName+" (max. "+this.MaxContainers+")";
        }

        public string PrintStatus()
        {
            var status = "";
            status += $"Max containers: {MaxContainers}\n";
            status += $"Containers loaded: {containers.Count}\n";
            status += $"Container list:\n";
            foreach (var container in containers.Values)
            {
                status += $"- ID: {container.Id}, renter: {container.Renter}, used volume: {container.UsedVolume}/{container.MaxVolume})\n";
            }
            return status;
        }
    }
}
