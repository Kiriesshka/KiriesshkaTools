using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AskGemini : MonoBehaviour
{
    //url to script in google 
    public string gasURL;
    public string prompt;
    public string answer;
    public void Message(string pr)
    {
        prompt = pr;
        StartCoroutine(SendDataToGAS());
    }
   
    private IEnumerator SendDataToGAS()
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", prompt);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);
        yield return www.SendWebRequest();

        string response = "";
        if(www.result == UnityWebRequest.Result.Success)
        {
            response = www.downloadHandler.text;
        }
        else
        {
            response = "NO";
        }
        answer = response;
    }
}
