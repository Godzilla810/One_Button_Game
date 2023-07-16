using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class RecordManager : MonoBehaviour
{
    public static RecordManager instance;
    void Awake() {
        if (instance != null){
            return;
        }
        instance = this;
    }

    private string filePath;

    private string GetPath()
    {
        for (int i = 0; i < 10;i++){
            string filePath = Application.streamingAssetsPath + "/data" + i + ".txt";
            if (!System.IO.File.Exists(filePath)){
                return filePath;
            }
        }
        return Application.streamingAssetsPath + "/data11.txt";
    }

    private string GetPath(int i)
    {
        return Application.streamingAssetsPath + "/data" + i + ".txt";
    }

    public void CreateTextFile(string name, int count, float distance)
    {
        filePath = GetPath();
        // 创建文本文件并写入数据
        PlayerData data = new PlayerData();
        data.name = name;
        data.count = count;
        data.distance = distance;

        string json = JsonConvert.SerializeObject(data);

        using (StreamWriter file = new StreamWriter(filePath))
        {
            file.Write(json);
        }
    }

    // private void ReadTextFile()
    // {
    //     // 读取文本文件并提取数据
    //     if (File.Exists(filePath))
    //     {
    //         using (StreamReader file = new StreamReader(filePath))
    //         {
    //             string json = file.ReadToEnd();
    //             PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);

    //             Debug.Log("PlayerName: " + data.name);
    //             Debug.Log("ClickCount: " + data.count);
    //             Debug.Log("Distance: " + data.distance);
    //         }
    //     }
    // }
    public string PrintTextFile(int fileIndex){
        filePath = GetPath(fileIndex);
        if (File.Exists(filePath))
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                string json = file.ReadToEnd();
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);

                Debug.Log("PlayerName: " + data.name);
                Debug.Log("ClickCount: " + data.count);
                Debug.Log("Distance: " + data.distance);
                return (fileIndex+1) + "." + data.name + " : " + data.count + " " + data.distance;
            }
        }
        return null;
    }
}
