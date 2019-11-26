using Microsoft.Extensions.Caching.Memory;


namespace WebApiService.Cache
{
    public class SWCharacterMemoryCache
    {
        public MemoryCache Cache { get; set; }
        public SWCharacterMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
        }
    }
}

