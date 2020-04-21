using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    GameObject DefaultBackground;

    [SerializeField]
    GameObject FlashbackInside;

    [SerializeField]
    GameObject FlashbackOutside;

    [SerializeField]
    GameObject Clues;

    [SerializeField]
    List<GameObject> Sprites;

    List<bool> BackupSpritesState;

    public void SetFlashbackOutside()
    {
        DisableSprites();
        FlashbackOutside.SetActive(true);
        FlashbackInside.SetActive(false);
        DefaultBackground.SetActive(false);
    }

    public void SetFlashbackInside()
    {
        Debug.Log("Flashback inside!");
        DisableSprites();
        FlashbackOutside.SetActive(false);
        FlashbackInside.SetActive(true);
        DefaultBackground.SetActive(false);
    }

    public void SetDefaultBackground()
    {
        EnableSprites();
        FlashbackOutside.SetActive(false);
        FlashbackInside.SetActive(false);
        DefaultBackground.SetActive(true);
    }

    private void EnableSprites()
    {
        Clues.SetActive(true);
        for (var i=0;  i< Sprites.Count;  i++)
        {
            Sprites[i].SetActive(BackupSpritesState[i]);
        }
    }

    private void DisableSprites()
    {
        Clues.SetActive(false);
        BackupSpritesState = new List<bool>();
        foreach (var sprite in Sprites)
        {
            BackupSpritesState.Add(sprite.activeSelf);
            sprite.SetActive(false);
        }
    }
}
