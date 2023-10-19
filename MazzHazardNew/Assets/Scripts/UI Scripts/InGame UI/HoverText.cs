using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverTextMessage;
    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverTextMessage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverTextMessage.SetActive(false);
    }
}
