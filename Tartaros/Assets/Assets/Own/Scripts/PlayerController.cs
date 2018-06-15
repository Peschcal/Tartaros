using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;

    private float speed = 15f;
    private float verticalVelocity;
    private float gravity = 30.0f;
    private float jumpForce = 15f;

    public DialogueManager dManager;


    private float climbingSpeedVert = 12;
    private float climbingSpeedHor = 8;

    public static bool bootsPickedUp = false;
    public static bool helmetPickedUp = false;
    public static bool glovesPickedUp = false;
    public static bool armorPickedUp = false;
    //public static bool bootsPickedUp = true;
    //public static bool helmetPickedUp = true;
    //public static bool glovesPickedUp = true;
    //public static bool armorPickedUp = true;


    public static bool protectedAgainstLight = false;

    public GameObject magicSpell;
    bool magicUsed = false;

    bool crouched = false;


    bool climbing = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!climbing)
        {
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

            if (controller.isGrounded)
            {
                verticalVelocity = -gravity * Time.deltaTime;

                if (Input.GetButtonDown("Jump") && bootsPickedUp)
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
        else
        {
            Vector3 moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal") * climbingSpeedHor;
            moveVector.y = Input.GetAxis("Vertical") * climbingSpeedVert;
            controller.Move(moveVector * Time.deltaTime);
        }
        //if (controller.isGrounded)
        //{
        //    moveDirection = transform.forward * Input.GetAxis("Vertical")*10f;
        //}


        //float turn = Input.GetAxis("Horizontal");
        //transform.Rotate(0, turn * 60f * Time.deltaTime, 0);
        //controller.Move(moveDirection * Time.deltaTime);

        if (NPCController.inRange == true)
        {
            if (Input.GetButtonDown("Grab"))
            {
                dManager.DisplayNextSentence();
            }
        }

        if (Input.GetButton("Magic") && helmetPickedUp)
        {

            UseMagic();
        }

        if (magicUsed)
        {
            magicSpell.transform.localScale += new Vector3(0.15F, 0.15f, 0);
            if (magicSpell.transform.localScale.magnitude >= 10)
            {
                EndMagic();
            }
        }


        if (Input.GetButtonDown("Grab") && glovesPickedUp)
        {
           // Debug.Log("Grab stuff");
        }

        if (Input.GetButtonDown("Transform") && armorPickedUp)
        {
            Debug.Log("Transform");
            protectedAgainstLight = true;
            StartCoroutine(Protected());

        }


        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("Crouch");
            if (!crouched)
            {
                transform.localScale = new Vector3(2, 1, 2f);
                controller.radius = 0.25f;
                crouched = true;
            }
            else
            {
                transform.localScale = new Vector3(2, 2, 2);
                controller.radius = 0.5f;
                crouched = false;
            }
        }


    }

    IEnumerator Protected()
    {
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("Transformation ends");
        protectedAgainstLight = false;

    }

    void UseMagic()
    {
        Debug.Log("Magic!!!!!!!!!!!!!!!!!!!!");

        magicSpell.SetActive(true);
        magicUsed = true;


    }

    void EndMagic()
    {
        magicUsed = false;
        magicSpell.transform.localScale = new Vector3(1, 1, 1);
        magicSpell.SetActive(false);

    }

    public void OnLadder(bool state)
    {
        if (state)
        {
            climbing = true;
        }
        else
        {
            climbing = false;
        }
    }





}
