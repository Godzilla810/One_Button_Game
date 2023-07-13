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

    public bool isReady = true;
    public bool isChargeUp = false;
    public bool isFly = false;
    public bool isEnd = false;
    void Start()
    {
        //開始
        Ready();
    }
    // Update is called once per frame
    void Update()
    {
        //重開
        if (Input.GetKeyDown("space") && !isReady && isEnd){
            Restart();
        }
    }
    //主選單
    public void Ready(){
        isEnd = false;
        isReady = true;
        StartCoroutine(ActivateChargeUpAfterDelay(1));
    }
    //蓄力
    public void ChargeUp(){
        isReady = false;
        isChargeUp = true;
        banana.SetActive(false);
        StartCoroutine(ActivateFlyAfterDelay(5));
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
        GetComponent<ScoreStored>().SaveScore();
    }
    //重開(動作)
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GetComponent<ScoreStored>().SaveData();
    }

    IEnumerator ActivateChargeUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ChargeUp();
    }
    IEnumerator ActivateFlyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        banana.SetActive(true);
        Fly();
    }
}
