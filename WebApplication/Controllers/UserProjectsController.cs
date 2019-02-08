using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserProjectsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/UserProjects
        public IQueryable<UserProject> GetUserProjects()
        {
            return db.UserProjects;
        }

        // GET: api/UserProjects/5
        [ResponseType(typeof(UserProject))]
        public async Task<IHttpActionResult> GetUserProject(int id)
        {
            UserProject userProject = await db.UserProjects.FindAsync(id);
            if (userProject == null)
            {
                return NotFound();
            }

            return Ok(userProject);
        }

        // PUT: api/UserProjects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserProject(int id, UserProject userProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProject.UserId)
            {
                return BadRequest();
            }

            db.Entry(userProject).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserProjects
        [ResponseType(typeof(UserProject))]
        public async Task<IHttpActionResult> PostUserProject(UserProject userProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProjects.Add(userProject);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserProjectExists(userProject.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userProject.UserId }, userProject);
        }

        // DELETE: api/UserProjects/5
        [ResponseType(typeof(UserProject))]
        public async Task<IHttpActionResult> DeleteUserProject(int id)
        {
            UserProject userProject = await db.UserProjects.FindAsync(id);
            if (userProject == null)
            {
                return NotFound();
            }

            db.UserProjects.Remove(userProject);
            await db.SaveChangesAsync();

            return Ok(userProject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProjectExists(int id)
        {
            return db.UserProjects.Count(e => e.UserId == id) > 0;
        }
    }
}