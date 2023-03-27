using Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanFleetManagement
{
    internal interface IDataAccess
    {
        Dictionary<int, ContainerShip> GetContainerShips();
    }
}
