using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.InteropServices;


namespace Mono02.WebApi.Controllers
{
    public class CarDealership
    {
        public CarDealership(System.Guid ID, string NAME)
        {
            cd_ID = ID;
            cd_Name = NAME;
        }
        public System.Guid cd_ID;
        public string cd_Name;



    };

    public class CarDealershipController : ApiController
    {
        [HttpGet]
        [Route("CarDealership")]
        // GET api/values
        public HttpResponseMessage GetCarDealerShip()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");


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
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
                }
                reader.Close();
                return Request.CreateResponse(HttpStatusCode.OK, cDealership);
            }
        }
        
        [HttpGet]
        [Route("GetCarDealership")]
        // GET api/values/5
        public HttpResponseMessage Get(System.Guid id)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");

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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Ne postoji taj ID");
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
                            return Request.CreateResponse(HttpStatusCode.OK, retrn);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
                        }


                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");

                    }

                }
            }
        }




        [HttpPost]
        [Route("AddCarDealership")]

        public HttpResponseMessage PostCarDealership(CarDealership C)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");

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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Car dealership already exists");
                }
                else
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Car_dealership(cd_ID, cd_Name) VALUES (@cd_ID, @cd_Name)", conn);
                    System.Guid g = System.Guid.NewGuid();
                    command.Parameters.AddWithValue("@cd_ID", g);
                    command.Parameters.AddWithValue("@cd_Name", C.cd_Name);

                    command.ExecuteNonQuery();
                    return Request.CreateResponse(HttpStatusCode.OK, "Done");
                }


            }
        }


        [HttpPut]
        [Route("UpdateCarDealership")]

        public HttpResponseMessage Putt(System.Guid id, [FromBody] CarDealership C)
        {
            C.cd_ID = id;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");

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

                if (!carDealershipId.Exists(x => x == C.cd_ID))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Ne postoji taj ID");
                }

                else
                {
                    SqlCommand command = new SqlCommand("UPDATE Car_dealership SET cd_Name=@cd_Name WHERE cd_id=@sId", conn);
                    System.Guid g = System.Guid.NewGuid();
                    command.Parameters.AddWithValue("@cd_ID", C.cd_ID);
                    command.Parameters.AddWithValue("@cd_Name", C.cd_Name);
                    command.Parameters.AddWithValue("@sId", id);
                    command.ExecuteNonQuery();

                    conn.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, "Done");

                }
            }

        }




        [HttpDelete]
        [Route("DeleteCarDealership")]

        public HttpResponseMessage Delete(System.Guid id)
        {
          
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UBO4KB9\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");

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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Ne postoji taj ID");
                }

                else
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Car_dealership WHERE cd_ID = @sId;",conn);
                    
                    command.Parameters.AddWithValue("@sId", id);
                    command.ExecuteNonQuery();

                    conn.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, "Done");

                }
            }
    }






    }//APi
}

