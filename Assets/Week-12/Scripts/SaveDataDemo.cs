using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class SaveDataDemo : MonoBehaviour
{
    public int score;
    public string username;
    public float balance 
    {
        get
        {
            return _balance;
        }
        set
        {
            _balance = value;
            PlayerPrefs.SetFloat("balance", _balance);
        }
    }
    private float _balance;

    public DataDemo data;

    [ContextMenu ("Do Save")]
    public void SaveDataTest()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetFloat("balance", balance);

        // one way to save player position- can also use 3 seperate pieces of data using PlayerPrefs.SetFloat();
        string position = string.Format("{0} {1} {2}", transform.position.x, transform.position.y, transform.position.z);
        PlayerPrefs.SetString("position", position);

        data.score = score;
        data.username = username;
        data.balance = balance;
        data.position = transform.position;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        PlayerPrefs.SetString("data", json);

        PlayerPrefs.Save();
    }
    [ContextMenu("Do File Save")]
    public void SaveToFile()
    {
        string path = "Assets/Resources/SaveData.txt";
        StreamWriter writer = new StreamWriter(path, false);

        data.score = score;
        data.username = username;
        data.balance = balance;
        data.position = transform.position;

        string json = JsonUtility.ToJson(data);
        writer.WriteLine(json);
        writer.Close();

        AssetDatabase.ImportAsset(path);
    }
}
