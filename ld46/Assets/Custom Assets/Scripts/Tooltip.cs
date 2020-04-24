using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hasTextField { get => TooltipText != null; }
    [SerializeField]
    TMPro.TextMeshProUGUI TooltipText;
    Button button;

    private void Start()
    {
        TooltipText.gameObject.SetActive(false);
    }

    void ToggleText(bool isVisible)
    {
        TooltipText.gameObject.SetActive(isVisible);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToggleText(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToggleText(false);
    }
}
