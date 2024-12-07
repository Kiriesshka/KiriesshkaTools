using UnityEngine;
using UnityEngine.UI;
public class PixelCamera : MonoBehaviour
{
    public Camera c;
    public RawImage rawImage;
    public RenderTexture renderTexture;
    public int scale = 1;
    private void Start()
    {
        renderTexture = new RenderTexture(Screen.width / scale, Screen.height / scale, 16, RenderTextureFormat.ARGB32);
        renderTexture.antiAliasing = 1;
        renderTexture.filterMode = FilterMode.Point;
        rawImage.texture = renderTexture;
        c.targetTexture = renderTexture;
        rawImage.gameObject.SetActive(true);
    }
}
