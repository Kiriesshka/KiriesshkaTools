using UnityEngine;
using TMPro;
public class SymbolBySymbolText : MonoBehaviour
{
    public string targetText;
    public TMP_Text txt;
    public float speed = 1;
    public float localTimer =-1;

    private void Start()
    {
        if(!txt) txt = GetComponent<TMP_Text>();
        localTimer = -1;
    }
    private void Update()
    {
        if(localTimer >= 0)
        {
            if (localTimer > targetText.Length)
                localTimer = targetText.Length;

            int target = Mathf.RoundToInt(localTimer);
            if(target < targetText.Length) 
                txt.text = targetText.Remove(target);
            else
                txt.text = targetText;
            
            if (localTimer == targetText.Length) 
                localTimer = -1;
            else 
                localTimer += Time.deltaTime * speed;
        }

        
    }
    public void _PushText(string text)
    {
        targetText = text;
        localTimer = 0;
        Debug.Log(localTimer);
    }
}
