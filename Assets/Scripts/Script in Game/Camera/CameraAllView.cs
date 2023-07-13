using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAllView : MonoBehaviour
{
    public Transform banana;
    public Transform player;
    public Camera camera;
    public float speed;
    private Vector3 dir;
    private bool isInitial = false;
    private bool isArrive;
    private bool isSmall;
    private bool isBig;

    private GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isArrive = (transform.position.x <= player.position.x);
        isBig = (camera.orthographicSize >= 3);
        isSmall = (camera.orthographicSize <= 70);
        if (!isInitial && gameManager.isEnd){
            Initialize();
            isInitial = true;
        }
        else{
            if (!isArrive && isSmall){
                ScaleUp();
            }
            if (!isArrive && !isSmall){
                Move();
            }
            if (isArrive && isBig){
                ScaleDown();
            }
        }
    }
    void Initialize(){
        Vector3 initialPos = new Vector3 (banana.position.x, 20, 0);
        transform.position = initialPos;
        camera.orthographicSize = 3;
        //目標方向
        dir = new Vector3(player.position.x - banana.position.x, 0, 0).normalized;
    }
    void Move(){
        transform.Translate(dir * Time.deltaTime * speed);
    }
    void ScaleUp(){
        camera.orthographicSize += speed / 2 * Time.deltaTime;
    }
    void ScaleDown(){
        camera.orthographicSize -= speed / 2 * Time.deltaTime;
    }
}
