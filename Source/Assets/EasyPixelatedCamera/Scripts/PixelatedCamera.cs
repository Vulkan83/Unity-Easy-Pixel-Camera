using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelatedCamera : MonoBehaviour {

    
    [Header("settings")]
    public int screenSizeWidth = 384;
    public int screenSizeHeight = 216;

    [Header("Display")]
    public RawImage display;

    private Camera renderCamera;
    private RenderTexture renderTexture;
    private int currentScreenWidth;
    private int currentScreenHeight;

    /****************************************/


    private void OnValidate() {
        if (screenSizeWidth < 1) screenSizeWidth = 1;
        if (screenSizeHeight < 1) screenSizeHeight = 1;
    }


    private void Start() {
        Init();
    }



    /****************************************/


    public void Init() {
        if (!renderCamera) renderCamera = GetComponent<Camera>();
        currentScreenWidth = Screen.width;
        currentScreenHeight = Screen.height;

        if (screenSizeWidth < 1) screenSizeWidth = 1;
        if (screenSizeHeight < 1) screenSizeHeight = 1;

        renderTexture = new RenderTexture(screenSizeWidth, screenSizeHeight, 24) {
            filterMode = FilterMode.Point,
            antiAliasing = 1
        };
        
        renderCamera.targetTexture = renderTexture;
        display.texture = renderTexture;
    }



    public bool CheckScreenResize() {
        bool result = Screen.width != currentScreenWidth || Screen.height != currentScreenHeight;
        return result;
    }

}
