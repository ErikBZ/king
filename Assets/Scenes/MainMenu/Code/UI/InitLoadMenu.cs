using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.SaveSystem;

[RequireComponent(typeof(GridLayoutGroup))]
public class InitLoadMenu : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public SaveStateList saveStateList;

    void Start()
    {
        if (saveStateList != null && saveStateList.Saves != null)
        {
            InitializeLoadMenu(saveStateList.Saves);
        }
    }

    void InitializeLoadMenu(List<SaveState> Saves)
    {
        foreach(SaveState save in Saves)
        {
            GameObject button  = Instantiate(ButtonPrefab, ButtonPrefab.transform.position, Quaternion.identity);
            button.transform.SetParent(transform);
            button.GetComponent<InitLoadStateButton>().InitButton(save);
        }
    }
}
