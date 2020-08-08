using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockcreater : MonoBehaviour {

    public static int create = 1;
    public GameObject I;
    public GameObject O;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (create == 1) {
            int blocknumber = Random.Range(1, 3);
            Debug.Log(blocknumber);
            if (blocknumber == 1) {
                transform.position = new Vector3(0.5f, 9, 0);
                Instantiate(I, transform.position, transform.rotation);
                create = 0;
            }
            if (blocknumber == 2) {
                transform.position = new Vector3(0, 8.5f, 0);
                Instantiate(O, transform.position, transform.rotation);
                create = 0;
            }
        }
    }
}
