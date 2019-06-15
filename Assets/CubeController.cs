using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //キューブの移動速度
    private float speed = -0.2f;
    //キューブの消滅位置
    private float deadLine = -10;
    //
    private AudioSource block;

	// Use this for initialization
	void Start () {
        //AudioSourceコンポーネントを入れる
        this.block = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(this.speed, 0, 0);

        if (this.transform.position.x < this.deadLine)
        {
            Destroy(this.gameObject);
        }
	}

    //衝突判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面かブロックに衝突したとき音を鳴らす
        if (collision.gameObject.tag == "Cube" || collision.gameObject.tag == "Ground")
        {
            this.block.Play();
        }
    }
}
