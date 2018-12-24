using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using King.Pieces;

public class LevelStartMenu : MonoBehaviour
{

    public GameObject ButtonPrefab;
    public GameObject UnitListDisplay;
    public GameObject UnitDetailDisplay;
    public GameObject Capacity;
    public GameObject Grid;
    PlayerStartContext startLevelContext = new PlayerStartContext();

    // this should be set by the map
    LevelRestrictionContext levelRestrictions;

    // Start is called before the first frame update
    void Start()
    {
        levelRestrictions = Grid.GetComponentInChildren<LevelManager>().LevelRestrictionContext;
        InitializeStartMenu(new List<string>{ "Hi", "Hello", "How", "are", "you", "doing"});
        UpdateCapacityText(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Will have to refactor this when i figure out how actual units
    void InitializeStartMenu(List<string> UnitNames)
    {
        foreach(string unitName in UnitNames)
        {
            GameObject button = Instantiate(ButtonPrefab, ButtonPrefab.transform.position, Quaternion.identity);
            button.transform.SetParent(UnitListDisplay.transform);
            button.GetComponent<Image>().color = Color.grey;
            button.GetComponent<Button>().onClick.AddListener(() => { UnitMenuButtonAction(unitName, button.GetComponent<Image>()); });
            button.GetComponent<HoverableButton>().OnHoverEvents.AddListener(() => { UnitMenuButtonHoverAction(unitName); });
        }
    }

    void UnitMenuButtonAction(string ButtonToUnitKey, Image image)
    {
        // remove and set the button to show as such
        if(startLevelContext.Units.Contains(ButtonToUnitKey))
        {
            startLevelContext.Units.Remove(ButtonToUnitKey);
            image.color = Color.grey;
        }
        // only add if there's space left
        else if(startLevelContext.Units.Count < levelRestrictions.LevelCapcity)
        {
            startLevelContext.Units.Add(ButtonToUnitKey);
            image.color = Color.white;
        }
        UpdateCapacityText(startLevelContext.Units.Count);
    }

    void UnitMenuButtonHoverAction(string UnitKey)
    {
        UnitDetailDisplay.GetComponentInChildren<Text>().text = UnitKey;
    }

    void UpdateCapacityText(int newSelectUnits)
    {
        Capacity.GetComponent<Text>().text = string.Format("{0}/{1}", newSelectUnits, levelRestrictions.LevelCapcity);
    }
}
