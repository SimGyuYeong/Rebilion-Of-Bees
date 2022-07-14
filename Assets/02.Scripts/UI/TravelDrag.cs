using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TravelDrag : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static bool IsDrag = false;

    private Image _iconImage;

    private void Awake()
    {
        _iconImage = transform.Find("DefaultIcon").GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Bee bee = eventData.pointerDrag.GetComponent<Bee>();
        bee.Travle();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(IsDrag == true)
        {
            _iconImage.color = Color.red;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _iconImage.color = Color.white;
    }
}
