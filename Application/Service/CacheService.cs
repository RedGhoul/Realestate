using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;

namespace RealEstate.Service;

public class CacheService 
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }
    
    public async Task<T> GetFromCache<T>(string key) where T : class
    {
        var cachedResponse = await _cache.GetStringAsync(key);
        return cachedResponse == null ? null : JsonSerializer.Deserialize<T>(cachedResponse,options: new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });
    }

    public async Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options) where T : class
    {
        var response = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, response , options);
    }

    public async Task<T> GetOrSet<T>(string key, Func<Task<T>> value, DistributedCacheEntryOptions options) where T : class
    {
        T valueGotten = await GetFromCache<T>(key);
        if (valueGotten == null)
        {
            T dbValue = await value.Invoke();
            var response = JsonSerializer.Serialize(dbValue, options: new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            await _cache.SetStringAsync(key, response , new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(45)
            });
            return dbValue;
        }

        return valueGotten;
    }
    
    public async Task<T> GetOrSet<T>(string key, Func<Task<T>> value) where T : class
    {
        T valueGotten = await GetFromCache<T>(key);
        if (valueGotten == null)
        {
            T dbValue = await value.Invoke();
            var response = JsonSerializer.Serialize(dbValue, options: new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            await _cache.SetStringAsync(key, response , new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(45)
            });
            return dbValue;
        }

        return valueGotten;
    }

    public async Task ClearCache(string key)
    {
        await _cache.RemoveAsync(key);
    }
}