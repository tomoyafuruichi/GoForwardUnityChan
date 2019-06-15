using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    //キューブのprefab
    public GameObject cubePrefab;
    //時間計測の変数
    private float delta = 0;
    //生成間隔
    private float span = 1.0f;
    //キューブの生成位置
    private float genPosX = 12;
    //キューブの生成位置オフセット
    private float offsetX = 0.5f;
    private float offsetY= 0.3f;
    //キューブの横間隔
    private float spaceX = 0.4f;
    //キューブの縦間隔
    private float spaceY = 6.9f;
    //生成個数上限
    private int maxBlockNum = 4;
         


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;

        //span以上の時間が経過したか調べる
        if (this.delta > this.span)
        {
            this.delta = 0;
            //生成数をランダムに決定
            int n = Random.Range(1, maxBlockNum + 1);
            //指定個数を生成
            for (int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            //次の生成間隔を決定
            this.span = this.offsetX + spaceX * n;

        }
		
	}
}
