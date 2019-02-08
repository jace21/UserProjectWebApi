using System;

namespace WebApplication
{
  /// <prologue>
  ///
  /// <file name="Constants.cs"/>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  ///
  /// 
  /// <author name="Jason Truong" date="02/08/19"/>
  /// 
  ///
  /// <history>
  ///   <entry date="02/08/19" author="Jason Truong" scr="" 
  ///          desc="Created"/> 
  /// </history>
  ///
  /// </prologue>
  /// 
  /// <summary>
  /// Constants for default profile.
  /// </summary>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  public class Constants
  {
    /// <summary>
    ///  SQL Server instance.
    /// </summary>
    public const string SqlServer = "SQLEXPRESS";

    /// <summary>
    /// Computer Name
    /// </summary>
    public static string ComputerName = Environment.MachineName;

    /// <summary>
    /// DB connect string to connect to SQL Database.
    /// </summary>
    public const string DbConnectString =
      @"data source={0}\{1};initial catalog=ProductionDatabase;" +
      @"integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
  }
}