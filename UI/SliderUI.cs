using UnityEngine;

public class SliderUI : MonoBehaviour
{
    private RectTransform mainPart;
    public RectTransform colorLine;
    public float percent;
    private void Start()
    {
        mainPart = GetComponent<RectTransform>();
    }
    private void Update()
    {
        colorLine.sizeDelta = new Vector2(mainPart.sizeDelta.x * (-1+ percent), mainPart.sizeDelta.y);
        colorLine.anchoredPosition = new Vector3(colorLine.sizeDelta.x / 2, 0, 0);
    }
}
