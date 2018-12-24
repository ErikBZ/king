using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
    public class HoverableButton : Button, IPointerEnterHandler
    {

        public UnityEvent OnHoverEvents;
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            OnHoverEvents.Invoke();
        }
    }
}