using System;
using System.Collections;
using System.Data;

namespace JumpCharge.DbBridge.Contracts
{
    public enum DBProvider
    {
        MySQL
    }
    public interface IDBManager : IDisposable
    {
        DBProvider Provider { get; }
        DataTable Execute(string query);
        DataTable Execute(string query, Hashtable parameters);
        DataTable Execute(string query, Hashtable parameters, CommandType commandType);
        DataSet ExecuteQuery(string query);
        DataSet ExecuteQuery(string query, Hashtable parameters);
        DataSet ExecuteQuery(string query, Hashtable parameters, CommandType commandType);
        int ExecuteNonQuery(string query);
        int ExecuteNonQuery(string query, Hashtable parameters);
        int ExecuteNonQuery(string query, Hashtable parameters, CommandType commandType);
        object ExecuteScalar(string query);
        object ExecuteScalar(string query, Hashtable parameters);
        object ExecuteScalar(string query, Hashtable parameters, CommandType commandType);
    }
}
