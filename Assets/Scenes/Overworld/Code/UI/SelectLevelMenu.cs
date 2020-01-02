using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.LevelSystem;

[RequireComponent(typeof(GridLayoutGroup))]
public class SelectLevelMenu : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public LevelDataList levelDataList;

    void Start()
    {
        if (levelDataList != null && levelDataList.Levels != null)
        {
            InitializeLoadMenu(levelDataList.Levels);
        }
    }

    void InitializeLoadMenu(List<LevelData> Data)
    {
        foreach(LevelData data in Data)
        {
            GameObject button  = Instantiate(ButtonPrefab, ButtonPrefab.transform.position, Quaternion.identity);
            button.transform.SetParent(transform);
            button.GetComponent<SelectLevelButton>().InitButton(data);
        }
    }
}
