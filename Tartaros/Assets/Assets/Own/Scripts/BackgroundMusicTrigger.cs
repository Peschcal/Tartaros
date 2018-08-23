using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicTrigger : MonoBehaviour {

    public GameObject audio;

    private AudioSource aSource;

	// Use this for initialization
	void Start () {
        aSource = audio.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!aSource.isPlaying)
            {
                aSource.Play();

            }
        }
    }
}
