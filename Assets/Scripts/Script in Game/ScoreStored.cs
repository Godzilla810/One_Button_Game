using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class ScoreStored : MonoBehaviour
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

    public TextMeshProUGUI inputText;
    public TextMeshProUGUI loadedName;
    public GameObject enterName;
    void Start()
    {

        //for (int i = 1; i <= 10; i++)
        //{
        //    Debug.Log(datas[i]);
        //    //ranking.Add(new nameAndScore(names[i], datas[i]));
        //}

        
        PlayerPrefs.SetString("name", "none");
        dataCount = 1;
        CountSort();

    }
    void Update()
    {
        playerName = PlayerPrefs.GetString("name", "none");
        loadedName.text = playerName;
    }

    public void SetName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
        enterName.SetActive(false);
    }

    public void SaveScore()
    {
        for (int i = 1; i <= 11; i++)
        {
            if (i <= 10)
            {
                if (System.IO.File.Exists(Application.streamingAssetsPath + "/count" + i))
                {
                    dataCount++;
                }
                else
                {
                    playerData data = new playerData();
                    //data.name = playerName;
                    data.count = GameObject.Find("GameManager").GetComponent<Count>().count;
                    //data.score = GameObject.Find("Banana").GetComponent<Axe>().GetDistance();
                    string save = JsonUtility.ToJson(data);
                    StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "count" + i));
                    file.Write(save);
                    file.Close();
                    Debug.Log(dataCount);
                    break;
                }
            }
            else if (i == 11)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (System.IO.File.Exists(Application.streamingAssetsPath + "/count" + j))
                    {
                        StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "count" + j));
                        string loadJson = file.ReadToEnd();
                        file.Close();
                        playerData loadData = new playerData();
                        loadData = JsonUtility.FromJson<playerData>(loadJson);
                        Debug.Log("min:" + counts[9]);
                        if (loadData.count == counts[9] && GameObject.Find("GameManager").GetComponent<Count>().count > counts[9])
                        {
                            Debug.Log("asdasdasd");
                            playerData data = new playerData();
                            //data.name = playerName;
                            data.count = GameObject.Find("GameManager").GetComponent<Count>().count;
                            //data.score = GameObject.Find("Banana").GetComponent<Axe>().GetDistance();
                            string save = JsonUtility.ToJson(data);
                            StreamWriter fileLast = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "count" + j));
                            fileLast.Write(save);
                            fileLast.Close();
                            break;
                        }
                        else
                        {
                            enterName.SetActive(false);
                        }
                    }
                    //else
                    //{
                    //    break;
                    //}
                }
            }
        }
    }
    public void SaveData()
    {
        for(int i = 1; i <= 11; i++)
        {
            if(i <= 10)
            {
                if (System.IO.File.Exists(Application.streamingAssetsPath + "/data" + i))
                {
                    dataCount++;
                }
                else
                {
                    playerData data = new playerData();
                    data.name = playerName;
                    data.count = GameObject.Find("GameManager").GetComponent<Count>().count;
                    data.score = GameObject.Find("Banana").GetComponent<Axe>().GetDistance();
                    string save = JsonUtility.ToJson(data);
                    StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "data" + i));
                    file.Write(save);
                    file.Close();
                    Debug.Log(dataCount);
                    break;
                }
            }
            
            else if(i == 11)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (System.IO.File.Exists(Application.streamingAssetsPath + "/data" + j))
                    {
                        StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "data" + j));
                        string loadJson = file.ReadToEnd();
                        file.Close();
                        playerData loadData = new playerData();
                        loadData = JsonUtility.FromJson<playerData>(loadJson);
                        Debug.Log("min:" + counts[9]);
                        if(loadData.count == counts[9] && GameObject.Find("GameManager").GetComponent<Count>().count > counts[9])
                        {
                            Debug.Log("asdasdasd");
                            enterName.SetActive(true);
                            playerData data = new playerData();
                            data.name = playerName;
                            data.count = GameObject.Find("GameManager").GetComponent<Count>().count;
                            data.score = GameObject.Find("Banana").GetComponent<Axe>().GetDistance();
                            string save = JsonUtility.ToJson(data);
                            StreamWriter fileLast = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "data" + j));
                            fileLast.Write(save);
                            fileLast.Close();
                            break;
                        }
                    }
                    //else
                    //{
                    //    break;
                    //}
                }
            }
        }
    }

    public void CountSort()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (System.IO.File.Exists(Application.streamingAssetsPath + "/count" + i))
            {
                StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "count" + i));
                string loadJson = file.ReadToEnd();
                file.Close();
                playerData loadData = new playerData();
                loadData = JsonUtility.FromJson<playerData>(loadJson);
                counts.Add(loadData.count);
            }
            else
            {
                break;
            }
            counts.Sort((x, y) => -x.CompareTo(y));
        }
    }
    //public void Sort()
    //{
    //    datas.Clear();
        
//        for (int i = 1; i <= 10; i++)
//        {
//            if (System.IO.File.Exists(Application.streamingAssetsPath + "/data" + i))
//            {
//                StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "data" + i));
//    string loadJson = file.ReadToEnd();
//    file.Close();
//                playerData loadData = new playerData();
//    loadData = JsonUtility.FromJson<playerData>(loadJson);
//                datas.Add(loadData.score);
//                counts.Add(loadData.count);
//                names.Add(loadData.name);
//            }
//            else
//{
//    break;
//}  
//        }
    //    counts.Sort((x, y) => -x.CompareTo(y));
    //    List<nameAndScore> ranking = new List<nameAndScore>();
    //    for (int i = 0; i < datas.Count; i++)
    //    {
    //        ranking.Add(new nameAndScore(names[i], datas[i]));
            
    //    }
    //    ranking.Sort((x, y) => { return -x.score.CompareTo(y.score); });
    //    foreach(nameAndScore aa in ranking)
    //    {
    //        Debug.Log(aa.toString());
    //        sortedScore.Add(aa.toString());
    //    }
    //    for (int i = 1; i <= datas.Count; i++)
    //    {
    //        GameObject.Find("Ranking/" + i).GetComponent<TextMeshProUGUI>().text = i + "." + sortedScore[i-1];
    //    }
    //}

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

        // public string toString()
        // {
        //     return name + " : " + score;
        // }
    }
}
