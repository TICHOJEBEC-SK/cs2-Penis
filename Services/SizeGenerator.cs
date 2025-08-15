using System.Security.Cryptography;
using System.Text;

namespace Penis.Services;

public class SizeGenerator
{
    private readonly Random _random = new();

    public string RandomSize(double minCm, double maxCm)
    {
        var value = minCm + _random.NextDouble() * (maxCm - minCm);
        return value.ToString("0.00");
    }

    public string DeterministicSize(string? seed, double minCm, double maxCm)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(seed ?? string.Empty));
        var u = BitConverter.ToUInt64(bytes, 0);
        var x = u / (double)ulong.MaxValue;
        var value = minCm + x * (maxCm - minCm);
        return value.ToString("0.00");
    }
}