using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBarBehavior : MonoBehaviour
{
    private GameObject barSprite;

    void Start()
    {
        barSprite = gameObject.transform.GetChild(2).gameObject;
    }

    public void UpdateBarSpriteScale(float scale)
    {
        Vector3 newScale = new Vector3(scale, barSprite.transform.localScale.y, barSprite.transform.localScale.z);
        barSprite.transform.localScale = newScale;
    }
}
