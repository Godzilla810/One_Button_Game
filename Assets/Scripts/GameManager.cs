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
    public GameObject banana;

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
    }
    //蓄力
    public void ChargeUp(){
        isMenu = false;
        isChargeUp = true;

        banana.SetActive(false);
        // 4.99 秒後激活 banana
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
        GetComponent<ScoreStored>().SaveData();
    }
    //重開(動作)
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator ActivateBananaAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        banana.SetActive(true);
    }
}
