using System.Collections.Generic;
using UnityEngine;
using King.UnitSystem;
using King.LevelSystem;

public class LevelStartMenu : MonoBehaviour
{

    public GameObject ButtonPrefab;
    public GameObject UnitListDisplay;
    public UnitList AvailableUnits;
    public UnitList UnitsSelectedForLevel;
    public LevelRestrictionContext levelRestrictions;

    [SerializeField] GameObject HUD;

    // this should be set by the map
    void Start()
    {
        UnitsSelectedForLevel.Units = new List<Unit>(levelRestrictions.AvailableTiles.Count);
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
