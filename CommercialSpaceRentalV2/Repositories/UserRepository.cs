using CommercialSpaceRentalV2.Constants.Enums;
using CommercialSpaceRentalV2.DTOs.UserDtos;
using CommercialSpaceRentalV2.Models;
using CommercialSpaceRentalV2.Repositories;
using Sensirion.Data.DB;
using System.Data;
using System.Data.Common;
using System.Reflection.Metadata;

public class UserRepository : BaseRepository
{

  protected readonly AuditLogRepository auditLog;

  public UserRepository(
     SQLHelper helper,
     ClientInfoService clientInfo,
     AuditLogRepository auditLog
   ) : base(helper, clientInfo)
  {
    this.auditLog = auditLog;
  
}
  void Log(int? userId, ActionType actionType, string? description)
  {
    try
    {
      AuditLogModel auditLogObject = new AuditLogModel
      {
        UserId = userId??0,
        ActionType = actionType,
        TargetType = TargetType.Users,
        TargetId = userId ?? 0,
        Description = description ?? string.Empty,
        IpAddress = clientInfo?.GetClientIp() ?? "Unknown",
        CreatedAt = DateTime.Now
      };
      auditLog.Add(auditLogObject);
    }
    catch (Exception ex)
    {
      Console.WriteLine("[Logger] " + ex.ToString());
      throw new DataException("couldn't save the log: " + ex);

    }
  }
  public List<UserModel> GetActiveUsers()
  {
    var users = new List<UserModel>();

    string query = @"
                SELECT
                id, type, name, email, phone, role, is_verified, status,
                created_at, updated_at, pasword_hash
                FROM [master].[dbo].[t_CRS_Users]
                WHERE status = 'active'
                ORDER BY created_at DESC;
        ";

    try
    {
      IList<DbDataRecord> records = _helper.ExecuteSqlManyResults(query);
      foreach (var record in records)
      {
        users.Add(new UserModel
        {
          Id = record.GetInt32(record.GetOrdinal("id")),
          CreatedAt = record.GetDateTime(record.GetOrdinal("created_at")),
          UpdatedAt = record.GetDateTime(record.GetOrdinal("updated_at")),
          Type = Enum.Parse<UserType>(record.GetString(record.GetOrdinal("type")), true),
          Name = record.GetString(record.GetOrdinal("name")),
          Email = record.GetString(record.GetOrdinal("email")),
          PasswordHash = record.GetString(record.GetOrdinal("pasword_hash")),
          Phone = record.GetString(record.GetOrdinal("phone")),
          Role = Enum.Parse<UserRole>(record.GetString(record.GetOrdinal("role")), true),
          IsVerified = record.GetBoolean(record.GetOrdinal("is_verified")),
          Status = Enum.Parse<UserStatus>(record.GetString(record.GetOrdinal("status")), true),
        });
      }
    }
    catch (Exception ex)
    {
      throw new DataException("Failed to retrieve active users.", ex);

    }

    return users;
  }
  public UserModel GetUserByEmail(string email)
  {

    string query = @"
            SELECT
            id, type, name, email, phone, role, is_verified, status,
            created_at, updated_at, pasword_hash
            FROM [master].[dbo].[t_CRS_Users]
            WHERE email = @email            
            ORDER BY created_at DESC;
        ";
    _helper.AddParameter("@email", DbType.String, email, false);

    try
    {
      IList<DbDataRecord> records = _helper.ExecuteSqlManyResults(query);
      if (records.Count < 1) {
        throw new DataException("No User Found");
      }
      var record = records[0]; 

      return new UserModel
      {
        Id = record.GetInt32(record.GetOrdinal("id")),
        Type = Enum.Parse<UserType>(record.GetString(record.GetOrdinal("type")), true),
        Name = record.GetString(record.GetOrdinal("name")),
        Email = record.GetString(record.GetOrdinal("email")),
        Phone = record.GetString(record.GetOrdinal("phone")),
        Role = Enum.Parse<UserRole>(record.GetString(record.GetOrdinal("role")), true),
        IsVerified = record.GetBoolean(record.GetOrdinal("is_verified")),
        Status = Enum.Parse<UserStatus>(record.GetString(record.GetOrdinal("status")), true),
        CreatedAt = record.GetDateTime(record.GetOrdinal("created_at")),
        UpdatedAt = record.GetDateTime(record.GetOrdinal("updated_at")),
        PasswordHash = record.GetString(record.GetOrdinal("pasword_hash"))
      };
    }
    catch (Exception ex)
    {
      throw new DataException("No User Found.", ex);
    }
  }
  public UserDefaultDto SignUp(UserModel user)
  {
    try
    {
      var existingUser = GetUserByEmail(user.Email);
      // If we reach this line, user already exists
      Log(null, ActionType.USER_REGISTER, $"FAIL: User with email {user.Email} already exists.");
      throw new DataException($"User with email {user.Email} already exists.");

    }
    catch (DataException ex)
    {
      if (!ex.Message.Contains("No User Found"))
      {
        throw; // rethrow if it's not the "user not found" case
      }
    }


    const string query = @"
    INSERT INTO dbo.t_CRS_Users (
      type, name, email, phone, created_at, updated_at,
      role, pasword_hash, is_verified, status
    )
    OUTPUT INSERTED.id
    VALUES (
      @type, @name, @email, @phone, @created_at, @updated_at,
      @role, @pasword_hash, @is_verified, @status
    );
  ";

    try
    {

      _helper.AddParameter("@type", DbType.String, user.Type.ToString(), false);
      _helper.AddParameter("@name", DbType.String, user.Name, false);
      _helper.AddParameter("@email", DbType.String, user.Email, false);
      _helper.AddParameter("@phone", DbType.String, user.Phone, false);
      _helper.AddParameter("@created_at", DbType.DateTime2, user.CreatedAt, false);
      _helper.AddParameter("@updated_at", DbType.DateTime2, user.UpdatedAt, false);
      _helper.AddParameter("@role", DbType.String, user.Role.ToString(), false);
      _helper.AddParameter("@pasword_hash", DbType.String, user.PasswordHash, false);
      _helper.AddParameter("@is_verified",DbType.Boolean, user.IsVerified, true);
      _helper.AddParameter("@status", DbType.String, user.Status, false);

      var insertedId = Convert.ToInt32(_helper.ExecuteSqlScalar(query));
      Log(insertedId, ActionType.USER_REGISTER, "SUCCESS");

      return new UserDefaultDto
      {
        Id = insertedId,
        Name = user.Name,
        Email = user.Email,
        Phone = user.Phone,
        Role = user.Role,
        Type = user.Type,
        Status = UserStatus.Active,
        CreatedAt = DateTime.Now,
      };
    }
    catch (Exception ex)
    {
      Console.WriteLine("[UserRepository][SighUp]" + ex.ToString());
      Log(null, ActionType.USER_REGISTER, "FAIL");
      throw new DataException("Failed to create user via inline insert.", ex);
    }
  }

