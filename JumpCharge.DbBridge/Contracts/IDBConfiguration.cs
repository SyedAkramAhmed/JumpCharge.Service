namespace JumpCharge.DbBridge.Contracts
{
    public interface IDBConfiguration
    {
        string Connection { get; set; }
        DBProvider Provider { get; set; }
    }
}
