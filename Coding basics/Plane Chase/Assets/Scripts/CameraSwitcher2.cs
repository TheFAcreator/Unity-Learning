using UnityEngine;

public class CameraSwitcher2 : MonoBehaviour
{
    public Camera[] cameras;     // Drag your cameras here in inspector
    private int currentCam = 0;

    void Start()
    {
        // Enable only the first camera
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = i == 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))   // Press C to switch camera
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        cameras[currentCam].enabled = false;

        currentCam++;
        if (currentCam >= cameras.Length)
            currentCam = 0;

        cameras[currentCam].enabled = true;
    }
}
