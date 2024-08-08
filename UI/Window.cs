using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : UIObject
{
    public enum Mode
    {
        LerpTo,
        SpeedTo,
        InstantlyTo,
        FloatingLerp,
        FloatingInst
    }
    [Header("Режим работы")]
    public Mode mode;

    [Header("Переменные")]
    public float speed = 5;
    public float distanceToConnect = 20;
    public RectTransform openAnchor;
    public RectTransform closeAnchor;

    public bool isOpened;
    private RectTransform rectTransform;

    private Vector3 mouseDifference;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(mode == Mode.LerpTo)
        {
            if (isOpened)
            {
                if (rectTransform.position !=openAnchor.position)
                {
                    rectTransform.position = Vector3.Lerp(rectTransform.position,openAnchor.position,speed*Time.deltaTime);
                }
            }
            else
            {
                if (rectTransform.position != closeAnchor.position)
                {
                    rectTransform.position = Vector3.Lerp(rectTransform.position, closeAnchor.position, speed*Time.deltaTime);
                }
            }
        }
        else if(mode == Mode.SpeedTo)
        {
            if (isOpened)
            {
                if (rectTransform.position != openAnchor.position)
                {
                    Vector3 dir = (openAnchor.position - rectTransform.position);
                    if(dir.magnitude < distanceToConnect)
                    {
                        rectTransform.position = openAnchor.position;
                        return;
                    }
                    dir.Normalize();
                    rectTransform.position += dir * speed * Time.deltaTime;
                }
            }
            else
            {
                if (rectTransform.position != closeAnchor.position)
                {
                    Vector3 dir = (closeAnchor.position - rectTransform.position);
                    if(dir.magnitude < distanceToConnect)
                    {
                        rectTransform.position = closeAnchor.position;
                        return;
                    }
                    dir.Normalize();
                    rectTransform.position += dir * speed * Time.deltaTime;
                }
            }
        }else if(mode == Mode.InstantlyTo)
        {
            if (isOpened)
            {
                if (rectTransform.position != openAnchor.position)
                {
                    rectTransform.position = openAnchor.position;
                }
            }
            else
            {
                if (rectTransform.position != closeAnchor.position)
                {
                    rectTransform.position = closeAnchor.position;
                }
            }
        }else if (mode == Mode.FloatingLerp)
        {
            if (isOpened)
            {
                if (mouseDifference == Vector3.zero) Debug.LogWarning("NO MOUSE POSITION GET");
                rectTransform.position = Vector3.Lerp(rectTransform.position, Input.mousePosition + mouseDifference, Time.deltaTime * speed);
            }
        }
        else if (mode == Mode.FloatingInst)
        {
            if (isOpened)
            {
                if (mouseDifference == Vector3.zero) Debug.LogWarning("NO MOUSE POSITION GET");
                rectTransform.position = Input.mousePosition + mouseDifference;
            }
        }
    }
    public void SetControllable()
    {
        isOpened = true;
        mouseDifference = rectTransform.position - Input.mousePosition;
    }
    public void SetUnControllable()
    {
        isOpened = false;
        mouseDifference = Vector3.zero;
    }
    public void Open()
    {
        isOpened = true;
    }
    public void Close()
    {
        isOpened = false;
    }
}
