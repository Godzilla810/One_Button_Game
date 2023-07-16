using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;
    public TextMeshProUGUI[] records;
    public Sprite[] sprites;
    public GameObject CG;

    public TextMeshProUGUI inputText;

    private GameManager gameManager;
    private RecordManager recordManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        recordManager = RecordManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isMenu){
            OpenPanel(0);
            GetRecord();
        }
        if (gameManager.isReady){
            OpenPanel(1);
        }
        else if (gameManager.isChargeUp){
            OpenPanel(2);
        }
        else if (gameManager.isFly){
            OpenPanel(3);
        }
        if (gameManager.isEnd){
            OpenPanel(4);
            GetCG();
        }
    }
    void GetRecord(){
        for (int i = 0;i < 10; i++){
            records[i].text = recordManager.PrintTextFile(i);
        }
    }
    void GetCG(){
        float distance = GameObject.Find("Banana").GetComponent<Axe>().distance;
        if (distance <= 500){
            CG.GetComponent<Image>().sprite = sprites[0];
        }
        else if (distance > 500 && distance <= 1000)
        {
            CG.GetComponent<Image>().sprite = sprites[1];
        }
        else if (distance > 1000 && distance <= 1500)
        {
            CG.GetComponent<Image>().sprite = sprites[2];
        }
        else if (distance > 1500 && distance <= 2000)
        {
            CG.GetComponent<Image>().sprite = sprites[3];
        }
        else if (distance > 2000)
        {
            CG.GetComponent<Image>().sprite = sprites[4];
        }
    }
    void OpenPanel(int panelIndex){
        for (int i = 0; i < panels.Length; i++){
            if (i == panelIndex){
                panels[i].SetActive(true);
            }
            else{
                panels[i].SetActive(false);
            }
        }
    }
}
