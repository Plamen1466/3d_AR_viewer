using UnityEngine;
using System.Collections;

public class TestControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(h, v, 0f), Space.World);
        if (Input.GetButtonDown("Fire1"))
        {
            transform.localScale += new Vector3(0.002f, 0.002f, 0.002f);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            transform.localScale += new Vector3(-0.002f, -0.002f, -0.002f);
        }
    }
}
