using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class AnimatedClickableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public UnityEvent mouseExit, mouseEnter, mouseClick;

    public bool mouseEnterAnim = false;
    public Animator anim;
     public bool mouseInRect = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (mouseEnterAnim)
        {
            mouseInRect = true;
            mouseEnter.Invoke();
            anim.speed = 1 / Time.timeScale;
            anim.SetTrigger("WobbleUp");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (mouseEnterAnim)
        {
            mouseExit.Invoke();
            mouseInRect = false;
            anim.speed = 1 / Time.timeScale;
            anim.SetTrigger("WobbleDown");
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        mouseClick.Invoke();
    }
    private void Update()
    {
        //if (!rectTransform.rect.Contains(Input.mousePosition))
        //{
        //    OnPointerExit();
        //}
    }
}
