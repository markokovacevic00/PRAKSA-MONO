using Mono02.Model;
using Mono02.Repository.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;


namespace Mono02.Repository
{
    public class CarDealershipRepository : ICarDealershipRepository
    {
        string connectionString = "Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public List<CarDealership> GetCarDealerShip()
        {
            SqlConnection conn = new SqlConnection(connectionString);


            using (conn)
            {
                List<CarDealership> cDealership = new List<CarDealership>();

                SqlCommand command = new SqlCommand("SELECT cd_ID, cd_Name FROM Car_dealership;", conn);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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

        public CarDealership Get(System.Guid id)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carDealershipId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT cd_ID FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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

                    SqlDataReader reader2 = command.ExecuteReader();

                    if (reader2.HasRows)
                    {
                        if (reader2.Read())
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

        public CarDealership PostCarDealership(CarDealership C)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<string> carDealershipName = new List<string>();

                SqlCommand command2 = new SqlCommand("SELECT cd_Name FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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
                    command.ExecuteNonQuery();
                    C.cd_ID = g;
                    return C;
                }
            }
        }

        public CarDealership Putt(System.Guid id, CarDealership C)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carDealershipId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT cd_ID FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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
                    command.ExecuteNonQuery();
                    C.cd_ID = id;

                    conn.Close();
                    return C;

                }
            }

        }

        public bool Delete(System.Guid id)
        {

            string connectionString = "Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carDealershipId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT cd_ID FROM Car_dealership;", conn);

                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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
                    command.ExecuteNonQuery();

                    conn.Close();
                    return true;

                }
            }
        }

    }
}
