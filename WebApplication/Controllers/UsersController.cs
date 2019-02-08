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
  /// <file name="UsersController.cs"/>
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
  /// the 'Users' related operations.
  /// </summary>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  public class UsersController : ApiController
  {
    #region Private Members

    /// <summary>
    /// Entity Framework connection to database.
    /// </summary>
    private DatabaseContext db = new DatabaseContext();

    #endregion

    #region HTTP Operations

    /// <summary>
    /// Gets all the user records.
    /// </summary>
    /// 
    /// <remarks>
    /// GET: api/Users
    /// </remarks>
    /// 
    /// <returns>
    /// Returns IQueryable of all user records.
    /// </returns>
    public IQueryable<User> GetUsers()
    {
      return db.Users;
    }

    /// <summary>
    /// Gets a user based on id.
    /// </summary>
    /// 
    /// <remarks>
    /// GET: api/Users/5
    /// </remarks>
    /// 
    /// <param name="id">
    /// Unique user ID.
    /// </param>
    /// 
    /// <returns>
    /// Returns a single user that matches id.
    /// </returns>
    [ResponseType(typeof(User))]
    public async Task<IHttpActionResult> GetUser(int id)
    {
      User user = await db.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    /// <summary>
    /// Replace matching user with new user object.
    /// </summary>
    /// 
    /// <remarks>
    /// PUT: api/Users/5
    /// </remarks>
    /// 
    /// <param name="id">
    /// User ID of user that is going to be updated.
    /// </param>
    /// 
    /// <param name="user">
    /// The new user information
    /// </param>
    /// 
    /// <returns>
    /// Returns the status of the operation.
    /// </returns>
    [ResponseType(typeof(void))]
    public async Task<IHttpActionResult> PutUser(int id, User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != user.Id)
      {
        return BadRequest();
      }

      db.Entry(user).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
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
    /// Add new user to database.
    /// </summary>
    /// 
    /// <param name="user">
    /// The new user that will be added to the database.
    /// </param>
    /// 
    /// <remarks>
    /// POST: api/Users 
    /// </remarks>
    /// 
    /// <returns>
    /// Returns HTTP Result
    /// </returns>
    [ResponseType(typeof(User))]
    public async Task<IHttpActionResult> PostUser(User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Users.Add(user);

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (UserExists(user.Id))
        {
          return Conflict();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
    }

    /// <summary>
    /// Deletes user based on ID from database.
    /// </summary>
    /// 
    /// <param name="id">
    /// User ID
    /// </param>
    /// 
    /// <remarks>
    /// DELETE: api/Users/5
    /// </remarks>
    /// 
    /// <returns>
    /// Returns HTTP response with result of operation.
    /// </returns>
    [ResponseType(typeof(User))]
    public async Task<IHttpActionResult> DeleteUser(int id)
    {
      User user = await db.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      db.Users.Remove(user);
      await db.SaveChangesAsync();

      return Ok(user);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Checks to see if the user record exists.
    /// </summary>
    /// 
    /// <param name="id">
    /// Checks for records that match the Id.
    /// </param>
    /// 
    /// <returns>
    /// Returns true if user exists, false otherwise.
    /// </returns>
    private bool UserExists(int id)
    {
      return db.Users.Count(e => e.Id == id) > 0;
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