using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankDrop : MonoBehaviour {


    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("mach was");
            // gameObject.SetActive(false);
            //          float power = 100;
            // float radius = 10f;
            // float upwardsModifier = 0;
            //rb.AddExplosionForce(power, other.transform.position, radius, upwardsModifier);

            rb.AddForce(new Vector3(-100, 0, 0)); 
            //Später Animation einbauen
        }
    }
}
