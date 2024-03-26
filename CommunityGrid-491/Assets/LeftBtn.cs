using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeftBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool LeftBtnDown = false;

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("L BTN DOWN");
        LeftBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("L BTN UP");
        LeftBtnDown = false;
    }
}
