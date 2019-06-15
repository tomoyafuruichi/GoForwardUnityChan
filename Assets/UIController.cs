using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    //ゲームオーバーテキスト
    private GameObject gameOverText;
    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 0;
    //走る速度
    private float speed = 0.03f;

    //ゲームオーバーの判定
    private bool isGameOver = false;

	// Use this for initialization
	void Start () {
        //ゲームオブジェクトを取得
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isGameOver == false)
        {
            //走った距離
            this.len += this.speed;
            //走った距離表示
            this.runLengthText.GetComponent<Text>().text = "Distance:" + len.ToString("F2") + "m";
        }
        //ゲームオーバーになったとき
        if (this.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    
	}

    public void GameOver()
    {
        //ゲームオーバー表示
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
