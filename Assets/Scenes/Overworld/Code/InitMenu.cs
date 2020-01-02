using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using King.Loader;

public class InitMenu : MonoBehaviour
{
    public ObjectReference SaveStateReference;
    SaveState SaveState;

    void Start()
    {        
        if (SaveStateReference != null && 
            SaveStateReference.Reference != null &&
            SaveStateReference.Reference.GetType() == typeof(SaveState))
        {
            SaveState = (SaveState) SaveStateReference.Reference;
            GetComponent<Text>().text = SaveState.PlayerName;
        }
    }
}
