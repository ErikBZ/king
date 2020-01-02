using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.SaveSystem;

[RequireComponent(typeof(Button))]
public class InitState : MonoBehaviour
{
    public SaveStateList SaveStateList;

    void Start()
    {
        if (SaveStateList != null)
        {
            // clear old garbage
            SaveStateList.Saves = new List<SaveState>();
            SaveStateList.Saves = SaveStateLoader.LoadFromJson();
        }

        if (SaveStateList.Saves.Count == 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
