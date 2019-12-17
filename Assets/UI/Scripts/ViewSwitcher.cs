using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewSwitcher : MonoBehaviour
{
    public Toggle MenuToggleObject;
    public Toggle MapToggleObject;

    void Start()
    {
        this.GetComponentInChildren<Text>().text = MenuToggleObject.isOn ? "Menu" : "Map";
    }

    public void ToggleButton()
    {
        MenuToggleObject.isOn = !MenuToggleObject.isOn;
        MapToggleObject.isOn = !MapToggleObject.isOn;

        this.GetComponentInChildren<Text>().text = MenuToggleObject.isOn ? "Menu" : "Map";
    }

}
