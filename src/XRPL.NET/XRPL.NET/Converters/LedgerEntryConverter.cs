using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Extensions;
using XRPL.NET.Models.LedgerObjectTypes;

namespace XRPL.NET.Converters;

/// <summary>
/// This custom converter exists because there is a limitation with the use of [JsonPolymorphic] and [JsonDerivedType] on <see cref="LedgerObjectBase"/>.
/// It's currently not possible to use any field which isn't the first field as discriminator.
/// https://github.com/dotnet/runtime/issues/72604
/// </summary>
internal class LedgerEntryConverter : JsonConverter<LedgerObjectBase>
{
    public override LedgerObjectBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var ledgerEntryType = jsonDoc.RootElement.GetProperty(nameof(LedgerObjectBase.LedgerEntryType)).GetString();
        if (ledgerEntryType != null)
        {
            var type = AttributeExtensions.GetLedgerEntryType(ledgerEntryType);
            return (LedgerObjectBase?)jsonDoc.RootElement.Deserialize(type, options);
        }

        throw new JsonException($"Missing '{nameof(LedgerObjectBase.LedgerEntryType)}' to serialize the ledger entry");
    }

    public override void Write(Utf8JsonWriter writer, LedgerObjectBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
