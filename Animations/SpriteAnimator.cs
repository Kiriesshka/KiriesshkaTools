using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    public bool isUsingSpriteRenderer;
    public bool isUsingImage;

    public SpriteRenderer spriteRenderer;
    public Image image;
    public string animationPath = "Animations";

    public int currentFrame;
    public float timeForNewFrame = 1;
    public float timeLast;

    public List<Sprite> frames;

    public bool isRunning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Configure();
    }
    public void Configure()
    {
        if(TryGetComponent(out spriteRenderer))
        {
            isUsingSpriteRenderer = true;
        }
        if(TryGetComponent(out image))
        {
            isUsingImage = true;
        }
    }
    public void GetFrames(string path)
    {
        frames = new List<Sprite>(Resources.LoadAll<Sprite>(path));
    }
    public void OnValidate()
    {
        Configure();
        GetFrames(animationPath);
        SetSprite(frames[currentFrame]);
    }
    public void PauseAnimation() => isRunning = false;
    public void UnpauseAnimation() => isRunning = true;
    public void RunNewAnimation(string ap)
    {
        animationPath = ap;
        currentFrame = 0;
        isRunning = true;
    }
    public void SetSprite(Sprite s)
    {
        if(isUsingImage)
        {
            image.sprite = s;
        }
        if(isUsingSpriteRenderer)
        {
            spriteRenderer.sprite = s;
        }
    }
    private void Update()
    {
        if(isRunning)
        {
            if(timeLast <=0) 
            {
                currentFrame++;
                if(currentFrame > frames.Count-1) currentFrame = 0;
                timeLast=timeForNewFrame;
                SetSprite(frames[currentFrame]);
            }
            timeLast-=Time.deltaTime;
        }
    }
}
