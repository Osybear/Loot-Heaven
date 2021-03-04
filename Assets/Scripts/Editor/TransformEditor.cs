using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class TransformEditor : Editor
{   
    private Editor defaultEditor;
    private Transform transform;
    
    void OnEnable(){
        //When this inspector is created, also create the built-in inspector
        transform = target as Transform;
		System.Type t = typeof(UnityEditor.EditorApplication).Assembly.GetType("UnityEditor.TransformInspector");
        if(defaultEditor == null)
		    defaultEditor = Editor.CreateEditor(transform, t);
    }

    public override void OnInspectorGUI()
    {
        defaultEditor.OnInspectorGUI();
    }

    [MenuItem("CONTEXT/Transform/Copy Pose")]
    static void CopyPositionAndScale(MenuCommand command){
        Transform tranform = (Transform)command.context;
        string temp = tranform.localRotation.ToString("F3") + ", " + tranform.lossyScale.ToString("F3");
        EditorGUIUtility.systemCopyBuffer = temp;
        Debug.Log(temp);
    }
}
