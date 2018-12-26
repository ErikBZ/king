using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using King.Pieces;

public class LevelStartMenu : MonoBehaviour
{

    public GameObject ButtonPrefab;
    public GameObject UnitListDisplay;
    public UnitList AvailableUnits;
    public UnitList UnitsSelectForLevel;
    public LevelRestrictionContext levelRestrictions;

    // this should be set by the map

    // Start is called before the first frame update
    void Start()
    {
        UnitsSelectForLevel.Units = new List<Unit>(levelRestrictions.LevelCapcity);
        InitializeStartMenu(AvailableUnits.Units);
    }

    void InitializeStartMenu(List<Unit> Units)
    {
        foreach(Unit unit in Units)
        {
            GameObject button = Instantiate(ButtonPrefab, ButtonPrefab.transform.position, Quaternion.identity);
            button.transform.SetParent(UnitListDisplay.transform);
            button.GetComponent<UnitMenuButton>().InitButton(unit);
        }
    }
}
