using Resturant_os.Helpers;
using Resturant_os.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Resturant_os.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Resturant")]
    public class ResturantController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetResturants()
        {
            try
            {
                //Create a new response
                APIResponse response = new APIResponse();

                var resturants = (from r in db.Resturants
                               select new
                               {
                                   r.ResturantId,
                                   r.ResturantName,
                                   r.Address,
                                   r.PhoneNo
                               }
                               ).Distinct().ToList().OrderBy(r => r.ResturantId);

                if (resturants.Count() == 0)
                {
                    response.message = "No Resturants Found.";
                    response.status = false;
                    response.data = null;

                    return Ok(response);
                }

                response.message = "";
                response.status = true;
                response.data = resturants;

                return Ok(response);
            }
            catch (Exception)
            {
                //Create a new response
                APIResponse response = new APIResponse();

                response.message = "Something went wrong please try again later.";
                response.status = false;
                response.data = null;

                return Ok(response);
            }
        }

        [HttpGet]
        public IHttpActionResult GetResturantById(int id)
        {
            try
            {
                //Create a new response
                APIResponse response = new APIResponse();

                if (id == 0)
                {
                    response.message = "Please enter a valid value.";
                    response.status = false;
                    response.data = null;

                    return Ok(response);
                }

                var findResturant = (from r in db.Resturants
                                     where r.ResturantId == id
                                     select new
                                     {
                                         r.ResturantId,
                                         r.ResturantName,
                                         r.Address,
                                         r.PhoneNo
                                     });

                if (findResturant.Count() == 0)
                {
                    response.message = "Resturant Not Found. Please enter a valid ID.";
                    response.status = false;
                    response.data = null;

                    return Ok(response);
                }

                var resturant = findResturant.FirstOrDefault();

                response.message = "";
                response.status = true;
                response.data = resturant;

                return Ok(response);
            }
            catch (Exception)
            {
                //Create a new response
                APIResponse response = new APIResponse();

                response.message = "Something went wrong please try again later.";
                response.status = false;
                response.data = null;

                return Ok(response);
            }
        }

        [HttpGet]
        public IHttpActionResult GetResturantByname(string resturantName)
        {
            try
            {
                //Create a new response
                APIResponse response = new APIResponse();

                if (resturantName == "" || resturantName == " " | resturantName == null)
                {
                    response.message = "Please enter a valid value.";
                    response.status = false;
                    response.data = null;

                    return Ok(response);
                }

                var findResturant = (from r in db.Resturants
                                     where r.ResturantName == resturantName
                                     select new
                                     {
                                         r.ResturantId,
                                         r.ResturantName,
                                         r.Address,
                                         r.PhoneNo
                                     }).Distinct().ToList();

                if (findResturant.Count() == 0)
                {
                    response.message = "Resturant Not Found. Please enter a valid ID.";
                    response.status = false;
                    response.data = null;

                    return Ok(response);
                }

                var resturant = findResturant.FirstOrDefault();

                response.message = "";
                response.status = true;
                response.data = resturant;

                return Ok(response);
            }
            catch (Exception)
            {
                //Create a new response
                APIResponse response = new APIResponse();

                response.message = "Something went wrong please try again later.";
                response.status = false;
                response.data = null;

                return Ok(response);
            }
        }

        [HttpPost]
        public IHttpActionResult PostResturant(string resturantName, string address, string phoneNumber)
        {
            try
            {
                //Create a new response
                APIResponse response = new APIResponse();

                db.Resturants.Add(new Resturant
                {
                    ResturantId = 0,
                    ResturantName = resturantName,
                    Address = address,
                    PhoneNo = phoneNumber,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                });

                db.SaveChanges();

                var resturant = (from r in db.Resturants
                                  where r.ResturantName == resturantName
                                  && r.Address == address
                                  && r.PhoneNo == phoneNumber
                                  select r
                                  );

                response.message = "";
                response.status = true;
                response.data = resturant;

                return Ok(response);

            }
            catch (Exception)
            {
                //Create a new response
                APIResponse response = new APIResponse();

                response.message = "Something went wrong please try again later.";
                response.status = false;
                response.data = null;

                return Ok(response);
            }
        }


        [HttpPut]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult PutRegion(int id, string resturantName, string address, string phoneNumber)
        {
            try
            {
                //Create a new response
                APIResponse response = new APIResponse();

                var resturant = (from r in db.Resturants where r.ResturantId == id select r).FirstOrDefault();

                resturant.ResturantName = resturantName;
                resturant.Address = address;
                resturant.PhoneNo = phoneNumber;
                resturant.Updated = DateTime.Now;

                db.SaveChanges();

                var updatedResturant = (from r in db.Resturants where r.ResturantId == id select r).FirstOrDefault();

                response.message = "";
                response.status = true;
                response.data = updatedResturant;

                return Ok(response);
            }
            catch (Exception)
            {
                //Create a new response
                APIResponse response = new APIResponse();

                response.message = "Something went wrong please try again later.";
                response.status = false;
                response.data = null;

                return Ok(response);
            }

        }

        [HttpDelete]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult DeleteRegion(int id)
        {
            try
            {
                //Create a new response
                APIResponse response = new APIResponse();

                var resturant = (from r in db.Resturants where r.ResturantId == id select r).FirstOrDefault();

                db.Resturants.Remove(resturant);

                db.SaveChanges();

                var deleted = (from r in db.Resturants where r.ResturantId == id select r);

                if (deleted.Count() == 0)
                {

                    response.message = "Delete Successful";
                    response.status = true;
                    response.data = null;

                    return Ok(response);
                }
                else
                {
                    response.message = "Something went wrong. Please try again later.";
                    response.status = false;
                    response.data = null;

                    return Ok(response);
                }
            }
            catch (Exception)
            {
                //Create a new response
                APIResponse response = new APIResponse();

                response.message = "Something went wrong please try again later.";
                response.status = false;
                response.data = null;

                return Ok(response);
            }
        }
    }
}