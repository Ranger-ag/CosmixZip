using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuBTN : MonoBehaviour
     , IPointerDownHandler
     , IPointerUpHandler
     , IPointerEnterHandler
     , IPointerExitHandler
{

    public UnityEvent OnClick;

    const float HoverBTSpeed = 5.12f;
    const float HoverBTSize = 1.04f;

    const float ClickBTSpeed = 13.32f;
    const float ClickBTSize = 1.10f;

    Vector3 originalSize;
    Vector3 targetSize;

    float btSpeed = 0;

    bool isClick = false;
    bool isHover = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
        btSpeed = ClickBTSpeed;
        targetSize = originalSize * ClickBTSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;

        if (isClick)
        {
            btSpeed = ClickBTSpeed;
        }
        else
        {
            btSpeed = HoverBTSpeed;
        }

        if (!isClick)
        {
            targetSize = originalSize * HoverBTSize;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;

        if (isClick)
        {
            btSpeed = ClickBTSpeed;
        }
        else
        {
            btSpeed = HoverBTSpeed;
        }

        isClick = false;
        targetSize = originalSize;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (isClick)
        {
            btSpeed = ClickBTSpeed;
        }
        else
        {
            btSpeed = HoverBTSpeed;
        }

        isClick = false;
        if (isHover)
        {
            targetSize = originalSize * HoverBTSize;
            OnClick?.Invoke();
        }
    }

    void Start()
    {
        if (OnClick == null)
            OnClick = new UnityEvent();

        originalSize = transform.localScale;
        targetSize = originalSize;
    }

    void Update()
    {
        if(targetSize != transform.localScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, Time.deltaTime * btSpeed);
        }
    }
}
