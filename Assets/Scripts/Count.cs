using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public bool isCount = false;
    public int countdown = 5;
    public int count;
    public float distance;

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI countText_ChargeUp;
    public TextMeshProUGUI countText_Fly;
    public TextMeshProUGUI distanceText_Fly;
    public TextMeshProUGUI distanceText_End;

    public GameObject axeObj;
    
    private GameManager gameManager;
    private Axe axe;
    private Vector3 startPos;

    void Start()
    {
        gameManager = GameManager.instance;
        axeObj = GameObject.Find("Axe");
        axe = GameObject.Find("Axe").GetComponent<Axe>();
        startPos = axeObj.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //蓄力(計時)開始
        if (gameManager.isStart && !isCount && !axe.isThrow){
            StartCoroutine(Countdown());
        }
        //計數
        if (Input.GetKeyDown("space") && isCount){
            count++;
            Debug.Log("count");
            countText_ChargeUp.text = count.ToString();
        }
        //計數
        if (gameManager.isFly){
            CountDistance();
        }
    }
    //計時
    IEnumerator Countdown(){
        count = 0;
        isCount = true;

        for (int i = countdown; i >= 0; i--){
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        isCount = false;
        count = GetCount();
        axe.Throw();
        gameManager.Fly();
        Debug.Log("Score:" + count);
    }
    public int GetCount(){
        countText_Fly.text = count.ToString();
        return count;
    }
    //計距離
    public void CountDistance(){
        Vector3 axe_X = new Vector3 (axeObj.transform.position.x, 0f, 0f);
        Vector3 start_x = new Vector3 (startPos.x, 0f, 0f);
        distance = Vector3.Distance(axe_X, start_x);
        distanceText_Fly.text = distance.ToString();
        GetScore();
    }
    public float GetScore(){
        distanceText_End.text = distance.ToString();
        return distance;
    }
}
