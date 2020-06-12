using System;
using UnityEngine;

namespace u3devtools.network
{
    public class NetworkManager
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

        public void connect(string ip, string port)
        {
            Debug.Log(String.Format("network connect {0}:{1}", ip, port));
        }
    }
}
