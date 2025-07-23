using CommercialSpaceRentalV2.Constants.Enums;
using CommercialSpaceRentalV2.Models;
using Sensirion.Data.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CommercialSpaceRentalV2.Repositories
{
  public class AuditLogRepository : BaseRepository
  {


    public AuditLogRepository(SQLHelper helper, ClientInfoService clientInfo)
    : base(helper, clientInfo)
    {
    }

    public void Add(AuditLogModel auditLog)
    {
      const string query = @"
        INSERT INTO MASTER.dbo.t_AuditLog (
          user_id, action_type, target_type, target_id, 
          description, ip_address, created_at
        ) 
        VALUES (
          @user_id, @action_type, @target_type, @target_id, 
          @description, @ip_address, @created_at
        );
      ";

      try
      {
        _helper.AddParameter("@user_id", DbType.Int32, auditLog.UserId, false);
        _helper.AddParameter("@action_type", DbType.String, auditLog.ActionType, false);
        _helper.AddParameter("@target_type", DbType.String, auditLog.TargetType, false);
        _helper.AddParameter("@target_id", DbType.Int32, auditLog.TargetId, false);
        _helper.AddParameter("@description", DbType.String, auditLog.Description, false);
        _helper.AddParameter("@ip_address", DbType.String, auditLog.IpAddress, false);
        _helper.AddParameter("@created_at", DbType.DateTime, auditLog.CreatedAt, false);

        _helper.ExecuteSqlManyResults(query);
      }
      catch (Exception ex)
      {
        Console.WriteLine("[AuditLogRepository][Add] Error: " + ex.Message);
        throw new DataException("Failed to insert audit log.", ex);
      }
    }
    public IEnumerable<AuditLogModel> GetAll() {
      var logs = new List<AuditLogModel>();
      const string query = @"SELECT * FROM [master].[dbo].[t_CRS_Users] ORDER BY created_at DESC;";
      try
      {
        IList<DbDataRecord> records = _helper.ExecuteSqlManyResults(query);
        foreach (DbDataRecord record in records)
        {
          logs.Add(new AuditLogModel
          {
            Id = record.GetInt32(record.GetOrdinal("id")),
            UserId = record.GetInt32(record.GetOrdinal("user_id")),
            ActionType = Enum.Parse<ActionType>(record.GetString(record.GetOrdinal("action_type")), true),
            TargetType = Enum.Parse<TargetType>(record.GetString(record.GetOrdinal("target_type")), true),
            TargetId = record.GetInt32(record.GetOrdinal("target_id")),
            Description = record.GetString(record.GetOrdinal("description")),
            IpAddress = record.GetString(record.GetOrdinal("ip_address")),
            CreatedAt = record.GetDateTime(record.GetOrdinal("created_at"))
          });
        }
      }
      catch (Exception ex)
      {
        throw new DataException("Failed to retrieve logs.", ex);

      }
      return logs;
    }
  }
}
