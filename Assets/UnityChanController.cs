using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    //Animatorを入れる
    Animator animator;
    //Rigidbodyを入れる
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLevel = -3.0f;
    //ジャンプ速度
    private float jumpVelocity = 20f;
    //ジャンプ速度の減衰
    private float dump = 0.8f;

    //ゲームオーバーになる距離
    private float deadLine = -9;

	// Use this for initialization
	void Start () {
        //Animatorコンポーネントを入れる
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 60;
    }
	
	// Update is called once per frame
	void Update () {
        //走るアニメーションを再生
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうか調べる
        bool isGround = (this.transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ中はボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックしたときジャンプ
        if (Input.GetMouseButton(0) && isGround)
        {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, jumpVelocity);
        }
        //クリックをやめたらジャンプ速度を減速
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= dump;
               
            }
        }

        //デッドラインを超えたらゲームオーバー
        if(this.transform.position.x<this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Unityちゃんを破棄
            Destroy(gameObject);
        }
	}
}
