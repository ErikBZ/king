using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Maybe call this like UnityUtils?
[CreateAssetMenu(fileName = "UnityUtils", menuName = "UnityUtils", order = 0)]
public class UnityUtils : ScriptableObject
{
    public void Exit()
    {
    #if UNITY_STANDALONE
        Application.Quit();
    #endif

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
