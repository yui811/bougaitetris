using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ioneblockscript : MonoBehaviour {

    public static bool flag = false;
    public static int delete = 0;
    BoxCollider a;

    // Use this for initialization
    void Start () {
        a = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (flag == false) {
            a.size = new Vector3(0.6f, 1, 1);
        }
        if (flag == true) {
            a.size = new Vector3(1, 0.6f, 1);
        }
        if (Igroupblockscript.drop == 0) {
            gameObject.layer = LayerMask.NameToLayer("otherblock");
            gameObject.tag = "otherblock";
        }
        if (Igroupblockscript.canmove == 1) {
            this.gameObject.transform.parent = null;
            delete = 1;
        }
    }
}
