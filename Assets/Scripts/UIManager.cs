using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject readyPanel;
    public GameObject chargeUpPanel;
    public GameObject flyPanel;
    public GameObject endPanel;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isReady){
            endPanel.SetActive(false);
            readyPanel.SetActive(true);
        }
        else if (gameManager.isChargeUp){
            readyPanel.SetActive(false);
            chargeUpPanel.SetActive(true);
        }
        else if (gameManager.isFly){
            chargeUpPanel.SetActive(false);
            flyPanel.SetActive(true);
        }
        if (gameManager.isEnd){
            flyPanel.SetActive(false);
            endPanel.SetActive(true);
        }
    }
}
