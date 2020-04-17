using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysManager : MonoBehaviour
{
    private int keyCount = 0;
    private Text keyCountText;

    private bool initialized;

    // Start is called before the first frame update
    void Start()
    {
        if (!initialized)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        keyCountText = gameObject.transform.Find("KeyCount").gameObject.GetComponent<Text>();
        initialized = true;
    }

    public int getKeyCount()
    {
        return keyCount;
    }

    public void incrementKeyCount()
    {
        ++keyCount;
        updateKeyCount();
    }

    public void decrementKeyCount()
    {
        --keyCount;
        updateKeyCount();
    }

    public void decreaseKeyCountBy(int number)
    {
        keyCount = keyCount - number;
        updateKeyCount();
    }

    private void updateKeyCount()
    {
        keyCountText.text = "x " + keyCount.ToString();
    }
}
