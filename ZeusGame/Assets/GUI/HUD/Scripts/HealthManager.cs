using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private int lifeCount;
    private Text lifeCountText;

    // Start is called before the first frame update
    void Start()
    {
        lifeCountText = gameObject.transform.Find("LifeCount").GetComponent<Text>();

        //if (lifeCount == 0) // Default life count is 5
        //{
        //    lifeCount = 5;
        //}
		 if (menuMain.hard == true) // Default life count is 5
        {
            lifeCount = 5;
        }
        if (menuMain.meduim == true) // Default life count is 5
        {
            lifeCount = 10;
        }
        if (menuMain.easy == true) // Default life count is 5
        {
            lifeCount = 20;
        }
        if (lifeCount == 0) // Default life count is 5
        {
            lifeCount = 15;
        }

        updateLifeCount();
    }

    public int getLifeCount()
    {
        return lifeCount;
    }

    public void setLifeCount(int count)
    {
        lifeCount = count;
        updateLifeCount();
    }

    public void decrementLifeCount()
    {
        --lifeCount;
        updateLifeCount();
    }

    public void incrementLifeCount()
    {
        ++lifeCount;
        updateLifeCount();
    }

    private void updateLifeCount()
    {
        lifeCountText.text = lifeCount.ToString();
    }

    public bool isOutOfLives()
    {
        return lifeCount <= 0;
    }
}
