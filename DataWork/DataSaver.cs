using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace KiriesshkaData
{
    public class ApplicationInfo
    {
        public string RootFolder()
        {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        return Application.persistentDataPath;
#else
            return Application.dataPath;
#endif
        }
    }
    public class DataSaver
    {
        public string fileName;
        public string fileExtension = ".json";
        public bool prettyPrint;
        private string dataToSave;
        public List<string> loadedData;

        public string RootFolder()
        {
#if PLATFORM_ANDROID && !UNITY_EDITOR
        return Application.persistentDataPath;
#else
            return Application.dataPath;
#endif
        }
        public string SavePath() => Path.Combine(RootFolder(), fileName + fileExtension);

        public void Add<T>(string name, T objToSave)
        {
            dataToSave += StringifyClass(name, objToSave);
        }
        public void Add(string name, bool boolToSave)
        {
            dataToSave += StringifyBool(name, boolToSave);
        }
        public void Add(string name, string stringToSave)
        {
            dataToSave += name + " : "+stringToSave + " : _STRING_ END\n";
        }
        public void Add(string name, int intToSave)
        {
            dataToSave += StringifyInt(name, intToSave);
        }
        public void Add(string name, float floatToSave)
        {
            dataToSave += StringifyFloat(name, floatToSave);
        }
        public string GetString(string name)
        {
            foreach (string s in loadedData)
            {
                if (s.Contains("_STRING_"))
                {
                    List<string> parts = new List<string>(s.Split(" : "));
                    if (parts[0] == name)
                    {
                        return parts[1];
                    }
                }
            }
            Debug.LogError("No STRING with name {" + name + "}");
            return "ERROR";
        }
        public float GetFloat(string name)
        {
            foreach (string s in loadedData)
            {
                if (s.Contains("_FLOAT_"))
                {
                    List<string> parts = new List<string>(s.Split(" : "));
                    if (parts[0] == name)
                    {
                        return float.Parse(parts[1].Replace(" ", ""));
                    }
                }
            }
            Debug.LogError("No FLOAT with name {" + name + "}");
            return 0f;
        }
        public int GetInt(string name)
        {
            foreach (string s in loadedData)
            {
                if (s.Contains("_INT_"))
                {
                    List<string> parts = new List<string>(s.Split(" : "));
                    if (parts[0] == name)
                    {
                        return int.Parse(parts[1].Replace(" ", ""));
                    }
                }
            }
            Debug.LogError("No INT with name {"+name+"}");
            return 0;
        }
        public bool GetBool(string name)
        {
            foreach (string s in loadedData)
            {
                if (s.Contains("_BOOL_"))
                {
                    List<string> parts = new List<string>(s.Split(" : "));
                    if (parts[0] == name)
                    {
                        if (parts[1].Contains("true")) return true;
                        return false;
                    }
                    Debug.Log("adkls");
                }
            }
            Debug.LogError("No BOOL with name {" + name + "}");
            return false;
        }
        public void Save()
        {
            File.WriteAllText(SavePath(), dataToSave);
        }
        public void Load()
        {
            if(File.Exists(SavePath()))
            {
                string data = File.ReadAllText(SavePath());
                loadedData = new List<string>(data.Split(" END\n"));
            }
            else
            {
                Debug.LogError("You trying to load non-existing file!");
            }
        }
        public string StringifyClass<T>(string name, T obj)
        {
            return name + " : " + JsonUtility.ToJson(obj, prettyPrint) + " : _CLASS_ END\n";
        }
        public string StringifyBool(string name, bool b)
        {
            return name + " : " + (b ? "true" : "else") + " : _BOOL_ END\n";
        }
        public string StringifyFloat(string name, float f)
        {
            return name + " : " + f.ToString() + " : _FLOAT_ END\n";
        }
        public string StringifyInt(string name, int i)
        {
            return name + " : " + i.ToString() + " : _INT_ END\n";
        }

    }
}

