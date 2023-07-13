using UnityEngine;

public class CameraManager : MonoBehaviour
{   

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject banana;

    private float Camera3SwitchPosition;

    public bool hasSwitchedToCamera2 = false;
    public bool hasSwitchedToCamera3 = false;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;

        // Initialize all the cameras
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);

        Camera3SwitchPosition = Camera3.transform.position.x - 50;
    }

    void Update()
    {
        if (!hasSwitchedToCamera2 && gameManager.isFly)
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            hasSwitchedToCamera2 = true;
        }
        if (!hasSwitchedToCamera3 && banana.transform.position.x >= Camera3SwitchPosition)
        {
            Camera2.SetActive(false);
            Camera3.SetActive(true);
            hasSwitchedToCamera3 = true;

        }
        if (banana.transform.position.x >= 150)
        {
            Camera3.SetActive(false);
            Camera2.SetActive(true);
        }
        if (gameManager.isEnd){
            Camera2.SetActive(false);
            Camera4.SetActive(true);
        }
    }
}
