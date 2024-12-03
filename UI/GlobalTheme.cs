using UnityEngine;

using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class GlobalTheme : MonoBehaviour
{
	public List<UIObject> themeObjects;
	public bool isDarkTheme;
	public Color darkThemeBackground;
	public Color darkThemeHigh;
	public Color darkThemeLow;
	public Color[] darkThemeColorsFree;
	public Color darkThemeText;
	public Color darkThemeTextOther;
	
	public Color lightThemeBackground;
	public Color lightThemeHigh;
	public Color lightThemeLow;
	public Color[] lightThemeColorsFree;
	public Color lightThemeText;
	public Color lightThemeTextOther;
	
	private void Start()
	{
		SetTheme();
	}
	public void SetTheme()
	{
		Debug.Log("Set theme!");
			foreach(UIObject obj in themeObjects)
			{
				if(obj.index == 0)
				{
					if(isDarkTheme)
					{
						if(obj.color == "Background")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = darkThemeBackground;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = darkThemeBackground;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = darkThemeBackground;
						}
						if(obj.color == "High")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = darkThemeHigh;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = darkThemeHigh;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = darkThemeHigh;
						}
						if(obj.color == "Low")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = darkThemeLow;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = darkThemeLow;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = darkThemeLow;
						}
						if(obj.color == "Text")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = darkThemeText;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = darkThemeText;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = darkThemeText;
						}
						if(obj.color == "TextOther")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = darkThemeTextOther;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = darkThemeTextOther;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = darkThemeTextOther;
						}
					}
					else
					{
						Debug.Log("Light");
						if(obj.color == "Background")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = lightThemeBackground;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = lightThemeBackground;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = lightThemeBackground;
						}
						if(obj.color == "High")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = lightThemeHigh;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = lightThemeHigh;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = lightThemeHigh;
						}
						if(obj.color == "Low")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = lightThemeLow;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = lightThemeLow;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = lightThemeLow;
						}
						if(obj.color == "Text")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = lightThemeText;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = lightThemeText;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = lightThemeText;
						}
						if(obj.color == "TextOther")
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = lightThemeTextOther;
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = lightThemeTextOther;
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = lightThemeTextOther;
						}
					}
				}
				else 
				{
					if(isDarkTheme)
					{
						if(obj.index <= darkThemeColorsFree.Length)
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = darkThemeColorsFree[obj.index];
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = darkThemeColorsFree[obj.index];
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = darkThemeColorsFree[obj.index];
						}	
					}
					else
					{
						if(obj.index <= lightThemeColorsFree.Length)
						{
							if(obj.workMode == "Image") obj.GetComponent<Image>().color = lightThemeColorsFree[obj.index];
							if(obj.workMode == "TMPro") obj.GetComponent<TMP_Text>().color = lightThemeColorsFree[obj.index];
							if(obj.workMode == "SpriteRenderer") obj.GetComponent<SpriteRenderer>().color = lightThemeColorsFree[obj.index];
						}
					}
				}
			}
	}
}
