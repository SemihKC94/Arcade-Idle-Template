using UnityEngine;

public class CameraFinderForWorldSpaceCanvas : MonoBehaviour
{
    private Canvas thisCanvas;
    private Camera mainCam;

    private void Start()
    {
        thisCanvas = GetComponent<Canvas>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        thisCanvas.worldCamera = mainCam;
    }
}
