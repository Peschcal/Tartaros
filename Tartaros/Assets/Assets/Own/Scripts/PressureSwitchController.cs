using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitchController : MonoBehaviour
{


    public GameObject door;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Swiotch");
            door.SetActive(false);
        }
    }
}