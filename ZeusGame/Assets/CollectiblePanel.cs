using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblePanel : MonoBehaviour
{
    public string levelName;
    public int totalCount;
    public Collectible.CollectibleType type;
    public Sprite image;
    private int currentCount;
    private bool levelHasBeenVisited = true;

    // Start is called before the first frame update
    void Start()
    {
        if (levelHasBeenVisited)
        {
            gameObject.transform.Find("LevelText").GetComponent<Text>().text = levelName;
        } else
        {
            gameObject.transform.Find("LevelText").GetComponent<Text>().text = "???";
        }
        
        if (currentCount <= 0)
        {
            gameObject.transform.Find("CountText").GetComponent<Text>().text = "???";
        } else
        {
            gameObject.transform.Find("CountText").GetComponent<Text>().text = currentCount + " / " + totalCount;
            gameObject.transform.Find("ImageBorderPanel").transform.Find("ImagePanel").transform.Find("Image")
                .GetComponent<Image>().sprite = image;
        }
    }

    public bool AddCollectible(Collectible.CollectibleType type)
    {
        if (this.type == type)
        {
            currentCount++;
            gameObject.transform.Find("CountText").GetComponent<Text>().text = currentCount + " / " + totalCount;
            if (currentCount <= 1)
            {
                gameObject.transform.Find("ImageBorderPanel").transform.Find("ImagePanel").transform.Find("Image")
                    .GetComponent<Image>().sprite = image;
            }
            return true;
        }
        print("Collectible of type " + type + "did not match panel's collectible type of " + this.type);
        return false;
    }

    public void ShowLevelName()
    {
        bool levelHasBeenVisited = true;
        gameObject.transform.Find("LevelText").GetComponent<Text>().text = levelName;
    }
}
