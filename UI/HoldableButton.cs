using UnityEngine;
using UnityEngine.UI;

public class HoldableButton : UIObject
{
    public bool isOn;

    public Sprite onSprite;
    public Sprite offSprite;

    public void SetOn()
    {
        isOn = true;
        GetComponent<Image>().sprite = onSprite;
    }
    public void SetOff() 
    {
        isOn = false;
        GetComponent<Image>().sprite = offSprite;
    }
}
