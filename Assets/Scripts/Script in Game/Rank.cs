using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Rank : MonoBehaviour
{
    // Start is called before the first frame update
    public string playerName;
    public string saveName;
    public int playerScore;
    public int dataCount;
    public List<int> counts;
    public List<float> datas;
    public List<string> names;
    public List<string> sortedScore;

   
    void Start()
    {

        //for (int i = 1; i <= 10; i++)
        //{
        //    Debug.Log(datas[i]);
        //    //ranking.Add(new nameAndScore(names[i], datas[i]));
        //}

        
        PlayerPrefs.SetString("name", "none");
        dataCount = 1;
        Sort();

    }
    void Update()
    {
        
    }

    public void Sort()
    {
        datas.Clear();
        
        for (int i = 1; i <= 10; i++)
        {
            if (System.IO.File.Exists(Application.streamingAssetsPath + "/data" + i))
            {
                StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "data" + i));
                string loadJson = file.ReadToEnd();
                file.Close();
                playerData loadData = new playerData();
                loadData = JsonUtility.FromJson<playerData>(loadJson);
                datas.Add(loadData.score);
                counts.Add(loadData.count);
                names.Add(loadData.name);
            }
            else
            {
                break;
            }  
        }
        counts.Sort((x, y) => -x.CompareTo(y));
        List<nameAndScore> ranking = new List<nameAndScore>();
        for (int i = 0; i < datas.Count; i++)
        {
            ranking.Add(new nameAndScore(names[i], datas[i]));
            
        }
        ranking.Sort((x, y) => { return -x.score.CompareTo(y.score); });
        foreach(nameAndScore aa in ranking)
        {
            Debug.Log(aa.toString());
            sortedScore.Add(aa.toString());
        }
        for (int i = 1; i <= datas.Count; i++)
        {
            GameObject.Find("Leader Board/" + i).GetComponent<TextMeshProUGUI>().text = i + "." + sortedScore[i-1];
        }
    }

    public class playerData
    {
        public string name;
        public float score;
        public int count;
    }

    public class nameAndScore
    {
        public string name;
        public float score;

        public nameAndScore(string name, float score)
        {
            this.name = name;
            this.score = score;
        }

        public string toString()
        {
            return " " + name + " : " + score;
        }
    }
}
