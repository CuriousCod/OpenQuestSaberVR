using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PancakeModeManager : MonoBehaviour
{
    SceneHandling _sceneHandling;
    
    [SerializeField] Camera _overviewCamera;

    private bool _pancakeMode = false;
    private bool _elementsDisabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        VerifyMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_pancakeMode)
            return;
        
        if (_elementsDisabled)
            return;
        
        DisableVrElements();
        ChangeCanvasesToOverlay();
    }

    private async void VerifyMode(){

        await System.Threading.Tasks.Task.Delay(2000);

        _sceneHandling = FindObjectOfType<SceneHandling>();

        if (!_sceneHandling.IsPancake){
            enabled = false;
            return;
        }

        _pancakeMode = true;
        _overviewCamera.gameObject.SetActive(true);
    }

    private void DisableVrElements()
    {
        var vrCanvases = FindObjectsOfType<VRTK_UICanvas>();
        
        foreach (var vrCanvas in vrCanvases)
        {
            vrCanvas.enabled = false;
        }
        
        _elementsDisabled = true;
    }

    private static void ChangeCanvasesToOverlay()
    {
        var canvases = FindObjectsOfType<Canvas>();
        
        foreach (var canvas in canvases)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }
    
}
