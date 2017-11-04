using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    #region GetSwipe
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;
    #endregion

    public Image currentImage;

    int i;
    public enum sprites
    {
        bugs,
        food,
        background
    }
    sprites currentSprite;

    public Sprite[] bugsSprites;
    public Sprite[] foodSprites;
    public Sprite[] backgroundSprites;

    // Use this for initialization
    void Start()
    {
        i = 0;
        currentSprite = sprites.bugs;
        ChangeSpritesByEnum();
    }

    // Update is called once per frame
    void Update()
    {
        GetSwipe();
    }

    public void GetSwipe()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                    NextSpriteInLoop(1);
                                    print("right");
                                }
                                else
                                {
                                    // MOVE LEFT
                                    NextSpriteInLoop(-1);
                                    print("left");
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    // MOVE UP
                                }
                                else
                                {
                                    // MOVE DOWN
                                }
                            }

                        }

                        break;
                }
            }
        }
    }

    public void ChangeSpritesByEnum()
    {
        switch (currentSprite)
        {
            case sprites.bugs:
                currentImage.sprite = bugsSprites[i];
                break;
            case sprites.food:
                currentImage.sprite = foodSprites[i];
                break;
            case sprites.background:
                currentImage.sprite = backgroundSprites[i];
                break;
            default:
                break;
        }

    }

    public void NextSpriteInLoop(int num)
    {
        int max = 0;
        switch (currentSprite)
        {
            case sprites.bugs:
                max = bugsSprites.Length;
                break;
            case sprites.food:
                max = foodSprites.Length;
                break;
            case sprites.background:
                max = backgroundSprites.Length;
                break;
            default:
                break;
        }
        i = i + num;

        if (i < 0)
        {
            i = i + max;
        }
        else if (i >= max)
        {
            i = i - max;
        }

        ChangeSpritesByEnum();
    }


    public void OpenBugsSprites()
    {
        currentSprite = sprites.bugs;
        ChangeSpritesByEnum();
    }
    public void OpenFoodSprites()
    {
        currentSprite = sprites.food;
        ChangeSpritesByEnum();
    }
    public void OpenBackgroundSprites()
    {
        currentSprite = sprites.background;
        ChangeSpritesByEnum();
    }
}
