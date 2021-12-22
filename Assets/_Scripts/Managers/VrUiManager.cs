using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VrUiManager : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void Initialize()
    {
        await System.Threading.Tasks.Task.Delay(1000);

        var sceneHandler = FindObjectOfType<SceneHandling>();

        if (sceneHandler.IsPancake)
            return;
        
        var cam = FindObjectOfType<SteamVR_Camera>().gameObject.GetComponent<Camera>();
        if (cam)
            cam.cullingMask &= ~(1 << LayerMask.NameToLayer("UI"));
        
        // var player = FindObjectOfType<VRTK_HeadsetCollider>();
        // if (!player)
        //     return;
        
        // var canvases = FindObjectsOfType<Canvas>();
        // foreach (var canvas in canvases)
        // {
        //     canvas.gameObject.layer = LayerMask.NameToLayer("UI");
        // }
        
        // uiCamera.transform.SetParent(player.transform);
        uiCamera.gameObject.SetActive(true);

    }
}
