using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletescript : MonoBehaviour {

    GameObject[] blocks;                //フィールド中のblockオブジェクト抽出
    float[] blockx = new float[1000];    //各blockオブジェクトのx座標
    float[] blocky = new float[1000];    //各blockオブジェクトのy座標
    float[] rowy = new float[20];        //各列のy座標（全20列）
    int[] checkrow = new int[20];       //各列に含まれるblockの個数（全20列）
    List<float> deleteyset = new List<float>();  //blockを削除しないといけない列のy座標リスト
    public static int finish = 0;
    public static int fall = 0;
    float[] fally = new float[1000];


    // Use this for initialization
    void Start () {
        for (int i = 0; i < this.checkrow.Length; i++) {     //for(変数の初期化;繰り返す条件;変数の更新）{実行する処理} ++の意味1ずつ増やす
            this.rowy[i] = -9 + i * 1.0f;    //各列のブロックy座標定義
        }
    }

    // Update is called once per frame
    void Update() {
        if (finish == 1) {
            int i = 0;
            int j = 0;
            this.deleteyset.Clear();   //block削除列のy座標リストを調査前に初期化
            for (i = 0; i < this.checkrow.Length; i++) {
                this.checkrow[i] = 0;    //各列のblock個数を調査前に初期化
            }

            i = 0;
            //現状のフィールド中の全blockオブジェクトの位置調査
            this.blocks = GameObject.FindGameObjectsWithTag("otherblock");
            foreach (GameObject block in this.blocks) {   //foreach(型名　オブジェクト名　in　コレクション)　{処理文}
                this.blockx[i] = Mathf.RoundToInt(block.transform.position.x * 10.0f) / 10.0f;　　　//mathf.roundtoint 四捨五入
                this.blocky[i] = Mathf.RoundToInt(block.transform.position.y * 10.0f) / 10.0f;
                i++;
            }

            //各列（y=-9,-8,…,8,9）のblock個数をカウント
            i = 0;
            for (i = 0; i < this.checkrow.Length; i++) {
                j = 0;
                foreach (GameObject block in this.blocks) {
                    //全blockをy座標ごとに分類し、各列に何個blockがあるかを調査
                    if (this.rowy[i] == this.blocky[j]) this.checkrow[i]++;  //if(y座標　== このブロックのy座標)　ブロックの個数+1
                    j++;
                }
            }

            i = 0;
            for (i = 0; i < this.checkrow.Length; i++) {
                if (this.checkrow[i] == 10) {
                    //列のブロック数が10個に到達していたら、以下のリストにその列のy座標を追加
                    this.deleteyset.Add(this.rowy[i]);　　　//↑削除しないといけないリスト
                }
            }

            //block削除
            for (i = 0; i < this.deleteyset.Count; i++) {
                j = 0;
                foreach (GameObject block in this.blocks) {
                    //削除リスト中のy座標とblockのy座標が一致したら削除
                    if (this.deleteyset[i] == this.blocky[j]) Destroy(block);
                    j++;
                }
            }

            i = 0;
            this.blocks = GameObject.FindGameObjectsWithTag("otherblock");
            foreach (GameObject block in this.blocks) {
                this.blockx[i] = Mathf.RoundToInt(block.transform.position.x * 10.0f) / 10.0f;
                this.blocky[i] = Mathf.RoundToInt(block.transform.position.y * 10.0f) / 10.0f;
                this.fally[i] = 0.0f;       //【この行を追加】
                i++;
            }

            //block削除後の落ちる高さを算出【以下は全て削除列数決定後に追加】
            j = 0;
            foreach (GameObject block in this.blocks) {
                for (i = 0; i < this.deleteyset.Count; i++)
                {
                    //j番ブロックのy座標が削除列y座標リストの要素より大きければ落下+1.0f追加
                    if (this.blocky[j] >= this.deleteyset[i]) this.fally[j] += 1.0f;
                }
                j++;
            }

            //削除後のblock一斉落下処理
            for (j = 0; j < this.blocks.Length; j++) {
                if (this.deleteyset.Contains(this.blocky[j]) == false) {
                    //削除されてないblockに対してのみ落下の指示
                    this.blocks[j].transform.Translate(0, -this.fally[j], 0, Space.World);
                    fall = 1;
                }
            }
            finish = 0;
        }
    }
}
