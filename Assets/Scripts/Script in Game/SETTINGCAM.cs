using UnityEngine;

public class SETTINGCAM : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject subCamera;
    public GameObject endingCamera;
    public GameObject banana;

    private float endingCameraSwitchPosition;

    public bool hasSwitchedToSubCamera = false;
    public bool hasSwitchedToEndingCamera = false;

    void Start()
    {
        // Initialize all the cameras
        mainCamera.SetActive(true);
        subCamera.SetActive(false);
        endingCamera.SetActive(false);

        // Calculate the x position to switch to the ending camera
        endingCameraSwitchPosition = endingCamera.transform.position.x - 50;
    }

    void Update()
    {
        // If the Banana's x position > 10 and has not switched to the sub camera yet, switch to the Sub Camera
        if (!hasSwitchedToSubCamera && banana.transform.position.x > 10)
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
            hasSwitchedToSubCamera = true; // Indicate that we have switched to the sub camera
        }

        // If the Banana's x position is equal to the ending camera's switch position and has not switched to the ending camera yet, switch to the Ending Camera
        if (banana.transform.position.x >= endingCameraSwitchPosition)
        {
            subCamera.SetActive(false);
            endingCamera.SetActive(true);
            hasSwitchedToEndingCamera = true; // Indicate that we have switched to the ending camera
        }
    }
}
