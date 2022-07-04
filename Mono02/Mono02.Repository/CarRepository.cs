using Mono02.Model;
using Mono02.Model.Common;
using Mono02.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Repository
{
    public class CarRepository : ICarRepository
    {
        string connectionString = "Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public async Task<List<Car>> GetCarAsync()
        {
            SqlConnection conn = new SqlConnection(connectionString);


            using (conn)
            {
                List<Car> cars = new List<Car>();

                SqlCommand command = new SqlCommand("SELECT carId, carName, carPrice, carMileage FROM Car;", conn);

                conn.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        cars.Add(new Car(reader.GetGuid(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }
                }
                else
                {
                    reader.Close();
                    return null;
                }
                reader.Close();
                return cars;
            }
        }

        public async Task<Car> GetAsync(System.Guid id)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT carId FROM Car;", conn);

                conn.Open();
                SqlDataReader reader = await command2.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        carId.Add(reader.GetGuid(0));
                    }
                }
                else
                {
                    reader.Close();
                }
                reader.Close();
                if (!carId.Exists(x => x == id))
                {
                    return null;
                }

                else
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Car WHERE carId = @carIdd;", conn);

                    command.Parameters.AddWithValue("@carIdd", id);

                    SqlDataReader reader2 = await command.ExecuteReaderAsync();

                    if (reader2.HasRows)
                    {
                        if (await reader2.ReadAsync())
                        {
                            Car retrn = new Car(reader2.GetGuid(0), reader2.GetString(1), reader2.GetInt32(2), reader2.GetInt32(3));
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

        public async Task<Car> AddCarAsync(Car C)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using (conn)
            {
                
            
                SqlCommand command = new SqlCommand("INSERT INTO Car(carID, carName, carPrice, CarMileage) VALUES (@id, @name,@price,@mileage)", conn);
                    System.Guid g = System.Guid.NewGuid();
                command.Parameters.AddWithValue("@id", g);
                command.Parameters.AddWithValue("@name", C.carName);
                command.Parameters.AddWithValue("@price", C.carPrice);
                command.Parameters.AddWithValue("@mileage", C.carMileage);

                await command.ExecuteNonQueryAsync();
                C.carId = g;  

                    return C;
            }
        }

        public async Task<Car> PuttAsync(System.Guid id, Car C)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carsId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT carId FROM Car;", conn);

                conn.Open();
                SqlDataReader reader = await command2.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        carsId.Add(reader.GetGuid(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!carsId.Exists(x => x == id))
                {
                    return null;
                }

                else
                {
                    SqlCommand command = new SqlCommand("UPDATE Car SET carName=@name, carPrice = @price, carMileage = @mileage WHERE carId=@id", conn);
                    command.Parameters.AddWithValue("@name", C.carName);
                    command.Parameters.AddWithValue("@price", C.carPrice);
                    command.Parameters.AddWithValue("@mileage", C.carMileage);
                    command.Parameters.AddWithValue("@id", id);
                    await command .ExecuteNonQueryAsync();
                    C.carId = id;

                    conn.Close();
                    return C;

                }
            }

        }

        public async Task<bool> DeleteAsync(System.Guid id)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT carId FROM Car;", conn);

                conn.Open();
                SqlDataReader reader = await command2.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        carId.Add(reader.GetGuid(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!carId.Exists(x => x == id))
                {
                    return false;
                }

                else
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Car WHERE carId = @id;", conn);

                    command.Parameters.AddWithValue("@id", id);
                    await command .ExecuteNonQueryAsync();

                    conn.Close();
                    return true;

                }
            }
        }

    }
}
