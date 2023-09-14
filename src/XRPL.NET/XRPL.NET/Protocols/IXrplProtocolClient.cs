using System.Text.Json;

namespace XRPL.NET.Protocols;

public interface IXrplProtocolClient : IDisposable
{
    Task<T> GetResponse<T>(string command, object? request, JsonSerializerOptions options, CancellationToken token);
}
