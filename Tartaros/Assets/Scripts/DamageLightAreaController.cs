using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLightAreaController : MonoBehaviour {


    private GameManager gameManager;


    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player läuft drüber");
            if (!PlayerController.protectedAgainstLight)
            {
            gameManager.Dying();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          //  Debug.Log("Damage tick");
        }
    }
}
