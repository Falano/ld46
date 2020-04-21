using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSprites : MonoBehaviour
{
    [SerializeField]
    BackgroundManager bgManager;

    private void OnMouseDown()
    {
        bgManager.EnableSpritesColliders();
    }
}
