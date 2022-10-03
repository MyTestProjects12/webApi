using Catalog.Settings;
using Dapper;
using System.Data.SqlClient;
using test.Interfaces;
using test.Models;

namespace test.Reposotries
{
    public class SqlVehicalReposotory : IAssociatedVehicle
    {
        
       
        public float GetLastOdometer(string plateNumber)
        {

            using (System.Data.IDbConnection connection = new SqlConnection(SqlDbSettings.ConnectionString))
            {

                connection.Open();
                string query =
                @"SELECT AV.LastOdometer  from [dbo].[Vehicle] as V 
                             inner join [dbo].[AssociatedVehicle] as AV  on V.VehicleID = AV.VehicleID
                 where  V.PlateNumber = @PlateNumber";

                return connection.QueryFirstOrDefault<AssociatedVehicle>(query, new { PlateNumber = plateNumber }).LastOdometer;
            }
        }

        public AssociatedVehicle GetVehicalInfo(string plateNumber)
        {
            using (System.Data.IDbConnection connection = new SqlConnection(SqlDbSettings.ConnectionString))
            {
                connection.Open();
             
                string query =
            @"SELECT V.PlateNumber, DR.NameAr as Driver,Fl.NameAr as FLeet, SF.NameAr as SubFleet ,C.NameAr as Company 
           from [dbo].[Vehicle] as V 
				    inner join [dbo].[AssociatedVehicle] as AV  ON    V.VehicleID = AV.VehicleID
				    inner join [dbo].[Driver] as  DR ON AV.DriverID = DR.DriverID
				    inner join [dbo].[SubFleet] as SF on SF.SubFleetID = AV.SubFleetID
				    inner join [dbo].[Fleet] as FL ON SF.FleetID = Fl.FleetID
				    inner join [dbo].[Company] as C ON C.CompanyID = FL.CompanyID
           where V.PlateNumber = @PlateNumber";
                //70-29202
                AssociatedVehicle associatedVehicle = connection.QueryFirstOrDefault<AssociatedVehicle>(query, new { PlateNumber = plateNumber });
                return associatedVehicle;
            }
               
        }
    }
}
