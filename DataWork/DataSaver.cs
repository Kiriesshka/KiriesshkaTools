using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System;
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
        public string fileName = "savedData";
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
            dataToSave += name + " S:S "+stringToSave + " S:S  END\n";
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
                if (s.Contains(" S:S "))
                {
                    List<string> parts = new List<string>(s.Split(" S:S "));
                    if (parts[0] == name)
                    {
                        return parts[1];
                    }
                }
            }
            throw new ArgumentException("No STRING with name {" + name + "}");
        }
        public float GetFloat(string name)
        {
            foreach (string s in loadedData)
            {
                if (s.Contains(" F:F "))
                {
                    List<string> parts = new List<string>(s.Split(" F:F "));
                    if (parts[0] == name)
                    {
                        return float.Parse(parts[1].Replace(" ", ""));
                    }
                }
            }
            throw new ArgumentException("No FLOAT with name {" + name + "}");
        }
        public int GetInt(string name)
        {
            foreach (string s in loadedData)
            {
                if (s.Contains(" I:I "))
                {
                    List<string> parts = new List<string>(s.Split(" I:I "));
                    if (parts[0] == name)
                    {
                        return int.Parse(parts[1]);
                    }
                }
            }
            throw new ArgumentException("No INT with name {" + name + "}");
        }
        public bool GetBool(string name)
        {
            foreach (string s in loadedData)
            {
                if (s.Contains(" B:B "))
                {
                    List<string> parts = new List<string>(s.Split(" B:B "));
                    if (parts[0] == name)
                    {
                        if (parts[1].Contains("true")) return true;
                        return false;
                    }
                }
            }
            throw new ArgumentException("No BOOL with name {" + name + "}");
        }
        public T GetClass<T>(string name)
        {
            foreach(string s in loadedData)
            {
                if (s.Contains(" C:C "))
                {
                    List<string> parts = new List<string>(s.Split(" C:C "));
                    if(parts[0] == name)
                    {
                        return JsonUtility.FromJson<T>(parts[1]);
                    }
                }
            }
            throw new ArgumentException("No CLASS with name {" + name + "}");
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
            return name + " C:C " + JsonUtility.ToJson(obj, prettyPrint) + " C:C  END\n";
        }
        public string StringifyBool(string name, bool b)
        {
            return name + " B:B " + (b ? "true" : "false") + " B:B  END\n";
        }
        public string StringifyFloat(string name, float f)
        {
            return name + " F:F " + f.ToString() + " F:F  END\n";
        }
        public string StringifyInt(string name, int i)
        {
            return name + " I:I " + i.ToString() + " I:I  END\n";
        }
    }
}
