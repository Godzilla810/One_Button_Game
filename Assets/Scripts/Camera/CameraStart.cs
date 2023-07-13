using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    private GameManager gameManager;
    public void GoReady(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.Ready();
    }
}
