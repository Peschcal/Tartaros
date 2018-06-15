using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingLight : MonoBehaviour
{

    Light light;

    public float speed;
    public float maxDist;
    public float minDist;

    GameObject player;

    NPCController npcController;


    public Animator animator;

    float range;
    // Use this for initialization
    void Start()
    {
        npcController = GetComponent<NPCController>();
        light = GetComponent<Light>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


        if ((Mathf.Sin(Time.time) * maxDist) > 0)
        {
            range = (Mathf.Sin(Time.time * speed) * maxDist);
        }
        else
        {
            range = -(Mathf.Sin(Time.time * speed) * maxDist);
        }
        //if (range > minDist)
        //{
        light.range = range;
        light.intensity = range / 3;
        //}
        //else
        //{
        //    light.range = minDist;
        //}
        
        if (transform.parent == null)
        {


            if (Vector3.Distance(player.transform.position, transform.position) < 1)
            {
                Debug.Log("parent");
                transform.parent = player.transform;
                transform.position = player.transform.position;
                npcController.TriggerDialogue();
                animator.SetBool("LightPickedUp", true);

            }
        }
    }

  
}
