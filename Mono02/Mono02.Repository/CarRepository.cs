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

        public List<Car> GetCar()
        {
            SqlConnection conn = new SqlConnection(connectionString);


            using (conn)
            {
                List<Car> cars = new List<Car>();

                SqlCommand command = new SqlCommand("SELECT carId, carName, carPrice, carMileage FROM Car;", conn);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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

        public Car Get(System.Guid id)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT carId FROM Car;", conn);

                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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

                    SqlDataReader reader2 = command.ExecuteReader();

                    if (reader2.HasRows)
                    {
                        if (reader2.Read())
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

        public Car AddCar(Car C)
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

                command.ExecuteNonQuery();
                C.carId = g;  

                    return C;
            }
        }

        public Car Putt(System.Guid id, Car C)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carsId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT carId FROM Car;", conn);

                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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
                    command.ExecuteNonQuery();
                    C.carId = id;

                    conn.Close();
                    return C;

                }
            }

        }

        public bool Delete(System.Guid id)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                List<System.Guid> carId = new List<System.Guid>();
                SqlCommand command2 = new SqlCommand("SELECT carId FROM Car;", conn);

                conn.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
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
                    command.ExecuteNonQuery();

                    conn.Close();
                    return true;

                }
            }
        }

    }
}
