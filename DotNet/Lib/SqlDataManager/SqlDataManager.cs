/************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************
 Created By: EJ Alexandra - 2016
             An Abstract Level, llc
 License:    Mozilla Public License 2.0
 ************************************************
 CODEE42 - AUTO GENERATED FILE - DO NOT OVERWRITE
 ************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

using YesAndOST.Lib.DataClasses;

using CoreLibrary.Extensions;

namespace YesAndOST.Lib.SqlDataManagement
{
    public partial class SqlDataManager : IDisposable
    {
        public SqlDataManager() : this(SqlDataManager.LastConnectionString) 
        {
            this.Schema = "dbo";
        }
    
        public SqlDataManager(String connectionString)
        {
            this.Schema = "dbo";
            this.ConnectionString = connectionString;
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                this.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }
        }

        public SqlDataManager(String dataSourceName, String dbName) 
        {
            this.Schema = "dbo";
            this.DataSourceName = dataSourceName;
            this.DBName = dbName;
        }
        
        public void Dispose() 
        {
            this.IsDisposed = true;
        }
        
        public static string LastConnectionString { get; set; }
        public string ConnectionString { get; set; }
        public String DataSourceName { get; set; }
        public String DBName { get; set; }
        public Boolean IsDisposed { get; set; }
        public String Schema { get; set; }
        

  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Abstraction abstraction)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Abstraction] (AbstractionId, ARMId, StatementId, ParentAbstractionId)
                                    VALUES (@AbstractionId, @ARMId, @StatementId, @ParentAbstractionId)", this.Schema);

                
                  
                if (ReferenceEquals(abstraction.AbstractionId, null)) cmd.Parameters.AddWithValue("@AbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AbstractionId", abstraction.AbstractionId);
                
                  
                if (ReferenceEquals(abstraction.ARMId, null)) cmd.Parameters.AddWithValue("@ARMId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMId", abstraction.ARMId);
                
                  
                if (ReferenceEquals(abstraction.StatementId, null)) cmd.Parameters.AddWithValue("@StatementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementId", abstraction.StatementId);
                
                  
                if (ReferenceEquals(abstraction.ParentAbstractionId, null)) cmd.Parameters.AddWithValue("@ParentAbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ParentAbstractionId", abstraction.ParentAbstractionId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Abstraction abstraction)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = abstraction.AbstractionId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Abstraction] WHERE AbstractionId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(abstraction);
                else return this.Insert(abstraction);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAbstractions<T>()
            where T : Abstraction, new()
        {
            return this.GetAllAbstractions<T>(String.Empty);
        }

        
        public List<T> GetAllAbstractions<T>(String whereClause)
            where T : Abstraction, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Abstraction]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T abstraction = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("AbstractionId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          abstraction.AbstractionId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ARMId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          abstraction.ARMId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("StatementId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          abstraction.StatementId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ParentAbstractionId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          abstraction.ParentAbstractionId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(abstraction);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Abstraction
        /// </summary>
        /// <returns></returns>
        public int Update(Abstraction abstraction)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Abstraction] SET 
                                    ARMId = @ARMId,StatementId = @StatementId,ParentAbstractionId = @ParentAbstractionId
                                    WHERE AbstractionId = @AbstractionId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(abstraction.AbstractionId, null)) cmd.Parameters.AddWithValue("@AbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AbstractionId", abstraction.AbstractionId);
                 //GUID
                
                if (ReferenceEquals(abstraction.ARMId, null)) cmd.Parameters.AddWithValue("@ARMId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMId", abstraction.ARMId);
                 //GUID
                
                if (ReferenceEquals(abstraction.StatementId, null)) cmd.Parameters.AddWithValue("@StatementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementId", abstraction.StatementId);
                 //GUID
                
                if (ReferenceEquals(abstraction.ParentAbstractionId, null)) cmd.Parameters.AddWithValue("@ParentAbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ParentAbstractionId", abstraction.ParentAbstractionId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Abstraction
        /// </summary>
        /// <returns></returns>
        public int Delete(Abstraction abstraction)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Abstraction] 
                                    WHERE AbstractionId = @AbstractionId", this.Schema);
                                    
                
                if (ReferenceEquals(abstraction.AbstractionId, null)) cmd.Parameters.AddWithValue("@AbstractionId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@AbstractionId", abstraction.AbstractionId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(APAAgreement aPAAgreement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[APAAgreement] (APAAgreementId, ARMPersonId, AbstractionId, IAgree)
                                    VALUES (@APAAgreementId, @ARMPersonId, @AbstractionId, @IAgree)", this.Schema);

                
                  
                if (ReferenceEquals(aPAAgreement.APAAgreementId, null)) cmd.Parameters.AddWithValue("@APAAgreementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@APAAgreementId", aPAAgreement.APAAgreementId);
                
                  
                if (ReferenceEquals(aPAAgreement.ARMPersonId, null)) cmd.Parameters.AddWithValue("@ARMPersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMPersonId", aPAAgreement.ARMPersonId);
                
                  
                if (ReferenceEquals(aPAAgreement.AbstractionId, null)) cmd.Parameters.AddWithValue("@AbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AbstractionId", aPAAgreement.AbstractionId);
                
                  
                if (ReferenceEquals(aPAAgreement.IAgree, null)) cmd.Parameters.AddWithValue("@IAgree", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IAgree", aPAAgreement.IAgree);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(APAAgreement aPAAgreement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = aPAAgreement.APAAgreementId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [APAAgreement] WHERE APAAgreementId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(aPAAgreement);
                else return this.Insert(aPAAgreement);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAPAAgreements<T>()
            where T : APAAgreement, new()
        {
            return this.GetAllAPAAgreements<T>(String.Empty);
        }

        
        public List<T> GetAllAPAAgreements<T>(String whereClause)
            where T : APAAgreement, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[APAAgreement]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T aPAAgreement = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("APAAgreementId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aPAAgreement.APAAgreementId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ARMPersonId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aPAAgreement.ARMPersonId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("AbstractionId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aPAAgreement.AbstractionId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("IAgree");
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          aPAAgreement.IAgree = reader.GetBoolean(propertyIndex);
                      }
                   
                    results.Add(aPAAgreement);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified APAAgreement
        /// </summary>
        /// <returns></returns>
        public int Update(APAAgreement aPAAgreement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[APAAgreement] SET 
                                    ARMPersonId = @ARMPersonId,AbstractionId = @AbstractionId,IAgree = @IAgree
                                    WHERE APAAgreementId = @APAAgreementId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(aPAAgreement.APAAgreementId, null)) cmd.Parameters.AddWithValue("@APAAgreementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@APAAgreementId", aPAAgreement.APAAgreementId);
                 //GUID
                
                if (ReferenceEquals(aPAAgreement.ARMPersonId, null)) cmd.Parameters.AddWithValue("@ARMPersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMPersonId", aPAAgreement.ARMPersonId);
                 //GUID
                
                if (ReferenceEquals(aPAAgreement.AbstractionId, null)) cmd.Parameters.AddWithValue("@AbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AbstractionId", aPAAgreement.AbstractionId);
                 //BOOLEAN
                
                if (ReferenceEquals(aPAAgreement.IAgree, null)) cmd.Parameters.AddWithValue("@IAgree", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IAgree", aPAAgreement.IAgree);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified APAAgreement
        /// </summary>
        /// <returns></returns>
        public int Delete(APAAgreement aPAAgreement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[APAAgreement] 
                                    WHERE APAAgreementId = @APAAgreementId", this.Schema);
                                    
                
                if (ReferenceEquals(aPAAgreement.APAAgreementId, null)) cmd.Parameters.AddWithValue("@APAAgreementId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@APAAgreementId", aPAAgreement.APAAgreementId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(ARM aRM)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[ARM] (ARMId, Name, Started, Completed, IsComplete, InviteCode, FocusAbstractionId)
                                    VALUES (@ARMId, @Name, @Started, @Completed, @IsComplete, @InviteCode, @FocusAbstractionId)", this.Schema);

                
                  
                if (ReferenceEquals(aRM.ARMId, null)) cmd.Parameters.AddWithValue("@ARMId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMId", aRM.ARMId);
                
                  
                if (ReferenceEquals(aRM.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", aRM.Name);
                
                  
                if (ReferenceEquals(aRM.Started, null) ||
                    (aRM.Started == DateTime.MinValue)) cmd.Parameters.AddWithValue("@Started", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@Started", aRM.Started);
                
                  
                if (ReferenceEquals(aRM.Completed, null) ||
                    (aRM.Completed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@Completed", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@Completed", aRM.Completed);
                
                  
                if (ReferenceEquals(aRM.IsComplete, null)) cmd.Parameters.AddWithValue("@IsComplete", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsComplete", aRM.IsComplete);
                
                  
                if (ReferenceEquals(aRM.InviteCode, null)) cmd.Parameters.AddWithValue("@InviteCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@InviteCode", aRM.InviteCode);
                
                  
                if (ReferenceEquals(aRM.FocusAbstractionId, null)) cmd.Parameters.AddWithValue("@FocusAbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@FocusAbstractionId", aRM.FocusAbstractionId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(ARM aRM)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = aRM.ARMId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [ARM] WHERE ARMId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(aRM);
                else return this.Insert(aRM);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllARMs<T>()
            where T : ARM, new()
        {
            return this.GetAllARMs<T>(String.Empty);
        }

        
        public List<T> GetAllARMs<T>(String whereClause)
            where T : ARM, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[ARM]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T aRM = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ARMId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRM.ARMId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          aRM.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Started");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          aRM.Started = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Completed");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          aRM.Completed = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("IsComplete");
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          aRM.IsComplete = reader.GetBoolean(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("InviteCode");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRM.InviteCode = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("FocusAbstractionId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRM.FocusAbstractionId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(aRM);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified ARM
        /// </summary>
        /// <returns></returns>
        public int Update(ARM aRM)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[ARM] SET 
                                    Name = @Name,Started = @Started,Completed = @Completed,IsComplete = @IsComplete,InviteCode = @InviteCode,FocusAbstractionId = @FocusAbstractionId
                                    WHERE ARMId = @ARMId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(aRM.ARMId, null)) cmd.Parameters.AddWithValue("@ARMId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMId", aRM.ARMId);
                 //NTEXT
                
                if (ReferenceEquals(aRM.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", aRM.Name);
                 //DATETIME
                
                if (ReferenceEquals(aRM.Started, null) ||
                    (aRM.Started == DateTime.MinValue)) cmd.Parameters.AddWithValue("@Started", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@Started", aRM.Started);
                 //DATETIME
                
                if (ReferenceEquals(aRM.Completed, null) ||
                    (aRM.Completed == DateTime.MinValue)) cmd.Parameters.AddWithValue("@Completed", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@Completed", aRM.Completed);
                 //BOOLEAN
                
                if (ReferenceEquals(aRM.IsComplete, null)) cmd.Parameters.AddWithValue("@IsComplete", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsComplete", aRM.IsComplete);
                 //GUID
                
                if (ReferenceEquals(aRM.InviteCode, null)) cmd.Parameters.AddWithValue("@InviteCode", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@InviteCode", aRM.InviteCode);
                 //GUID
                
                if (ReferenceEquals(aRM.FocusAbstractionId, null)) cmd.Parameters.AddWithValue("@FocusAbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@FocusAbstractionId", aRM.FocusAbstractionId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified ARM
        /// </summary>
        /// <returns></returns>
        public int Delete(ARM aRM)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[ARM] 
                                    WHERE ARMId = @ARMId", this.Schema);
                                    
                
                if (ReferenceEquals(aRM.ARMId, null)) cmd.Parameters.AddWithValue("@ARMId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ARMId", aRM.ARMId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(ARMChat aRMChat)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[ARMChat] (ARMChatId, CreatedAt, ARMPersonId, AbstractionId, StatementId)
                                    VALUES (@ARMChatId, @CreatedAt, @ARMPersonId, @AbstractionId, @StatementId)", this.Schema);

                
                  
                if (ReferenceEquals(aRMChat.ARMChatId, null)) cmd.Parameters.AddWithValue("@ARMChatId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMChatId", aRMChat.ARMChatId);
                
                  
                if (ReferenceEquals(aRMChat.CreatedAt, null) ||
                    (aRMChat.CreatedAt == DateTime.MinValue)) cmd.Parameters.AddWithValue("@CreatedAt", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@CreatedAt", aRMChat.CreatedAt);
                
                  
                if (ReferenceEquals(aRMChat.ARMPersonId, null)) cmd.Parameters.AddWithValue("@ARMPersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMPersonId", aRMChat.ARMPersonId);
                
                  
                if (ReferenceEquals(aRMChat.AbstractionId, null)) cmd.Parameters.AddWithValue("@AbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AbstractionId", aRMChat.AbstractionId);
                
                  
                if (ReferenceEquals(aRMChat.StatementId, null)) cmd.Parameters.AddWithValue("@StatementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementId", aRMChat.StatementId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(ARMChat aRMChat)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = aRMChat.ARMChatId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [ARMChat] WHERE ARMChatId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(aRMChat);
                else return this.Insert(aRMChat);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllARMChats<T>()
            where T : ARMChat, new()
        {
            return this.GetAllARMChats<T>(String.Empty);
        }

        
        public List<T> GetAllARMChats<T>(String whereClause)
            where T : ARMChat, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[ARMChat]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T aRMChat = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ARMChatId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRMChat.ARMChatId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CreatedAt");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          aRMChat.CreatedAt = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ARMPersonId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRMChat.ARMPersonId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("AbstractionId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRMChat.AbstractionId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("StatementId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRMChat.StatementId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(aRMChat);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified ARMChat
        /// </summary>
        /// <returns></returns>
        public int Update(ARMChat aRMChat)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[ARMChat] SET 
                                    CreatedAt = @CreatedAt,ARMPersonId = @ARMPersonId,AbstractionId = @AbstractionId,StatementId = @StatementId
                                    WHERE ARMChatId = @ARMChatId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(aRMChat.ARMChatId, null)) cmd.Parameters.AddWithValue("@ARMChatId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMChatId", aRMChat.ARMChatId);
                 //DATETIME
                
                if (ReferenceEquals(aRMChat.CreatedAt, null) ||
                    (aRMChat.CreatedAt == DateTime.MinValue)) cmd.Parameters.AddWithValue("@CreatedAt", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@CreatedAt", aRMChat.CreatedAt);
                 //GUID
                
                if (ReferenceEquals(aRMChat.ARMPersonId, null)) cmd.Parameters.AddWithValue("@ARMPersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMPersonId", aRMChat.ARMPersonId);
                 //GUID
                
                if (ReferenceEquals(aRMChat.AbstractionId, null)) cmd.Parameters.AddWithValue("@AbstractionId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AbstractionId", aRMChat.AbstractionId);
                 //GUID
                
                if (ReferenceEquals(aRMChat.StatementId, null)) cmd.Parameters.AddWithValue("@StatementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementId", aRMChat.StatementId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified ARMChat
        /// </summary>
        /// <returns></returns>
        public int Delete(ARMChat aRMChat)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[ARMChat] 
                                    WHERE ARMChatId = @ARMChatId", this.Schema);
                                    
                
                if (ReferenceEquals(aRMChat.ARMChatId, null)) cmd.Parameters.AddWithValue("@ARMChatId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ARMChatId", aRMChat.ARMChatId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(ARMPerson aRMPerson)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[ARMPerson] (ARMPersonId, AvatarId, ARMId, JoinedOn)
                                    VALUES (@ARMPersonId, @AvatarId, @ARMId, @JoinedOn)", this.Schema);

                
                  
                if (ReferenceEquals(aRMPerson.ARMPersonId, null)) cmd.Parameters.AddWithValue("@ARMPersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMPersonId", aRMPerson.ARMPersonId);
                
                  
                if (ReferenceEquals(aRMPerson.AvatarId, null)) cmd.Parameters.AddWithValue("@AvatarId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AvatarId", aRMPerson.AvatarId);
                
                  
                if (ReferenceEquals(aRMPerson.ARMId, null)) cmd.Parameters.AddWithValue("@ARMId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMId", aRMPerson.ARMId);
                
                  
                if (ReferenceEquals(aRMPerson.JoinedOn, null) ||
                    (aRMPerson.JoinedOn == DateTime.MinValue)) cmd.Parameters.AddWithValue("@JoinedOn", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@JoinedOn", aRMPerson.JoinedOn);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(ARMPerson aRMPerson)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = aRMPerson.ARMPersonId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [ARMPerson] WHERE ARMPersonId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(aRMPerson);
                else return this.Insert(aRMPerson);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllARMPersons<T>()
            where T : ARMPerson, new()
        {
            return this.GetAllARMPersons<T>(String.Empty);
        }

        
        public List<T> GetAllARMPersons<T>(String whereClause)
            where T : ARMPerson, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[ARMPerson]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T aRMPerson = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("ARMPersonId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRMPerson.ARMPersonId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("AvatarId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRMPerson.AvatarId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ARMId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          aRMPerson.ARMId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("JoinedOn");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          aRMPerson.JoinedOn = reader.GetDateTime(propertyIndex);
                      }
                   
                    results.Add(aRMPerson);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified ARMPerson
        /// </summary>
        /// <returns></returns>
        public int Update(ARMPerson aRMPerson)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[ARMPerson] SET 
                                    AvatarId = @AvatarId,ARMId = @ARMId,JoinedOn = @JoinedOn
                                    WHERE ARMPersonId = @ARMPersonId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(aRMPerson.ARMPersonId, null)) cmd.Parameters.AddWithValue("@ARMPersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMPersonId", aRMPerson.ARMPersonId);
                 //GUID
                
                if (ReferenceEquals(aRMPerson.AvatarId, null)) cmd.Parameters.AddWithValue("@AvatarId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AvatarId", aRMPerson.AvatarId);
                 //GUID
                
                if (ReferenceEquals(aRMPerson.ARMId, null)) cmd.Parameters.AddWithValue("@ARMId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMId", aRMPerson.ARMId);
                 //DATETIME
                
                if (ReferenceEquals(aRMPerson.JoinedOn, null) ||
                    (aRMPerson.JoinedOn == DateTime.MinValue)) cmd.Parameters.AddWithValue("@JoinedOn", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@JoinedOn", aRMPerson.JoinedOn);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified ARMPerson
        /// </summary>
        /// <returns></returns>
        public int Delete(ARMPerson aRMPerson)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[ARMPerson] 
                                    WHERE ARMPersonId = @ARMPersonId", this.Schema);
                                    
                
                if (ReferenceEquals(aRMPerson.ARMPersonId, null)) cmd.Parameters.AddWithValue("@ARMPersonId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ARMPersonId", aRMPerson.ARMPersonId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(AuthToken authToken)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[AuthToken] (AuthTokenId, PersonId, TemporaryAccessToken, HashedToken, CreatedOn, ExpiresOn)
                                    VALUES (@AuthTokenId, @PersonId, @TemporaryAccessToken, @HashedToken, @CreatedOn, @ExpiresOn)", this.Schema);

                
                  
                if (ReferenceEquals(authToken.AuthTokenId, null)) cmd.Parameters.AddWithValue("@AuthTokenId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AuthTokenId", authToken.AuthTokenId);
                
                  
                if (ReferenceEquals(authToken.PersonId, null)) cmd.Parameters.AddWithValue("@PersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PersonId", authToken.PersonId);
                
                  
                if (ReferenceEquals(authToken.TemporaryAccessToken, null)) cmd.Parameters.AddWithValue("@TemporaryAccessToken", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TemporaryAccessToken", authToken.TemporaryAccessToken);
                
                  
                if (ReferenceEquals(authToken.HashedToken, null)) cmd.Parameters.AddWithValue("@HashedToken", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@HashedToken", authToken.HashedToken);
                
                  
                if (ReferenceEquals(authToken.CreatedOn, null) ||
                    (authToken.CreatedOn == DateTime.MinValue)) cmd.Parameters.AddWithValue("@CreatedOn", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@CreatedOn", authToken.CreatedOn);
                
                  
                if (ReferenceEquals(authToken.ExpiresOn, null) ||
                    (authToken.ExpiresOn == DateTime.MinValue)) cmd.Parameters.AddWithValue("@ExpiresOn", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@ExpiresOn", authToken.ExpiresOn);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(AuthToken authToken)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = authToken.AuthTokenId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [AuthToken] WHERE AuthTokenId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(authToken);
                else return this.Insert(authToken);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAuthTokens<T>()
            where T : AuthToken, new()
        {
            return this.GetAllAuthTokens<T>(String.Empty);
        }

        
        public List<T> GetAllAuthTokens<T>(String whereClause)
            where T : AuthToken, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[AuthToken]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T authToken = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("AuthTokenId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          authToken.AuthTokenId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("PersonId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          authToken.PersonId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("TemporaryAccessToken");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          authToken.TemporaryAccessToken = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("HashedToken");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          authToken.HashedToken = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("CreatedOn");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          authToken.CreatedOn = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ExpiresOn");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          authToken.ExpiresOn = reader.GetDateTime(propertyIndex);
                      }
                   
                    results.Add(authToken);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified AuthToken
        /// </summary>
        /// <returns></returns>
        public int Update(AuthToken authToken)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[AuthToken] SET 
                                    PersonId = @PersonId,TemporaryAccessToken = @TemporaryAccessToken,HashedToken = @HashedToken,CreatedOn = @CreatedOn,ExpiresOn = @ExpiresOn
                                    WHERE AuthTokenId = @AuthTokenId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(authToken.AuthTokenId, null)) cmd.Parameters.AddWithValue("@AuthTokenId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AuthTokenId", authToken.AuthTokenId);
                 //GUID
                
                if (ReferenceEquals(authToken.PersonId, null)) cmd.Parameters.AddWithValue("@PersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PersonId", authToken.PersonId);
                 //GUID
                
                if (ReferenceEquals(authToken.TemporaryAccessToken, null)) cmd.Parameters.AddWithValue("@TemporaryAccessToken", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@TemporaryAccessToken", authToken.TemporaryAccessToken);
                 //NTEXT
                
                if (ReferenceEquals(authToken.HashedToken, null)) cmd.Parameters.AddWithValue("@HashedToken", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@HashedToken", authToken.HashedToken);
                 //DATETIME
                
                if (ReferenceEquals(authToken.CreatedOn, null) ||
                    (authToken.CreatedOn == DateTime.MinValue)) cmd.Parameters.AddWithValue("@CreatedOn", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@CreatedOn", authToken.CreatedOn);
                 //DATETIME
                
                if (ReferenceEquals(authToken.ExpiresOn, null) ||
                    (authToken.ExpiresOn == DateTime.MinValue)) cmd.Parameters.AddWithValue("@ExpiresOn", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@ExpiresOn", authToken.ExpiresOn);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified AuthToken
        /// </summary>
        /// <returns></returns>
        public int Delete(AuthToken authToken)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[AuthToken] 
                                    WHERE AuthTokenId = @AuthTokenId", this.Schema);
                                    
                
                if (ReferenceEquals(authToken.AuthTokenId, null)) cmd.Parameters.AddWithValue("@AuthTokenId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@AuthTokenId", authToken.AuthTokenId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Avatar avatar)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Avatar] (AvatarId, Handle, Description, Nickname)
                                    VALUES (@AvatarId, @Handle, @Description, @Nickname)", this.Schema);

                
                  
                if (ReferenceEquals(avatar.AvatarId, null)) cmd.Parameters.AddWithValue("@AvatarId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AvatarId", avatar.AvatarId);
                
                  
                if (ReferenceEquals(avatar.Handle, null)) cmd.Parameters.AddWithValue("@Handle", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Handle", avatar.Handle);
                
                  
                if (ReferenceEquals(avatar.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", avatar.Description);
                
                  
                if (ReferenceEquals(avatar.Nickname, null)) cmd.Parameters.AddWithValue("@Nickname", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Nickname", avatar.Nickname);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Avatar avatar)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = avatar.AvatarId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Avatar] WHERE AvatarId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(avatar);
                else return this.Insert(avatar);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllAvatars<T>()
            where T : Avatar, new()
        {
            return this.GetAllAvatars<T>(String.Empty);
        }

        
        public List<T> GetAllAvatars<T>(String whereClause)
            where T : Avatar, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Avatar]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T avatar = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("AvatarId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          avatar.AvatarId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Handle");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          avatar.Handle = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Description");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          avatar.Description = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Nickname");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          avatar.Nickname = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(avatar);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Avatar
        /// </summary>
        /// <returns></returns>
        public int Update(Avatar avatar)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Avatar] SET 
                                    Handle = @Handle,Description = @Description,Nickname = @Nickname
                                    WHERE AvatarId = @AvatarId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(avatar.AvatarId, null)) cmd.Parameters.AddWithValue("@AvatarId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@AvatarId", avatar.AvatarId);
                 //NTEXT
                
                if (ReferenceEquals(avatar.Handle, null)) cmd.Parameters.AddWithValue("@Handle", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Handle", avatar.Handle);
                 //NTEXT
                
                if (ReferenceEquals(avatar.Description, null)) cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Description", avatar.Description);
                 //NTEXT
                
                if (ReferenceEquals(avatar.Nickname, null)) cmd.Parameters.AddWithValue("@Nickname", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Nickname", avatar.Nickname);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Avatar
        /// </summary>
        /// <returns></returns>
        public int Delete(Avatar avatar)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Avatar] 
                                    WHERE AvatarId = @AvatarId", this.Schema);
                                    
                
                if (ReferenceEquals(avatar.AvatarId, null)) cmd.Parameters.AddWithValue("@AvatarId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@AvatarId", avatar.AvatarId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Person person)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Person] (PersonId, Name, EmailAddress, IsEmailVerified, PhoneNumber, IsPhoneerified, DOB, SSN, PreferredHandle)
                                    VALUES (@PersonId, @Name, @EmailAddress, @IsEmailVerified, @PhoneNumber, @IsPhoneerified, @DOB, @SSN, @PreferredHandle)", this.Schema);

                
                  
                if (ReferenceEquals(person.PersonId, null)) cmd.Parameters.AddWithValue("@PersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
                
                  
                if (ReferenceEquals(person.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", person.Name);
                
                  
                if (ReferenceEquals(person.EmailAddress, null)) cmd.Parameters.AddWithValue("@EmailAddress", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@EmailAddress", person.EmailAddress);
                
                  
                if (ReferenceEquals(person.IsEmailVerified, null)) cmd.Parameters.AddWithValue("@IsEmailVerified", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsEmailVerified", person.IsEmailVerified);
                
                  
                if (ReferenceEquals(person.PhoneNumber, null)) cmd.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                
                  
                if (ReferenceEquals(person.IsPhoneerified, null)) cmd.Parameters.AddWithValue("@IsPhoneerified", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsPhoneerified", person.IsPhoneerified);
                
                  
                if (ReferenceEquals(person.DOB, null) ||
                    (person.DOB == DateTime.MinValue)) cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@DOB", person.DOB);
                
                  
                if (ReferenceEquals(person.SSN, null)) cmd.Parameters.AddWithValue("@SSN", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SSN", person.SSN);
                
                  
                if (ReferenceEquals(person.PreferredHandle, null)) cmd.Parameters.AddWithValue("@PreferredHandle", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PreferredHandle", person.PreferredHandle);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Person person)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = person.PersonId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Person] WHERE PersonId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(person);
                else return this.Insert(person);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllPersons<T>()
            where T : Person, new()
        {
            return this.GetAllPersons<T>(String.Empty);
        }

        
        public List<T> GetAllPersons<T>(String whereClause)
            where T : Person, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Person]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T person = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("PersonId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          person.PersonId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Name");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          person.Name = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("EmailAddress");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          person.EmailAddress = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("IsEmailVerified");
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          person.IsEmailVerified = reader.GetBoolean(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("PhoneNumber");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          person.PhoneNumber = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("IsPhoneerified");
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          person.IsPhoneerified = reader.GetBoolean(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("DOB");
                      if (!reader.IsDBNull(propertyIndex)) //DATETIME
                      {
                          
                          person.DOB = reader.GetDateTime(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("SSN");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          person.SSN = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("PreferredHandle");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          person.PreferredHandle = reader.GetString(propertyIndex);
                      }
                   
                    results.Add(person);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Person
        /// </summary>
        /// <returns></returns>
        public int Update(Person person)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Person] SET 
                                    Name = @Name,EmailAddress = @EmailAddress,IsEmailVerified = @IsEmailVerified,PhoneNumber = @PhoneNumber,IsPhoneerified = @IsPhoneerified,DOB = @DOB,SSN = @SSN,PreferredHandle = @PreferredHandle
                                    WHERE PersonId = @PersonId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(person.PersonId, null)) cmd.Parameters.AddWithValue("@PersonId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
                 //NTEXT
                
                if (ReferenceEquals(person.Name, null)) cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Name", person.Name);
                 //NTEXT
                
                if (ReferenceEquals(person.EmailAddress, null)) cmd.Parameters.AddWithValue("@EmailAddress", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@EmailAddress", person.EmailAddress);
                 //BOOLEAN
                
                if (ReferenceEquals(person.IsEmailVerified, null)) cmd.Parameters.AddWithValue("@IsEmailVerified", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsEmailVerified", person.IsEmailVerified);
                 //NTEXT
                
                if (ReferenceEquals(person.PhoneNumber, null)) cmd.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                 //BOOLEAN
                
                if (ReferenceEquals(person.IsPhoneerified, null)) cmd.Parameters.AddWithValue("@IsPhoneerified", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@IsPhoneerified", person.IsPhoneerified);
                 //DATETIME
                
                if (ReferenceEquals(person.DOB, null) ||
                    (person.DOB == DateTime.MinValue)) cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                  
                else cmd.Parameters.AddWithValue("@DOB", person.DOB);
                 //NTEXT
                
                if (ReferenceEquals(person.SSN, null)) cmd.Parameters.AddWithValue("@SSN", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@SSN", person.SSN);
                 //NTEXT
                
                if (ReferenceEquals(person.PreferredHandle, null)) cmd.Parameters.AddWithValue("@PreferredHandle", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@PreferredHandle", person.PreferredHandle);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Person
        /// </summary>
        /// <returns></returns>
        public int Delete(Person person)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Person] 
                                    WHERE PersonId = @PersonId", this.Schema);
                                    
                
                if (ReferenceEquals(person.PersonId, null)) cmd.Parameters.AddWithValue("@PersonId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@PersonId", person.PersonId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(Statement statement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[Statement] (StatementId, StatementText, StrippedStatementText, OriginalMD5Hash, StrippedMD5Hash)
                                    VALUES (@StatementId, @StatementText, @StrippedStatementText, @OriginalMD5Hash, @StrippedMD5Hash)", this.Schema);

                
                  
                if (ReferenceEquals(statement.StatementId, null)) cmd.Parameters.AddWithValue("@StatementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementId", statement.StatementId);
                
                  
                if (ReferenceEquals(statement.StatementText, null)) cmd.Parameters.AddWithValue("@StatementText", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementText", statement.StatementText);
                
                  
                if (ReferenceEquals(statement.StrippedStatementText, null)) cmd.Parameters.AddWithValue("@StrippedStatementText", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StrippedStatementText", statement.StrippedStatementText);
                
                  
                if (ReferenceEquals(statement.OriginalMD5Hash, null)) cmd.Parameters.AddWithValue("@OriginalMD5Hash", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@OriginalMD5Hash", statement.OriginalMD5Hash);
                
                  
                if (ReferenceEquals(statement.StrippedMD5Hash, null)) cmd.Parameters.AddWithValue("@StrippedMD5Hash", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StrippedMD5Hash", statement.StrippedMD5Hash);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(Statement statement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = statement.StatementId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [Statement] WHERE StatementId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(statement);
                else return this.Insert(statement);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllStatements<T>()
            where T : Statement, new()
        {
            return this.GetAllStatements<T>(String.Empty);
        }

        
        public List<T> GetAllStatements<T>(String whereClause)
            where T : Statement, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[Statement]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T statement = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("StatementId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          statement.StatementId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("StatementText");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          statement.StatementText = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("StrippedStatementText");
                      if (!reader.IsDBNull(propertyIndex)) //NTEXT
                      {
                          
                          statement.StrippedStatementText = reader.GetString(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("OriginalMD5Hash");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          statement.OriginalMD5Hash = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("StrippedMD5Hash");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          statement.StrippedMD5Hash = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(statement);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified Statement
        /// </summary>
        /// <returns></returns>
        public int Update(Statement statement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[Statement] SET 
                                    StatementText = @StatementText,StrippedStatementText = @StrippedStatementText,OriginalMD5Hash = @OriginalMD5Hash,StrippedMD5Hash = @StrippedMD5Hash
                                    WHERE StatementId = @StatementId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(statement.StatementId, null)) cmd.Parameters.AddWithValue("@StatementId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementId", statement.StatementId);
                 //NTEXT
                
                if (ReferenceEquals(statement.StatementText, null)) cmd.Parameters.AddWithValue("@StatementText", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StatementText", statement.StatementText);
                 //NTEXT
                
                if (ReferenceEquals(statement.StrippedStatementText, null)) cmd.Parameters.AddWithValue("@StrippedStatementText", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StrippedStatementText", statement.StrippedStatementText);
                 //GUID
                
                if (ReferenceEquals(statement.OriginalMD5Hash, null)) cmd.Parameters.AddWithValue("@OriginalMD5Hash", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@OriginalMD5Hash", statement.OriginalMD5Hash);
                 //GUID
                
                if (ReferenceEquals(statement.StrippedMD5Hash, null)) cmd.Parameters.AddWithValue("@StrippedMD5Hash", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@StrippedMD5Hash", statement.StrippedMD5Hash);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified Statement
        /// </summary>
        /// <returns></returns>
        public int Delete(Statement statement)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[Statement] 
                                    WHERE StatementId = @StatementId", this.Schema);
                                    
                
                if (ReferenceEquals(statement.StatementId, null)) cmd.Parameters.AddWithValue("@StatementId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@StatementId", statement.StatementId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

          
  
        /// <summary>
        /// Returns a count of the numbers of rows affected by the insert
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
  
  
  
        public int Insert(YesAnd yesAnd)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"INSERT INTO [{0}].[YesAnd] (YesAndId, ARMChatId, Yes, YesAndAlso, YesAndARMChatId)
                                    VALUES (@YesAndId, @ARMChatId, @Yes, @YesAndAlso, @YesAndARMChatId)", this.Schema);

                
                  
                if (ReferenceEquals(yesAnd.YesAndId, null)) cmd.Parameters.AddWithValue("@YesAndId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@YesAndId", yesAnd.YesAndId);
                
                  
                if (ReferenceEquals(yesAnd.ARMChatId, null)) cmd.Parameters.AddWithValue("@ARMChatId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMChatId", yesAnd.ARMChatId);
                
                  
                if (ReferenceEquals(yesAnd.Yes, null)) cmd.Parameters.AddWithValue("@Yes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Yes", yesAnd.Yes);
                
                  
                if (ReferenceEquals(yesAnd.YesAndAlso, null)) cmd.Parameters.AddWithValue("@YesAndAlso", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@YesAndAlso", yesAnd.YesAndAlso);
                
                  
                if (ReferenceEquals(yesAnd.YesAndARMChatId, null)) cmd.Parameters.AddWithValue("@YesAndARMChatId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@YesAndARMChatId", yesAnd.YesAndARMChatId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
          /// <summary>
        /// Returns a count of the numbers of rows affected by the Upsert.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dataSource"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public int Upsert(YesAnd yesAnd)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                
                // Check if this method exists, and call insert or udpate as appropriate
                
                
                var id = yesAnd.YesAndId;
                cmd.CommandText = String.Format(@"SELECT CASE WHEN EXISTS (SELECT * FROM [YesAnd] WHERE YesAndId = '{0}') THEN 1 else 0 END", id);
                
                var rowExists = cmd.ExecuteScalar();

                if (rowExists.SafeToString() == "1") return this.Update(yesAnd);
                else return this.Insert(yesAnd);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public List<T> GetAllYesAnds<T>()
            where T : YesAnd, new()
        {
            return this.GetAllYesAnds<T>(String.Empty);
        }

        
        public List<T> GetAllYesAnds<T>(String whereClause)
            where T : YesAnd, new()
        {
            List<T> results = new List<T>();
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"SELECT * FROM [{0}].[YesAnd]", this.Schema);
                if (!String.IsNullOrEmpty(whereClause)) 
                {
                    cmd.CommandText = String.Format("{0} WHERE {1}", cmd.CommandText, whereClause);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                
                int propertyIndex = -1;
                while (reader.Read())
                {
                    T yesAnd = new T();
                    
                    
                      propertyIndex = reader.GetOrdinal("YesAndId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          yesAnd.YesAndId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("ARMChatId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          yesAnd.ARMChatId = reader.GetGuid(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("Yes");
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          yesAnd.Yes = reader.GetBoolean(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("YesAndAlso");
                      if (!reader.IsDBNull(propertyIndex)) //BOOLEAN
                      {
                          
                          yesAnd.YesAndAlso = reader.GetBoolean(propertyIndex);
                      }
                   
                      propertyIndex = reader.GetOrdinal("YesAndARMChatId");
                      if (!reader.IsDBNull(propertyIndex)) //GUID
                      {
                          
                          yesAnd.YesAndARMChatId = reader.GetGuid(propertyIndex);
                      }
                   
                    results.Add(yesAnd);
                }

                return results;
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Updates the specified YesAnd
        /// </summary>
        /// <returns></returns>
        public int Update(YesAnd yesAnd)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"UPDATE [{0}].[YesAnd] SET 
                                    ARMChatId = @ARMChatId,Yes = @Yes,YesAndAlso = @YesAndAlso,YesAndARMChatId = @YesAndARMChatId
                                    WHERE YesAndId = @YesAndId", this.Schema);

                 //GUID
                
                if (ReferenceEquals(yesAnd.YesAndId, null)) cmd.Parameters.AddWithValue("@YesAndId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@YesAndId", yesAnd.YesAndId);
                 //GUID
                
                if (ReferenceEquals(yesAnd.ARMChatId, null)) cmd.Parameters.AddWithValue("@ARMChatId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@ARMChatId", yesAnd.ARMChatId);
                 //BOOLEAN
                
                if (ReferenceEquals(yesAnd.Yes, null)) cmd.Parameters.AddWithValue("@Yes", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@Yes", yesAnd.Yes);
                 //BOOLEAN
                
                if (ReferenceEquals(yesAnd.YesAndAlso, null)) cmd.Parameters.AddWithValue("@YesAndAlso", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@YesAndAlso", yesAnd.YesAndAlso);
                 //GUID
                
                if (ReferenceEquals(yesAnd.YesAndARMChatId, null)) cmd.Parameters.AddWithValue("@YesAndARMChatId", DBNull.Value);
                    
                else cmd.Parameters.AddWithValue("@YesAndARMChatId", yesAnd.YesAndARMChatId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
        
                
        /// <summary>
        /// Deletes the specified YesAnd
        /// </summary>
        /// <returns></returns>
        public int Delete(YesAnd yesAnd)
        {
            SqlConnection conn = this.CreateSqlConnection();
            try
            {
                this.InitializeConnection(conn);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format(@"DELETE FROM [{0}].[YesAnd] 
                                    WHERE YesAndId = @YesAndId", this.Schema);
                                    
                
                if (ReferenceEquals(yesAnd.YesAndId, null)) cmd.Parameters.AddWithValue("@YesAndId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@YesAndId", yesAnd.YesAndId);
                

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }

                  
            
            

        public object LastIdentity { get; set; }
        public string ExecuteAsUser { get; set; }
        
        private SqlConnection CreateSqlConnection() 
        {
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = this.DataSourceName;
                scsb.InitialCatalog = this.DBName;
                scsb.IntegratedSecurity = true;
                this.ConnectionString = scsb.ConnectionString;
            }
            
            SqlDataManager.LastConnectionString = this.ConnectionString;
            
            return new SqlConnection(this.ConnectionString);
        }
        
        
        private void InitializeConnection(SqlConnection conn)
        {
            conn.Open();
            if (!String.IsNullOrEmpty(this.ExecuteAsUser))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("EXECUTE AS USER='{0}'", this.ExecuteAsUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

      