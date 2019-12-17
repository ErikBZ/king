using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.Loader;

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
            SaveStateList.Saves = SaveStateLoader.Load();
        }

        if (SaveStateList.Saves.Count == 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
