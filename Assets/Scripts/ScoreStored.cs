using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreStored : MonoBehaviour
{
    // Start is called before the first frame update
    public string playerName;
    public int playerScore;
    public int dataCount;
    public List<int> datas;
    void Start()
    {
        dataCount = 1;
        Sort();
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
                    data.score = GameObject.Find("GameManager").GetComponent<Count>().count;
                    string save = JsonUtility.ToJson(data);
                    StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "data" + dataCount));
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
                        if(loadData.score == datas[9] && GameObject.Find("GameManager").GetComponent<Count>().count >= datas[9])
                        {
                            playerData data = new playerData();
                            data.name = playerName;
                            data.score = GameObject.Find("GameManager").GetComponent<Count>().count;
                            string save = JsonUtility.ToJson(data);
                            StreamWriter fileLast = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "data" + j));
                            fileLast.Write(save);
                            fileLast.Close();
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
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
                //Debug.Log(i + "."+loadData.score);
            }
            else
            {
                break;
            }
            
        }
        datas.Sort((x, y) => -x.CompareTo(y));
        for (int i = 1; i <= datas.Count; i++)
        {
            Debug.Log(i + "." + datas[i - 1]);
        }

    }

    public class playerData
    {
        public string name;
        public int score;
    }
}
