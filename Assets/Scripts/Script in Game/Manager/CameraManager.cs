using UnityEngine;

public class CameraManager : MonoBehaviour
{   

    public Camera[] cameras;
    public Transform banana;

    private float Camera3SwitchPosition;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        OpenCamera(0);
    }

    void Update()
    {
        if (banana.position.x >= 100 && banana.position.x <= 180)
        {
            OpenCamera(2);
        }
        else if (gameManager.isFly)
        {
            OpenCamera(1);
        }
        if (gameManager.isEnd){
            OpenCamera(3);
        }
    }
    void OpenCamera(int cameraIndex){
        for (int i = 0; i < cameras.Length; i++){
            if (i == cameraIndex){
                cameras[i].enabled = true;
            }
            else{
                cameras[i].enabled = false;
            }
        }
    }
}
