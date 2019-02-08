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
  /// <file name="ProjectsController.cs"/>
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
  /// the 'Project' related operations.
  /// </summary>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  public class ProjectsController : ApiController
  {
    #region Private Members

    /// <summary>
    /// Entity Framework connection to database.
    /// </summary>
    private DatabaseContext db = new DatabaseContext();

    #endregion

    #region HTTP Operations

    /// <summary>
    /// Gets all the project records.
    /// </summary>
    /// 
    /// <remarks>
    /// GET: api/Projects
    /// </remarks>
    /// 
    /// <returns>
    /// Returns IQueryable of all project records.
    /// </returns>
    public IQueryable<Project> GetProjects()
    {
      return db.Projects;
    }

    /// <summary>
    /// Gets a project based on id.
    /// </summary>
    /// 
    /// <remarks>
    /// GET: api/Projects/5
    /// </remarks>
    /// 
    /// <param name="id">
    /// Unique project ID.
    /// </param>
    /// 
    /// <returns>
    /// Returns a single project that matches id.
    /// </returns>
    [ResponseType(typeof(Project))]
    public async Task<IHttpActionResult> GetProject(int id)
    {
      Project project = await db.Projects.FindAsync(id);

      if (project == null)
      {
        return NotFound();
      }

      return Ok(project);
    }

    /// <summary>
    /// Replace matching project with new project object.
    /// </summary>
    /// 
    /// <remarks>
    /// PUT: api/Projects/5
    /// </remarks>
    /// 
    /// <param name="id">
    /// User ID of project that is going to be updated.
    /// </param>
    /// 
    /// <param name="project">
    /// The new project information
    /// </param>
    /// 
    /// <returns>
    /// Returns the status of the operation.
    /// </returns>
    [ResponseType(typeof(void))]
    public async Task<IHttpActionResult> PutProject(int id, Project project)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != project.Id)
      {
        return BadRequest();
      }

      db.Entry(project).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProjectExists(id))
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
    /// Add new project to database.
    /// </summary>
    /// 
    /// <param name="project">
    /// The new project that will be added to the database.
    /// </param>
    /// 
    /// <remarks>
    /// POST: api/Projects
    /// </remarks>
    /// 
    /// <returns>
    /// Returns HTTP Result
    /// </returns>
    [ResponseType(typeof(Project))]
    public async Task<IHttpActionResult> PostProject(Project project)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Projects.Add(project);

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (ProjectExists(project.Id))
        {
          return Conflict();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
    }

    /// <summary>
    /// Deletes project based on ID from database.
    /// </summary>
    /// 
    /// <param name="id">
    /// Project ID
    /// </param>
    /// 
    /// <remarks>
    /// DELETE: api/Projects/5
    /// </remarks>
    /// 
    /// <returns>
    /// Returns HTTP response with result of operation.
    /// </returns>
    [ResponseType(typeof(Project))]
    public async Task<IHttpActionResult> DeleteProject(int id)
    {
      Project project = await db.Projects.FindAsync(id);

      if (project == null)
      {
        return NotFound();
      }

      db.Projects.Remove(project);
      await db.SaveChangesAsync();

      return Ok(project);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Checks to see if the project record exists.
    /// </summary>
    /// 
    /// <param name="id">
    /// Checks for records that match the Id.
    /// </param>
    /// 
    /// <returns>
    /// Returns true if project exists, false otherwise.
    /// </returns>
    private bool ProjectExists(int id)
    {
      return db.Projects.Count(e => e.Id == id) > 0;
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