  public UserDefaultDto UpdateUser(UserModel user)
  {
    var existingUser = GetUserByEmail(user.Email); // throws if not found

    const string query = @"
      UPDATE [master].[dbo].[t_CRS_Users] 
      SET 
      name = @name, 
      email = @email, 
      phone = @phone, 
      updated_at = @updated_at, 
      pasword_hash = @pasword_hash, 
      is_verified = @is_verified, 
      status = @status
      WHERE id = @id;
  ";

    try
    {
      _helper.AddParameter("@id", DbType.Int32, user.Id, false);
      _helper.AddParameter("@name", DbType.String, user.Name, false);
      _helper.AddParameter("@email", DbType.String, user.Email, false);
      _helper.AddParameter("@phone", DbType.String, user.Phone, false);
      _helper.AddParameter("@updated_at", DbType.DateTime2, DateTime.Now, false);
      _helper.AddParameter("@pasword_hash", DbType.String, user.PasswordHash, false);
      _helper.AddParameter("@is_verified", DbType.Boolean, user.IsVerified, false);
      _helper.AddParameter("@status", DbType.String, user.Status.ToString(), false);

      _helper.ExecuteSqlManyResults(query);

      return new UserDefaultDto
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        Phone = user.Phone,
        Role = user.Role,
        Type = user.Type,
        Status = user.Status,
        CreatedAt = user.CreatedAt,
      };
    }
    catch (Exception ex)
    {
      Console.WriteLine("[UserRepository][UpdateUser] " + ex.ToString());
      throw new DataException("Failed to update user. "+ ex.Message);
    }
  }

  public void DeleteUser(UserDefaultDto user) { 
  var existingUser= GetUserByEmail(user.Email);
    const string query = @"Delete FROM [master].[dbo].[t_CRS_Users] WHERE id=@id";
    try {
    _helper.AddParameter("@id", DbType.Int32 , user.Id, false);
      _helper.ExecuteSqlManyResults(query);
    }
    catch (Exception ex) {
      throw new DataException("Couldn't delete User: "+ex.Message);
    }

  }


}
