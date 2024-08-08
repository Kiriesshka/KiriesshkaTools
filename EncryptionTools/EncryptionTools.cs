using System.Collections.Generic;
using UnityEngine;


namespace EncryptionTools
{
    public class Encryptor
    {
        string alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm 1234567890-=+_)(*&^%$#@!|}{';/?.><,~`";
        Dictionary<char, string> leep = new Dictionary<char, string>
        {
            {'A',"4" },
            {'B',"j3" },
            {'C',"(" },
            {'D',"[)" },
            {'E',"3" },
            {'F',"|#" },
            {'G',"[," },
            {'H',"|-|" },
            {'J',"]" },
            {'K',"|<" },
            {'L',"|" },
            {'M',"[v]" },
            {'N',"/V" },
            {'O',"()" },
            {'P',"|>" },
            {'Q',"9" },
            {'R',"/2" },
            {'S',"5" },
            {'T',"7" },
            {'U',"v" },
            {'W',"VV" },
            {'X',"><" },
            {'Y',"`/" },
            {'Z',"7_" },

        };

        //EXAMPLE 
        //encrypt with keys abc and h819 in PLUS mode

        //string a = EncryptVigenere("info to encrypt", new List<List<char>> { new List<char> { 'a', 'b', 'c' }, new List<char> { 'h', '8', '1', '9' } }, "PLUS");
        
        //to decrypt simply change to MINUS mode
        //string a = EncryptVigenere("info to encrypt", new List<List<char>> { new List<char> { 'a', 'b', 'c' }, new List<char> { 'h', '8', '1', '9' } }, "MINUS");
        
        //also you can encrypt with MINUS mode and then decrypt with PLUS mode
        
        public string EncryptVigenere(string data, List<List<char>> keys, string mode)
        {
            List<char> dataArray = new List<char>(data);
            string res = "";
            for(int a = 0; a < keys.Count; a++)
            {
                List<char> keySimple = keys[a];
                while (keys[a].Count < data.Length)
                {
                    keys[a].AddRange(keySimple);
                }
                if (keys.IndexOf(keys[a]) < keys.Count - 1)
                {
                    keys[a] = new List<char>(EncryptVigenere(new string(keys[a].ToArray()), new List<List<char>> { keys[a + 1] }, "PLUS"));
                }
                
            }

            if(mode == "PLUS")
            {
                for (int i = 0; i < data.Length; i++)
                {
                    res += EncryptPlus(dataArray[i], keys[0][i]);
                }
            }
            else if (mode == "MINUS")
            {
                for (int i = 0; i < data.Length; i++)
                {
                    res += EncryptMinus(dataArray[i], keys[0][i]);
                }
            }
            return res;
        }
        public char EncryptPlus(char before, char key)
        {
            int beforeIndex = alphabet.IndexOf(before);
            int keyIndex = alphabet.IndexOf(key);
            int resultIndex = beforeIndex + keyIndex;
            if(resultIndex > alphabet.Length)
            {
                resultIndex -=alphabet.Length;
            }
            return alphabet[resultIndex];
        }
        public char EncryptMinus(char before, char key)
        {
            int beforeIndex = alphabet.IndexOf(before);
            int keyIndex = alphabet.IndexOf(key);
            int resultIndex = beforeIndex - keyIndex;
            if (resultIndex < 0)
            {
                resultIndex += alphabet.Length;
            }
            return alphabet[resultIndex];
        }
        public void SetAlphabet(string newAlphabet)
        {
            alphabet = newAlphabet;
        }
        public string toLeepSpeak(string data)
        {
            string res = "";

            for(int i =0; i < data.Length; i++)
            {
                if (leep.ContainsKey(data[i]))
                {
                    res += leep[data[i]];
                }
                else res+= data[i]; 
            }
            return res;
        }
    }
}