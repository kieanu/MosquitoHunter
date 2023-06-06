using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Sprite itemSprite;

    void Start()
    {
        itemSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

   
}
