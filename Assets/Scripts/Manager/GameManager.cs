using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//----------ReadME----------//
// 確認目前狀態:
// isReady
// 呼叫新的狀態:
// Ready()
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
    public GameObject banana;

    public bool isMenu = true;
    public bool isReady = false;
    public bool isChargeUp = false;
    public bool isFly = false;
    public bool isEnd = false;
    void Start()
    {
        //開始
        Menu();
    }
    // Update is called once per frame
    void Update()
    {
        //重開
        if (Input.GetKeyDown("space") && isEnd){
            Restart();
        }
    }
    //開始
    public void Menu(){
        isEnd = false;
        isMenu = true;
    }
    //準備
    public void Ready(){
        isMenu = false;
        isReady = true;
        StartCoroutine(ActivateChargeUpAfterDelay(1));
    }
    //蓄力
    public void ChargeUp(){
        isReady = false;
        isChargeUp = true;
        banana.SetActive(false);
        StartCoroutine(ActivateBananaAfterDelay(4.99f));
    }
    //飛行過程
    public void Fly(){
        isChargeUp = false;
        isFly = true;
    }
    //落地結束
    public void End(){
        isFly = false;
        isEnd = true;
        // GetComponent<ScoreStored>().SaveScore();
    }
    //重開(動作)
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // GetComponent<ScoreStored>().SaveData();
    }
    IEnumerator ActivateReadyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Ready();
    }
    IEnumerator ActivateChargeUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ChargeUp();
    }
    IEnumerator ActivateBananaAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        banana.SetActive(true);
    }
}
