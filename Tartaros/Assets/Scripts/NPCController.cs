using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    // Use this for initialization

    public Dialogue dialogue;

    public static bool inRange = false;
    //bool conversationStarted = false;


    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		//if(inRange == true && conversationStarted == false)
  //      {
  //          if (Input.GetButtonDown("Fire3"))
  //          {
   //             conversationStarted = true;

        //    }
        //}
	}

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gespräch startet");
           inRange = true;
            TriggerDialogue();

        }
    }



    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            EndDialogue();
            inRange = false;
        }
    }

    public void TriggerDialogue()
    {
        
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    public void EndDialogue()
    {
        //conversationStarted = false;
        //inRange = false;
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
