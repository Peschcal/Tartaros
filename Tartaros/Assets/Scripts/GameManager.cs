using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Animator animator;


    void Start()
    {

    }


    void Update()
    {

    }


    public void Dying()
    {
        Debug.Log("died");
        //animator.SetBool("IsDead", true);

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dying"))
        //{
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       // }

    }


    public void PickUp (string item)
    {
        switch (item)
        {
            case "Boots":
                Debug.Log("Picked up boots, yeah!");
                PlayerController.bootsPickedUp = true;
                break;
            case "Gloves":
                Debug.Log("Picked up the Gloves, yeah!");
                PlayerController.glovesPickedUp = true;
                break;
            case "Armor":
                PlayerController.armorPickedUp = true;
                Debug.Log("Picked up the Armor, yeah!");
                break;
            case "Helmet":
                Debug.Log("Picked up the helmet, yeah!");
                PlayerController.helmetPickedUp = true;
                break;
            default:
                Debug.Log("Not implemented yet");
                break;
                
        }
    }


}
