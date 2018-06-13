using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupController : MonoBehaviour
{


    private GameManager gameManager;
    public GameObject canvas;

    private Text text;

    private string pickUpName;

    private void Start()
    {
        pickUpName = gameObject.name;
        Debug.Log(pickUpName);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.PickUp(pickUpName);
            canvas.gameObject.SetActive(true);
            text = canvas.gameObject.GetComponentInChildren<Text>();

            switch (pickUpName)
            {
                case "Boots":
                    text.text = "You obtained the Boots you may now use the Jump";
                    break;
                case "Gloves":
                    text.text = "You obtained the Gloves you can now grab and throw stuff";
                    break;
                case "Armor":
                    text.text = "You obtained the Armor you can now transform";
                    break;
                case "Helmet":
                    text.text = "You obtained the Helmet you may now use the magic powers";
                    break;
            }
            
            StartCoroutine(Wait());
        }
    }



    IEnumerator Wait()
    {
       
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);
        
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
