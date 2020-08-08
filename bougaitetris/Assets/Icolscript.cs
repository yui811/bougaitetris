using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icolscript : MonoBehaviour {

    private GameObject I;

	// Use this for initialization
	void Start () {
        I = GameObject.Find("I");
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnCollisionStay(Collision col) {
        if (LayerMask.LayerToName(col.gameObject.layer) == "downwall") {
            I.transform.position += new Vector3(0, 1, 0);
            Igroupblockscript.drop = 0;
        }
    }
}
