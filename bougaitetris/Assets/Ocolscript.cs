using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocolscript : MonoBehaviour {

    private GameObject O;

	// Use this for initialization
	void Start () {
        O = GameObject.Find("O");
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnCollisionStay(Collision col) {
        if (LayerMask.LayerToName(col.gameObject.layer) == "downwall") {
            O.transform.position += new Vector3(0, 1, 0);
            Igroupblockscript.drop = 0;
        }
    }
}
