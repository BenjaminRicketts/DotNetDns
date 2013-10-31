namespace DotNetDns.Common.Messages
{
    public enum OperationCode : byte
    {
        StandardQuery = 0,
        InverseQuery = 1,
        Status = 2
    }
}