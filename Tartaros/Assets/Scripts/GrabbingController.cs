using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingController : MonoBehaviour
{

    public GameObject player;

    PlayerController pController;

    bool playerInRange = false;


    void Start()
    {
        pController = player.GetComponent<PlayerController>();
    }

    void Update()
    {

        if (playerInRange && Input.GetButton("Grab") && PlayerController.glovesPickedUp)
        {
            //Debug.Log("Grabbing");
           

            Vector3 toTarget = (player.transform.position - transform.position).normalized;

            //Debug.Log(toTarget);
            //if (Vector3.Dot(toTarget, transform.forward) > 0)
            //{

            if (Mathf.Abs(toTarget.x) > 0.8)
            {
              
                //seitlich von der Box
                transform.position += new Vector3(Input.GetAxis("Horizontal"),0,0);
            }
            else
            {
                //vor oder hinter der Box
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            playerInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

        }
    }
}
