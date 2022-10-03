using System.Data.SqlClient;
using test.Models;

namespace test.Interfaces
{
    public interface IAssociatedVehicle
    {
        public float GetLastOdometer(string plateNumber);
        public AssociatedVehicle GetVehicalInfo(string plateNumber);
        
    }
}
