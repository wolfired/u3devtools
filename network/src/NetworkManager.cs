using System;
using UnityEngine;

namespace u3devtools.network
{
    class NetworkManager
    {
        private static NetworkManager _ins;

        public static NetworkManager ins
        {
            get
            {
                if (null == _ins)
                {
                    _ins = new NetworkManager();
                }
                return _ins;
            }
        }

        private NetworkManager()
        {

        }
    }
}
