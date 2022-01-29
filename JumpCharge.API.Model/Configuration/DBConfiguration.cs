using JumpCharge.DbBridge.Contracts;

namespace JumpCharge.API.Model.Configuration
{
    public class DBConfiguration : IDBConfiguration
    {
        public string Connection { get; set; }
        public DBProvider Provider { get; set; }
    }
}
