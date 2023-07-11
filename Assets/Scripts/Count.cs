using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public GameObject thingToThrow;
    public bool isCount = false;
    public int countdown = 5;
    public int count;

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI chargeUpCountText;
    public TextMeshProUGUI flyCountText;
    public TextMeshProUGUI flyDistanceText;
    public TextMeshProUGUI endDistanceText;
    
    private GameManager gameManager;
    private Axe axe;
    

    void Start()
    {
        gameManager = GameManager.instance;
        axe = thingToThrow.GetComponent<Axe>();
    }
    // Update is called once per frame
    void Update()
    {
        //計時開始
        if (gameManager.isChargeUp && !isCount){
            StartCoroutine(Countdown());
        }
        //蓄力中(計次數)
        if (Input.GetKeyDown("space") && gameManager.isChargeUp){
            count++;
            chargeUpCountText.text = count.ToString() + "Hit";
        }
        //飛行中(計距離)
        if (gameManager.isFly){
            float distance = axe.GetDistance();
            flyDistanceText.text = distance.ToString();
            endDistanceText.text = distance.ToString();
        }
    }
    //計時
    IEnumerator Countdown(){
        count = 0;
        isCount = true;
        for (int i = countdown; i > 0; --i){
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        //計時結束後

        //紀錄最終count
        flyCountText.text = count.ToString();
        //丟出斧頭
        axe.ThrowWithForce(count);
        //切換到Fly
        gameManager.Fly();
        Debug.Log("Count:" + count);
    }

}