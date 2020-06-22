using UnityEngine;

namespace u3devtools.cacher
{
    public class Cacher
    {
        private Dictionary<string, CachedBundle> _cached_bundles;

        public Cacher()
        {
            _cached_bundles = new Dictionary<string, CachedBundle>();
        }

        public void addCachedBundle(string key, AssetBundle bundle)
        {
            CachedBundle cachedBundle;
            bool cached = _cached_bundles.TryGetValue(key, out cachedBundle);
            if (cached)
            {
                cachedBundle.bundle = bundle;
            }
            else
            {
                _cached_bundles.Add(key, cachedBundle = new CachedBundle(bundle));
            }
        }

        public AssetBundle getCachedBundle(string key)
        {
            CachedBundle cachedBundle;
            bool cached = _cached_bundles.TryGetValue(key, out cachedBundle);
            if (cached)
            {
                return cachedBundle.bundle;
            }
            return null;
        }
    }
}
