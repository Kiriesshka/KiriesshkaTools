using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFingerScale : MonoBehaviour
{
    public OrbitCamera oC;
    public float scale;
    public float minSize;
    public float maxSize;
    private bool listenForTouches;
    private Vector2 firstPoint;
    private Vector2 secondPoint;
    private float refernceDistance;
    private float oldScale;
    private void Update()
    {
        if(Input.touchCount == 2)
        {
                if (listenForTouches)
                {
                    firstPoint = Input.GetTouch(0).position;
                    secondPoint = Input.GetTouch(1).position;
                    listenForTouches = false;
                    refernceDistance = Vector2.Distance(firstPoint, secondPoint);        
                }
                float dist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

                float newSize = Mathf.Lerp(oC.distance, oldScale + (refernceDistance - dist) * scale, Time.deltaTime * 5);

                if (newSize > maxSize) newSize = maxSize;
                if (newSize < minSize) newSize = minSize;
                oC.distance = newSize;
        }
        else
        {
            listenForTouches = true;
            oldScale = oC.distance;
        }
    }
}
