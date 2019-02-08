using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication.Models;

namespace WebApplication.Controllers
{
  /// <prologue>
  ///
  /// <file name="UserProjectsController.cs"/>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  ///
  /// <author name="Jason Truong" date="02/07/19"/>
  /// 
  /// <history>
  ///   <entry date="02/07/19" author="Jason Truong" scr="" 
  ///          desc="Created"/> 
  /// </history>
  ///
  /// </prologue>
  /// 
  /// <summary>
  /// Controller for handling Get and Post operations for
  /// the 'UserProject' related operations.
  /// </summary>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  public class UserProjectsController : ApiController
  {
    #region Private Members

    /// <summary>
    /// Entity Framework connection to database.
    /// </summary>
    private DatabaseContext db = new DatabaseContext();

    #endregion

    #region HTTP Operations

    /// <summary>
    /// Gets all the user project records.
    /// </summary>
    /// 
    /// <remarks>
    /// GET: api/UserProjects
    /// </remarks>
    /// 
    /// <returns>
    /// Returns IQueryable of all user project records.
    /// </returns>
    public IQueryable<UserProject> GetUserProjects()
    {
      return db.UserProjects;
    }

    /// <summary>
    /// Gets a user project based on id.
    /// </summary>
    /// 
    /// <remarks>
    /// GET: api/UserProjects/5
    /// </remarks>
    /// 
    /// <param name="id">
    /// Unique user project ID.
    /// </param>
    /// 
    /// <returns>
    /// Returns a single user project that matches id.
    /// </returns>
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

    /// <summary>
    /// Replace matching user project with new user project object.
    /// </summary>
    /// 
    /// <remarks>
    /// PUT: api/UserProjects/5
    /// </remarks>
    /// 
    /// <param name="id">
    /// User ID of user project that is going to be updated.
    /// </param>
    /// 
    /// <param name="userProject">
    /// The new user project information
    /// </param>
    /// 
    /// <returns>
    /// Returns the status of the operation.
    /// </returns>
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

    /// <summary>
    /// Add new user project to database.
    /// </summary>
    /// 
    /// <param name="userProject">
    /// The new user project that will be added to the database.
    /// </param>
    /// 
    /// <remarks>
    /// POST: api/UserProjects
    /// </remarks>
    /// 
    /// <returns>
    /// Returns HTTP Result
    /// </returns>
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
    
    /// <summary>
    /// Deletes user project based on ID from database.
    /// </summary>
    /// 
    /// <param name="id">
    /// User Project ID
    /// </param>
    /// 
    /// <remarks>
    /// DELETE: api/UserProjects/5 
    /// </remarks>
    /// 
    /// <returns>
    /// Returns HTTP response with result of operation.
    /// </returns>
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

    #endregion

    #region Private Methods

    /// <summary>
    /// Checks to see if the user project record exists.
    /// </summary>
    /// 
    /// <param name="id">
    /// Checks for records that match the Id.
    /// </param>
    /// 
    /// <returns>
    /// Returns true if user project exists, false otherwise.
    /// </returns>
    private bool UserProjectExists(int id)
    {
      return db.UserProjects.Count(e => e.UserId == id) > 0;
    }

    #endregion

    #region IDisposable

    /// <summary>
    /// Dispose of the Database.
    /// </summary>
    /// 
    /// <param name="disposing">
    /// Checks to ensure the dispose is only called once.
    /// </param>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    #endregion
  }
}