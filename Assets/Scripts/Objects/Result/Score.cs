using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int score = 123;

    private GameObject[] gameObjects = new GameObject[6];
    public GameObject score_0;
    public GameObject score_1;
    public GameObject score_2;
    public GameObject score_3;
    public GameObject score_4;
    public GameObject score_5;

    private Sprite[] sprites = new Sprite[10];
    public Sprite num_0;
    public Sprite num_1;
    public Sprite num_2;
    public Sprite num_3;
    public Sprite num_4;
    public Sprite num_5;
    public Sprite num_6;
    public Sprite num_7;
    public Sprite num_8;
    public Sprite num_9;
    // Use this for initialization
    void Start () {
        gameObjects[0] = score_0;
        gameObjects[1] = score_1;
        gameObjects[2] = score_2;
        gameObjects[3] = score_3;
        gameObjects[4] = score_4;
        gameObjects[5] = score_5;

        sprites[0] = num_0;
        sprites[1] = num_1;
        sprites[2] = num_2;
        sprites[3] = num_3;
        sprites[4] = num_4;
        sprites[5] = num_5;
        sprites[6] = num_6;
        sprites[7] = num_7;
        sprites[8] = num_8;
        sprites[9] = num_9;

        String score_string = String.Format("{0:D6}", score);
        for (int i = 0; i < 6; i++)
        {
            string num_str = score_string.Substring(i, 1);
            int num = int.Parse(num_str);
            gameObjects[5 - i].GetComponent<Image>().sprite = sprites[num];
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        String score_string = String.Format("{0:D6}", score);
        for (int i = 0; i < 6; i++)
        {
            string num_str = score_string.Substring(i, 1);
            int num = int.Parse(num_str);
            gameObjects[5 - i].GetComponent<Image>().sprite = sprites[num];
        }

    }
}
