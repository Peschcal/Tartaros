using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{


    public Dialogue dialogue;
    public Transform[] destinations;

    private int nextDest = 0;

    private NavMeshAgent agent;
    public static bool inRange = false;
    //bool conversationStarted = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinations[nextDest].position);
    }


    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= 0.01f)
            {
                StartCoroutine(Resting());
                if (nextDest == destinations.Length - 1)
                {
                    nextDest = 0;
                }
                else
                {
                    nextDest++;
                }
                
                agent.destination = (destinations[nextDest].position);
            }
        }

    }

    IEnumerator Resting()
    {
        float restingTime = Random.Range(5f, 10f);
     //   Debug.Log("Resting Time: " + restingTime);
        agent.isStopped = true;
        yield return new WaitForSeconds(restingTime);
        agent.isStopped = false;
      //  Debug.Log("We just waited "+restingTime+" seconds");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Gespräch startet");
            inRange = true;
            agent.isStopped = true;
            TriggerDialogue();

        }
    }



    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            EndDialogue();
            inRange = false;
            agent.isStopped = false;
        }
    }

    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    public void EndDialogue()
    {

        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
