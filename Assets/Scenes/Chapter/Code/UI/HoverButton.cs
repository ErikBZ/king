using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoverButton : MonoBehaviour, IPointerEnterHandler
{
    public UnityEvent Response;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Response.Invoke();
    }
}
