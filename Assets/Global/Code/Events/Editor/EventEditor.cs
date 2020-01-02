// Shout out to mah boi Ryan Hipple
using UnityEngine;
using UnityEditor;

namespace King.Events
{
    [CustomEditor(typeof(CustomEvent))]
    public class EventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUI.enabled = Application.isPlaying;

            CustomEvent e = target as CustomEvent;
            if(GUILayout.Button("Raise"))
            {
                e.Raise();
            }
        }
    }
}