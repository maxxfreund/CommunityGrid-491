using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool RightBtnDown = false;

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("R BTN DOWN");
        RightBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("R BTN UP");
        RightBtnDown = false;
    }
}
