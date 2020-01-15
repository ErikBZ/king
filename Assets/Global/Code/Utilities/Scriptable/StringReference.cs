using UnityEngine;

[CreateAssetMenu(fileName = "StringReference", menuName = "Generic/StringReference", order = 0)]
public class StringReference : ScriptableObject
{
    public string Reference;

    public void UpdateReference(string update)
    {
        Reference = update;
    }
}
