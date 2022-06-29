using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mono02.WebApi.Controllers
{

    public static class PeopleList
    {
        static public List<Person> _list;
        static PeopleList()
        {
            _list = new List<Person>();
        }
        public static void Record(Person person)
        {
            _list.Add(person);
        }
        public static void RecordOn(int id, Person person)
        {
            _list.Insert(id, person);
        }
        public static Person Display(int i)
        {
            return _list[i];
        }
        public static List<Person> DisplayAll()
        {
            return _list;
        }
    }



    public class Student
    {
        public Student(){}
        public int Id { get; set; }
        public string Name{get; set;}
    }

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
    }


    public class ValuesController : ApiController
    {
        [HttpGet]
        // GET api/values
        public HttpResponseMessage Gett()
        {
            if (PeopleList._list == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"Empty");
            }
            else
            { return Request.CreateResponse(HttpStatusCode.OK, PeopleList.DisplayAll()); }
        }
        [HttpGet]
        // GET api/values/5
        public HttpResponseMessage Gett(int id)
        {
            if (!PeopleList._list.Exists(x => x.Id == id))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,"Id ne postoji");
            }
            else
            { return Request.CreateResponse(HttpStatusCode.OK, PeopleList._list.Find(x => x.Id == id)); }
        }
        [HttpPost]
        // POST api/values
        public HttpResponseMessage Postt(Person p)
        {
           if(PeopleList._list.Exists(x=>x.Id == p.Id))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id already exists");
            }
            else
            {
                PeopleList.Record(p);

                return Request.CreateResponse(HttpStatusCode.OK, PeopleList.DisplayAll());
            }
        }

        [HttpPut]
        // PUT api/values/5
        public HttpResponseMessage Putt(int id, [FromBody] Person p)
        {
            if (!PeopleList._list.Exists(x => x.Id == id))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id ne postoji");
    
            }
            else
            {
                foreach (Person pers in PeopleList._list)
                {
                    if (id == pers.Id)
                    {
                        pers.Name = p.Name;
                        pers.Age = p.Age;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, PeopleList.DisplayAll());
            }
            
        }
        [HttpDelete]
        // DELETE api/values/5
        public HttpResponseMessage Deletee(int id)
        {
            if (!PeopleList._list.Exists(x => x.Id == id))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id ne postoji");

            }
            else
            {
                foreach (Person pers in PeopleList._list.ToList())
                {
                    if (id == pers.Id)
                    {
                        PeopleList._list.Remove(pers);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, PeopleList.DisplayAll());
            }        
        }
    }
}
