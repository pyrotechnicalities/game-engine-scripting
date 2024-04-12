using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadDataDemo : MonoBehaviour
{
    public int score;
    public string username;
    public float balance;

    public DataDemo data;

    [ContextMenu("Do Load")]
    public void LoadDataTest()
    {
        score = PlayerPrefs.GetInt("score");
        username = PlayerPrefs.GetString("username");
        balance = PlayerPrefs.GetFloat("balance");

        string positionString = PlayerPrefs.GetString("position", "0 0 0");
        // axis[0] is x, axis[1] is y, axis[2] is z
        string[] axis = positionString.Split(' ');
        transform.position = new Vector3(float.Parse(axis[0]), float.Parse(axis[1]), float.Parse(axis[2]));

        data = JsonUtility.FromJson<DataDemo>(PlayerPrefs.GetString("data"));
    }
}
