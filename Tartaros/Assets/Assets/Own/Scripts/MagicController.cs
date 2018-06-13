using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MagicController : MonoBehaviour {


    public GameObject enemy;

    EnemyController eController;


    // Use this for initialization
    void Start () {
         eController = enemy.GetComponent<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            eController.HitByMagic();
        }
    }

    

}
