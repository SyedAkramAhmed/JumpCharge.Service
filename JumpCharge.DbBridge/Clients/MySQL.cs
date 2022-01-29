using JumpCharge.DbBridge.Contracts;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

namespace JumpCharge.DbBridge.Clients
{
    public class MySQL : IDBManager
    {
        private MySqlCommand _mysqlCommand = null;
        private MySqlDataAdapter _objAdaptor = null;
        private MySqlConnection _connection = null;
        public MySQL(string connection)
        {
            try
            {
                _connection = new MySqlConnection(connection);
                _connection.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DBProvider Provider => DBProvider.SQL;
        public DataTable Execute(string query)
        {
            return Execute(query, new Hashtable(), CommandType.Text);
        }
        public DataTable Execute(string query, Hashtable parameters)
        {
            return Execute(query, parameters, CommandType.StoredProcedure);
        }
        public DataTable Execute(string query, Hashtable parameters, CommandType commandType)
        {
            DataTable dt = new DataTable();
            try
            {
                _mysqlCommand = Command(commandType, query, parameters);
                _objAdaptor = DataAdaptor();
                _objAdaptor.Fill(dt);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex) { throw ex; }
            return dt;
        }
        public int ExecuteNonQuery(string query)
        {
            return ExecuteNonQuery(query, new Hashtable(), CommandType.Text);
        }
        public int ExecuteNonQuery(string query, Hashtable parameters)
        {
            return ExecuteNonQuery(query, parameters, CommandType.StoredProcedure);
        }
        public int ExecuteNonQuery(string query, Hashtable parameters, CommandType commandType)
        {
            int result = 0;
            try
            {
                _mysqlCommand = Command(commandType, query, parameters);
                result = _mysqlCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex) { throw ex; }
            return result;

        }
        public DataSet ExecuteQuery(string query)
        {
            return ExecuteQuery(query, new Hashtable(), CommandType.Text);
        }
        public DataSet ExecuteQuery(string query, Hashtable parameters)
        {
            return ExecuteQuery(query, parameters, CommandType.StoredProcedure);
        }
        public DataSet ExecuteQuery(string query, Hashtable parameters, CommandType commandType)
        {
            DataSet objData = new DataSet();
            try
            {
                _mysqlCommand = Command(commandType, query, parameters);
                _objAdaptor = DataAdaptor();
                _objAdaptor.Fill(objData);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objData;
        }
        public object ExecuteScalar(string query)
        {
            return ExecuteScalar(query, new Hashtable(), CommandType.Text);
        }
        public object ExecuteScalar(string query, Hashtable parameters)
        {
            return ExecuteScalar(query, parameters, CommandType.StoredProcedure);
        }
        public object ExecuteScalar(string query, Hashtable parameters, CommandType commandType)
        {
            object objresult = null;
            try
            {
                _mysqlCommand = Command(commandType, query, parameters);
                objresult = _mysqlCommand.ExecuteScalar();

            }
            catch (MySqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            return objresult;
        }
        public void Dispose()
        {
            if (_objAdaptor != null) { _objAdaptor.Dispose(); _objAdaptor = null; }
            if (_mysqlCommand != null) { _mysqlCommand.Dispose(); _mysqlCommand = null; }
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
            GC.SuppressFinalize(this);
        }
        private MySqlCommand Command(CommandType type, string text, Hashtable parameters)
        {
            if (_mysqlCommand == null)
            {
                _mysqlCommand = new MySqlCommand(text, _connection);
            }
            else
            {
                _mysqlCommand.CommandText = text;
                _mysqlCommand.Parameters.Clear();
            }
            _mysqlCommand.CommandType = type;
            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    _mysqlCommand.Parameters.AddWithValue(key, parameters[key]);
                }
            }
            return _mysqlCommand;
        }
        private MySqlDataAdapter DataAdaptor()
        {
            if (_objAdaptor == null)
            {
                _objAdaptor = new MySqlDataAdapter(_mysqlCommand);
            }
            else
            {
                _objAdaptor.SelectCommand = _mysqlCommand;
            }
            return _objAdaptor;
        }
    }
}
