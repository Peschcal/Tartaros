using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;

    private float speed = 10f;
    private float verticalVelocity;
    private float gravity = 30.0f;
    private float jumpForce = 15f;

    public DialogueManager dManager;


    private float climbingSpeed = 10;



    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(verticalVelocity);
        if (Input.GetButton("Horizontal"))
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0));
            Debug.Log("Horizontal");
        }
        if (Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") * speed));
            Debug.Log("Vertical");
        }

        //if (Input.GetButton("Jump"))
        //{
        //    Debug.Log("Jump");
        //}


        //if (Input.GetButton("Fire1"))
        //{
        //    Debug.Log("Fire1");
        //}

        // if (Input.GetButton("Transform"))
        // {
        //    Debug.Log("Transform");
        // }

        if (NPCController.inRange == true)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                dManager.DisplayNextSentence();
            }
        }

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = Vector3.zero;

        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical") * speed;

        controller.Move(moveVector * Time.deltaTime);





    }
}
