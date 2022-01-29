using JumpCharge.DbBridge.Clients;
using JumpCharge.DbBridge.Contracts;
using System;
using System.Collections;
using System.Data;

namespace JumpCharge.DbBridge
{
    public class DBBridgeService : IDBManager
    {
        private readonly IDBManager manager = null;
        public DBBridgeService(IDBConfiguration configuration)
        {
            switch (configuration.Provider)
            {
                case DBProvider.MySQL:
                    manager = new MySQL(configuration.Connection);
                    Provider = configuration.Provider;
                    break;

            }
        }
        public DBProvider Provider { get; }
        public DataTable Execute(string query) => manager.Execute(query);
        public DataTable Execute(string query, Hashtable parameters) => manager.Execute(query, parameters);
        public DataTable Execute(string query, Hashtable parameters, CommandType commandType) => manager.Execute(query, parameters, commandType);
        public int ExecuteNonQuery(string query) => manager.ExecuteNonQuery(query);
        public int ExecuteNonQuery(string query, Hashtable parameters) => manager.ExecuteNonQuery(query, parameters);
        public int ExecuteNonQuery(string query, Hashtable parameters, CommandType commandType) => manager.ExecuteNonQuery(query, parameters, commandType);
        public DataSet ExecuteQuery(string query) => manager.ExecuteQuery(query);
        public DataSet ExecuteQuery(string query, Hashtable parameters) => manager.ExecuteQuery(query, parameters);
        public DataSet ExecuteQuery(string query, Hashtable parameters, CommandType commandType) => manager.ExecuteQuery(query, parameters, commandType);
        public object ExecuteScalar(string query) => manager.ExecuteScalar(query);
        public object ExecuteScalar(string query, Hashtable parameters) => manager.ExecuteScalar(query, parameters);
        public object ExecuteScalar(string query, Hashtable parameters, CommandType commandType) => manager.ExecuteScalar(query, parameters, commandType);
        public void Dispose()
        {
            manager.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
