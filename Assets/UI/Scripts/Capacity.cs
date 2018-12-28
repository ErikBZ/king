using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.Pieces;

public class Capacity : MonoBehaviour
{
    // May need make this a reference and exapnd on references
    public LevelRestrictionContext Context;
    public UnitList ActiveUnits;


    private void Start()
    {
        UpdateCapcity();
    }
    public void UpdateCapcity()
    {
        int activeUnitsCount = ActiveUnits.Units.Count;
        this.GetComponent<Text>().text = string.Format("{0}/{1}", activeUnitsCount, Context.AvailableTiles.Count);
    }
}
