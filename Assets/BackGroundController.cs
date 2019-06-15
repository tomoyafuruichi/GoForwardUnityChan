using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {

    //背景のスクロールの速さ
    private float scrollSpeed = -0.03f;
    //背景の終了位置
    private float deadLine = -16;
    //背景の開始位置
    private float startLine = 15.8f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //背景をスクロールする
        transform.Translate(this.scrollSpeed, 0,0 );

        //画面外に出たら背景を開始位置に移動
        if(this.transform.position.x<this.deadLine)
        {
            this.transform.position = new Vector2(startLine, 0);
        }

		
	}
}
