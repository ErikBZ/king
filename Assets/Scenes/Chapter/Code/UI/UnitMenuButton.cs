using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.UnitSystem;
using King.Events;
using King.LevelSystem;

[RequireComponent(typeof(Button))]
public class UnitMenuButton : MonoBehaviour
{
    public UnitList ActiveUnits;
    public CustomEvent ActiveUnitUpdatedEvent;
    // This should be a scriptable object reference
    public UnitReference Reference;
    public CustomEvent HoverEvent;
    public LevelRestrictionContext LevelRestrictionContext;
    // This is set by the Button Manager
    public Unit Unit;

    public void InitButton(Unit unit)
    {
        Unit = unit;
        this.GetComponent<Image>().sprite = unit.PortraitSprite;
        this.GetComponent<Image>().color = Color.grey;
        this.GetComponent<Image>().enabled = true;
    }

    public void UpdateUnitReference()
    {
        if(Reference.Unit == null || !Reference.Unit.Equals(Unit))
        {
            Reference.Unit = Unit;
            HoverEvent.Raise();
        }
    }

    public void UpdateActiveUnits()
    {
        List<Unit> units = ActiveUnits.Units;
        if(units.Contains(Unit))
        {
            units.Remove(Unit);
            ActiveUnitUpdatedEvent.Raise();
            this.GetComponent<Image>().color = Color.grey;
        }

        else if(units.Count < LevelRestrictionContext.AvailableTiles.Count)
        {
            units.Add(Unit);
            this.GetComponent<Image>().color = Color.white;
            ActiveUnitUpdatedEvent.Raise();
        }
    }
}
