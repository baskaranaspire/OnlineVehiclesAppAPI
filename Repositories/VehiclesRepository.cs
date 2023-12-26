using Dapper;
using Npgsql;
using OnlineVehiclesApplication.Constants;
using OnlineVehiclesApplication.DataTransferObjects;
using OnlineVehiclesApplication.Interfaces;
using System.Data;

namespace OnlineVehiclesApplication.Repositories
{
    public class VehiclesRepository : IVehiclesRepository
    {
        public async Task<Vehicles> Create(Vehicles vehicles)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@VehicleId", vehicles.VehicleId);
                param.Add("@Vin", vehicles.Vin);
                param.Add("@Model", vehicles.Model);
                param.Add("@Make", vehicles.Make);
                param.Add("@Year", vehicles.Year);
                param.Add("@ThumbnailId", vehicles.ThumbnailUrl);
                await Task.FromResult(connectionPostgreSQL.Execute($"insert into public.Vehicles values(@VehicleId,@Vin,@Model,@Make, @Year, @ThumbnailId)", param, commandType: CommandType.Text));
                return vehicles;
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@id", id);
                int result = await Task.FromResult(connectionPostgreSQL.Execute($"DELETE FROM public.Vehicles WHERE Vehicle_Id = @id", param, commandType: CommandType.Text));
                return result;
            }
        }

        public Task<List<Vehicles>> GetAllAsync()
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var querySQL = @"SELECT Vehicle_Id VehicleId,Vin,Model,Make,Year,Thumbnail_Url ThumbnailUrl FROM public.Vehicles;";
                IList<Vehicles> vehicleList = connectionPostgreSQL.Query<Vehicles>(querySQL).ToList();
                return Task.FromResult(vehicleList.ToList());
            }
        }

        public Task<Vehicles> GetByIdAsync(string id)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@id", id);
                var result = connectionPostgreSQL.Query<Vehicles>(@"Select Vehicle_Id VehicleId,Vin,Model,Make,Year,Thumbnail_Url ThumbnailUrl  from public.Vehicles Where Vehicle_Id = @id", param, commandType: CommandType.Text).FirstOrDefault();
                return Task.FromResult(result);
            }
        }

        public async Task<Vehicles> Update(Vehicles vehicles)
        {
            if (vehicles != null && vehicles.VehicleId != null)
            {
                using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
                {
                    Task<Vehicles> vehicleExists = this.GetByIdAsync(vehicles.VehicleId);
                    if (vehicleExists.Result != null)
                    {
                        var param = new DynamicParameters();
                        param.Add("@Vin", vehicles.Vin);
                        param.Add("@Model", vehicles.Model);
                        param.Add("@Make", vehicles.Make);
                        param.Add("@Year", vehicles.Year);
                        param.Add("@ThumbnailUrl", vehicles.ThumbnailUrl);
                        await Task.FromResult(connectionPostgreSQL.Execute($"Update public.Vehicles set Vin = @Vin,Model = @Model,Make=@Make,Year=@Year,Thumbnail_Url=@ThumbnailUrl Where Vehicle_Id = @id", param, commandType: CommandType.Text));
                        return vehicles;
                    }
                }
            }
            return null;
        }
    }
}
