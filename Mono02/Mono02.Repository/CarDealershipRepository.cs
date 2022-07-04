using Mono02.Model;
using Mono02.Repository.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mono02.Repository
{
    public class CarDealershipRepository : ICarDealershipRepository
    {
        string connectionString = "Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public async Task<List<CarDealership>> GetCarDealerShipAsync()
        {
            SqlConnection conn = new SqlConnection(connectionString);


            using (conn)
            {
                List<CarDealership> cDealership = new List<CarDealership>();

                SqlCommand command = new SqlCommand("SELECT cd_ID, cd_Name FROM Car_dealership;", conn);

                conn.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        cDealership.Add(new CarDealership(reader.GetGuid(0), reader.GetString(1)));
                    }
                }
                else
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                return cDealership;
            }
        }

        public async Task<CarDealership> GetAsync(System.Guid id)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carDealershipId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT cd_ID FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = await command2.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        carDealershipId.Add(reader.GetGuid(0));
                    }
                }
                else
                {
                    reader.Close();
                }
                reader.Close();
                if (!carDealershipId.Exists(x => x == id))
                {
                    return null;
                }

                else
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Car_dealership WHERE cd_ID = @sId;", conn);

                    command.Parameters.AddWithValue("@sId", id);

                    SqlDataReader reader2 = await command.ExecuteReaderAsync();

                    if (reader2.HasRows)
                    {
                        if (await reader2.ReadAsync())
                        {
                            CarDealership retrn = new CarDealership(reader2.GetGuid(0), reader2.GetString(1));
                            return retrn;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<CarDealership> PostCarDealershipAsync(CarDealership C)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<string> carDealershipName = new List<string>();

                SqlCommand command2 = new SqlCommand("SELECT cd_Name FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = await command2.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        carDealershipName.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (carDealershipName.Exists(x => x == C.cd_Name))
                {
                    return null;
                }
                else
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (@cd_ID, @cd_Name)", conn);
                    System.Guid g = System.Guid.NewGuid();
                    command.Parameters.AddWithValue("@cd_ID", g);
                    command.Parameters.AddWithValue("@cd_Name", C.cd_Name);
                    await command.ExecuteNonQueryAsync();
                    C.cd_ID = g;
                    return C;
                }
            }
        }

        public async Task<CarDealership> PuttAsync(System.Guid id, CarDealership C)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carDealershipId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT cd_ID FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = await command2.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        carDealershipId.Add(reader.GetGuid(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!carDealershipId.Exists(x => x == id))
                {
                    return null;
                }

                else
                {
                    SqlCommand command = new SqlCommand("UPDATE Car_dealership SET cd_Name=@cd_Name WHERE cd_id=@sId", conn);
                    command.Parameters.AddWithValue("@cd_Name", C.cd_Name);
                    command.Parameters.AddWithValue("@sId", id);
                    await command.ExecuteNonQueryAsync();
                    C.cd_ID = id;

                    conn.Close();
                    return C;

                }
            }

        }

        public async Task<bool> DeleteAsync(System.Guid id)
        {

            string connectionString = "Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carDealershipId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT cd_ID FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = await command2.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader .ReadAsync())
                    {
                        carDealershipId.Add(reader.GetGuid(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!carDealershipId.Exists(x => x == id))
                {
                    return false;
                }

                else
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Car_dealership WHERE cd_ID = @sId;", conn);

                    command.Parameters.AddWithValue("@sId", id);
                    await command.ExecuteNonQueryAsync();

                    conn.Close();
                    return true;

                }
            }
        }

    }
}
