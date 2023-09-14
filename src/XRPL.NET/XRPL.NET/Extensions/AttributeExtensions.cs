using System.Reflection;
using XRPL.NET.Attributes;
using XRPL.NET.Models.LedgerObjectTypes;
using XRPL.NET.Models.TransactionTypes;

namespace XRPL.NET.Extensions;

internal static class AttributeExtensions
{
    internal static Type GetLedgerEntryType(string ledgerEntryType)
    {
        foreach (var type in Assembly.GetAssembly(typeof(LedgerObjectBase))!.GetTypes().Where(type => type.IsSubclassOf(typeof(LedgerObjectBase))))
        {
            var custom = type.GetCustomAttribute<LedgerEntryTypeAttribute>();
            if (custom != null && custom.LedgerEntryType.Equals(ledgerEntryType))
            {
                return type;
            }
        }

        throw new NotImplementedException("Not implemented ledger entry type: " + ledgerEntryType);
    }

    internal static Type GetTransactionType(string transactionType, bool throwException)
    {
        foreach (var type in Assembly.GetAssembly(typeof(LedgerObjectBase))!.GetTypes().Where(type => type.IsSubclassOf(typeof(TransactionBase))))
        {
            var custom = type.GetCustomAttribute<TransactionTypeAttribute>();
            if (custom != null && custom.TransactionType.Equals(transactionType))
            {
                return type;
            }
        }

        if (throwException)
        {
            throw new NotImplementedException("Not implemented transaction type: " + transactionType);
        }

        return typeof(TransactionBase);
    }
}
