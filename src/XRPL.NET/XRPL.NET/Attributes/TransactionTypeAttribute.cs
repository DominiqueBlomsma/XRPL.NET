namespace XRPL.NET.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal class TransactionTypeAttribute : Attribute
{
    internal TransactionTypeAttribute(string transactionType)
    {
        TransactionType = transactionType;
    }

    public string TransactionType { get; }
}
