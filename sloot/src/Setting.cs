using System;

using UnityEditor;
using UnityEngine;

namespace u3devtools.sloot
{
    public class Setting
    {
        private string zone;

        protected Setting(string zone)
        {
            this.zone = zone;
        }

        protected bool GetBool(string key, bool defaultValue = false)
        {
            return EditorPrefs.GetBool(key, defaultValue);
        }

        protected void SetBool(string key, bool value)
        {
            EditorPrefs.SetBool(key, value);
        }

        protected int GetInt(string key, int defaultValue = 0)
        {
            return EditorPrefs.GetInt(key, defaultValue);
        }

        protected void SetInt(string key, int value)
        {
            EditorPrefs.SetInt(key, value);
        }

        protected float GetFloat(string key, float defaultValue = 0.0F)
        {
            return EditorPrefs.GetFloat(key, defaultValue);
        }

        protected void SetFloat(string key, float value)
        {
            EditorPrefs.SetFloat(key, value);
        }

        protected string GetString(string key, string defaultValue = null)
        {
            return EditorPrefs.GetString(key, defaultValue);
        }

        protected void SetString(string key, string value)
        {
            EditorPrefs.SetString(key, value);
        }
    }
}
