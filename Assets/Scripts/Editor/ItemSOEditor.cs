using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemSO))]
public class ItemSOEditor : Editor
{   
    public override void OnInspectorGUI(){
        DrawDefaultInspector();
        ItemSO itemSOScript = (ItemSO)target;

        if(GUILayout.Button("Paste Pose"))
        {
            string buffer = EditorGUIUtility.systemCopyBuffer;
            buffer = buffer.Replace("(", "").Replace(")", "");
            string[] num = buffer.Split(',');
            Quaternion rotation = new Quaternion(float.Parse(num[0]), float.Parse(num[1]), float.Parse(num[2]), float.Parse(num[3]));
            itemSOScript.poseRotation = rotation;
            itemSOScript.poseScale = float.Parse(num[4]);
            EditorUtility.SetDirty(itemSOScript);
        }
    }
}