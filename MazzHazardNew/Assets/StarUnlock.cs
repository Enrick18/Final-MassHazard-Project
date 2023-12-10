using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarUnlock : MonoBehaviour
{
    public string levelKey;
    public Image lockedStar;
    public Sprite yellowStar;

    private void Start()
    {
        int level = PlayerPrefs.GetInt(levelKey, 0);

        if (level != 0)
        {
            lockedStar.sprite = yellowStar;
        }

    }
}
