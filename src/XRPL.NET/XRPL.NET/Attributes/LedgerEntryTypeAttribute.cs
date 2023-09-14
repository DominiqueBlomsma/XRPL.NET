namespace XRPL.NET.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal class LedgerEntryTypeAttribute : Attribute
{
    internal LedgerEntryTypeAttribute(string ledgerEntryType)
    {
        LedgerEntryType = ledgerEntryType;
    }

    public string LedgerEntryType { get; }
}
