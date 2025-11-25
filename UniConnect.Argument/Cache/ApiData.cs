using System.Collections.Concurrent;

namespace UniConnect.Argument.Cache;

public static class ApiData
{
    private static ConcurrentDictionary<Guid, ApiDataContent> _dictionary = new ConcurrentDictionary<Guid, ApiDataContent>();

    public static Guid Add(ApiDataContent apiDataContent)
    {
        Guid newGuid = Guid.NewGuid();
        _dictionary[newGuid] = apiDataContent;
        return newGuid;
    }

    public static ApiDataContent Get(Guid apiDataGuid)
    {
        return _dictionary[apiDataGuid];
    }

    public static void Remove(Guid apiDataGuid)
    {
        _dictionary.Remove(apiDataGuid, out _);
    }
}
