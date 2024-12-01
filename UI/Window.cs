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
	[Header("����� ������")]
	public Mode mode;

	[Header("����������")]
	public float speed = 5;
	public float distanceToConnect = 20;
	public RectTransform openAnchor;
	public RectTransform closeAnchor;
	public List<RectTransform> allPositions;

	public bool isOpened;
	private RectTransform rectTransform;

	private Vector3 mouseDifference;
	public bool setOnFront;
	public bool isCoolFloatingLerp;
	private Vector3 mouseStartPosition;
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
				if (isCoolFloatingLerp)
				{
					if (mouseDifference == Vector3.zero) Debug.LogWarning("NO MOUSE POSITION GET");
					else
					{
						rectTransform.position = Vector3.Lerp(rectTransform.position, (Input.mousePosition + mouseDifference), Time.deltaTime * speed);
						transform.rotation =Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, Vector2.Distance(mouseStartPosition, Input.mousePosition) / 30 * ((mouseStartPosition-Input.mousePosition).x < 0 ? 1 : -1))), Time.deltaTime*3);
					}
				}
                else
                {
					if (mouseDifference == Vector3.zero) Debug.LogWarning("NO MOUSE POSITION GET");
					else rectTransform.position = Vector3.Lerp(rectTransform.position, Input.mousePosition + mouseDifference, Time.deltaTime * speed);
				}
				
			}else if (closeAnchor)
            {
				if (rectTransform.position != closeAnchor.position)
				{
					rectTransform.position = Vector3.Lerp(rectTransform.position, closeAnchor.position, speed * Time.deltaTime);
					transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime*4);
				}
			}
		}
		else if (mode == Mode.FloatingInst)
		{
			if (isOpened)
			{
				if (mouseDifference == Vector3.zero) Debug.LogWarning("NO MOUSE POSITION GET");
				else rectTransform.position = Input.mousePosition + mouseDifference;
			}
			else if (closeAnchor)
			{
				if (rectTransform.position != closeAnchor.position)
				{
					rectTransform.position = closeAnchor.position;
				}
			}
		}
	}
	public void SetOpenAnchorAndOpenTo(RectTransform newOpenAnchor)
	{
		openAnchor = newOpenAnchor;
		Open();
	}
	public void SetCloseAnchorAndCloseTo(RectTransform newCloseAnchor)
	{
		closeAnchor = newCloseAnchor;
		Close();
	}
	public void OpenToAnchorById(int id)
	{
		if(allPositions != null && allPositions.Count > id)
		{
			openAnchor = allPositions[id];
			Open();
		}
	}
	public void CloseToAnchorById(int id)
	{
		if(allPositions != null && allPositions.Count > id)
		{
			closeAnchor = allPositions[id];
			Close();
		}
	}
	public void SetControllable()
	{
		isOpened = true;
		mouseDifference = rectTransform.position - Input.mousePosition;
		mouseStartPosition = Input.mousePosition;
		if(setOnFront)
        {
			transform.SetAsLastSibling();
        }
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
	public void InvertState()
	{
		isOpened = !isOpened;
	}
}
