using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightSprite : MonoBehaviour
{
    SpriteRenderer sprite;
    Color defaultColor;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }

    void OnMouseEnter()
    {
        sprite.color = Color.yellow;
    }

    void OnMouseExit()
    {
        sprite.color = defaultColor;
    }
}
