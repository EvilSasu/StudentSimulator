using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractiveObjectController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color selectedColor;
    public Color clickedColor;

    private Image img;

    private void Start()
    {
        img = this.GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        img.color = clickedColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.color = selectedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = defaultColor;
    }
}
