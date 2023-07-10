using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//----------ReadME----------//
// 確認目前狀態:
// isMenu
// 呼叫新的狀態:
// Menu()
//----------ReadME----------//
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() {
        if (instance != null){
            return;
        }
        instance = this;
    }
    public GameObject menuPanel;
    public GameObject chargeUpPanel;
    public GameObject flyPanel;
    public GameObject endPanel;

    public bool isMenu = true;
    public bool isChargeUp = false;
    public bool isFly = false;
    public bool isEnd = false;
    // Update is called once per frame
    void Update()
    {
        //蓄力
        if (Input.GetKeyDown("space") && isMenu && !isEnd){
            ChargeUp();
        }
        //重開
        else if (Input.GetKeyDown("space") && !isMenu && isEnd){
            Restart();
        }
    }
    //主選單
    public void Menu(){
        isEnd = false;
        isMenu = true;
        endPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    //蓄力
    public void ChargeUp(){
        isMenu = false;
        isChargeUp = true;
        menuPanel.SetActive(false);
        chargeUpPanel.SetActive(true);
    }
    //飛行過程
    public void Fly(){
        isChargeUp = false;
        isFly = true;
        chargeUpPanel.SetActive(false);
        flyPanel.SetActive(true);
    }
    //落地結束
    public void End(){
        isFly = false;
        isEnd = true;
        flyPanel.SetActive(false);
        endPanel.SetActive(true);
    }
    //重開(動作)
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
