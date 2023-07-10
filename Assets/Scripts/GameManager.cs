using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() {
        if (instance != null){
            return;
        }
        instance = this;
    }
    public GameObject startPanel;
    public GameObject chargeUpPanel;
    public GameObject flyPanel;
    public GameObject endPanel;

    public bool isStart = false;
    public bool isFly = false;
    public bool isEnd = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !isStart && isEnd){
            StartGame();
        }
        else if (Input.GetKeyDown("space") && !isStart){
            Restart();
        }
    }

    public void StartGame(){
        isStart = true;
        ChargeUp();
    }
    public void ChargeUp(){
        startPanel.SetActive(false);
        chargeUpPanel.SetActive(true);
    }
    public void Fly(){
        isFly = true;
        chargeUpPanel.SetActive(false);
        flyPanel.SetActive(true);
    }
    public void EndGame(){
        isFly = false;
        isStart = false;
        isEnd = false;
        flyPanel.SetActive(false);
        endPanel.SetActive(true);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        endPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
