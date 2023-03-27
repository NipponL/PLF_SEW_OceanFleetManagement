using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shipping
{
    public class StorageContainer
    {
        public int Id { get; set; }
        public string Renter { get; set; }
        public float MaxVolume { get; set; }
        public float UsedVolume { get; set; }

        public bool AddSpace(float volume)
        {
            //TODO
            if (Renter == "Magna")
            {
                MaxVolume += volume;
                return true;
            }
            return false;
            
        }

        public bool RemoveSpace(float volume)
        {
            if (UsedVolume >= volume)
            {
                UsedVolume -= volume;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("Container ID: {0}, Renter: {1}, Max Volume: {2} m^3, Used Volume: {3} m^3", Id, Renter, MaxVolume, UsedVolume);
        }
    }
}
