using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PixelatedCamera))]
public class PixelatedCameraEditor : Editor {

    PixelatedCamera pixelCamera;
 

    private void Awake() {
        pixelCamera = (PixelatedCamera)target;
    }


    public override void OnInspectorGUI() {
        if (DrawDefaultInspector() || pixelCamera.CheckScreenResize()) pixelCamera.Init();
    }


}
