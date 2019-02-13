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
    /// Server Name
    /// </summary>
    public static string ServerName = "jtbackend.database.windows.net";

    /// <summary>
    /// DB connect string to connect to SQL Database.
    /// </summary>
    public const string DbConnectString =
      "data source={0};initial catalog=ProductionDatabase;user id=jasontruong1321;password=Throwaway12;MultipleActiveResultSets=True;App=EntityFramework";
  }
}