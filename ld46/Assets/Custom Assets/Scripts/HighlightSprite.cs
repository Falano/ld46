﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightSprite : MonoBehaviour
{
    bool alreadyCheckedTextField = false;
    bool hasTextField { get => HelpText != null; }
    Text _helpText;
    public Text HelpText {
        get
        {
            if(!alreadyCheckedTextField)
            {
                alreadyCheckedTextField = true;
                _helpText = gameObject.GetComponentInChildren<Text>(includeInactive:true);
            }
            return _helpText;
        }
    }

    SpriteRenderer spriteRenderer;
    Color defaultColor;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    void OnMouseEnter()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        spriteRenderer.color = Color.yellow;
        if (hasTextField)
        {
            HelpText.gameObject.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        spriteRenderer.color = defaultColor;
        if (hasTextField)
        {
            HelpText.gameObject.SetActive(false);
        }

    }
}
