using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject readyPanel;
    public GameObject chargeUpPanel;
    public GameObject flyPanel;
    public GameObject endPanel;
    public GameObject cgImage;

    public Sprite cg1;
    public Sprite cg2;
    public Sprite cg3;
    public Sprite cg4;
    public Sprite cg5;

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
            GetCG();
        }
    }
        public void GetCG(){
        float distance = GameObject.Find("Banana").GetComponent<Axe>().GetDistance();
        if (distance <= 1000){
            cgImage.GetComponent<Image>().sprite = cg1;
        }
        else if (distance > 1000 && distance <= 2000)
        {
            cgImage.GetComponent<Image>().sprite = cg2;
        }
        else if (distance > 2000 && distance <= 3000)
        {
            cgImage.GetComponent<Image>().sprite = cg3;
        }
        else if (distance > 3000 && distance <= 4000)
        {
            cgImage.GetComponent<Image>().sprite = cg4;
        }
        else if (distance > 4000)
        {
            cgImage.GetComponent<Image>().sprite = cg5;
        }
    }
}
