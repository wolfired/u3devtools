using UnityEditor;
using UnityEngine;

namespace u3devtools.sloot
{
    public class Setting4Bundle : Setting
    {
        public Setting4Bundle(string zone) : base(zone)
        {
        }

        public string BundleRoot
        {
            get { return this.GetString("BundleRoot", ""); }
            set { this.SetString("BundleRoot", value); }
        }
    }
}
