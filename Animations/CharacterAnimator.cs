using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterAnimator : MonoBehaviour
{
    public List<Sprite> anim = new List<Sprite>();
    public string animationFolder = "Animations";
    public bool runAnimation;
    public float changeDuration = 1;
    public float currentDuration = 0;
    public int currentSpriteIndex;
    private SpriteRenderer spriteRenderer;
    private Image image;
    public string animationName;
    private void Start()
    {
        Application.targetFrameRate = 120;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(runAnimation) RunAnimation(animationName);
    }
    public void RunAnimation(string path)
    {
        
        animationName = path;
        currentSpriteIndex = 0;
        currentDuration = 0;
        anim = new List<Sprite> (Resources.LoadAll<Sprite>(animationFolder +"/"+ path));
        runAnimation = true;
        if (spriteRenderer)
        {
            spriteRenderer.sprite = anim[currentSpriteIndex];
        }
        if (image)
        {
            image.sprite = anim[currentSpriteIndex];
        }
    }
    private void Update()
    {
        if (anim.Count > 0 & runAnimation)
        {
            currentDuration += Time.deltaTime;
            if(currentDuration > changeDuration)
            {
                currentDuration = 0;
                currentSpriteIndex += 1;
            }
        }
        if (currentSpriteIndex >= anim.Count) currentSpriteIndex = 0;
        if(spriteRenderer) spriteRenderer.sprite = anim[currentSpriteIndex];
        if(image) image.sprite = anim[currentSpriteIndex];
    }
}
