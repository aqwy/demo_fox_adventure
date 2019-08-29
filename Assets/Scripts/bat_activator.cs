using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_activator : MonoBehaviour
{
    public ParticleSystem bats;
    public AudioSource batsAudios;
    public AudioClip batsSound;

    private bool _soundPlayed;

    private void Start()
    {
        bats.gameObject.SetActive(false);
        _soundPlayed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.GetComponent<PlayerPlatformerController>())
        {
            bats.gameObject.SetActive(true);
            
            if (!bats.isPlaying)
            {              
                bats.Play();
                StartCoroutine(stopParticle());               
            }

            if (bats.isPlaying && !_soundPlayed)
            {
                batsAudios.PlayOneShot(batsSound);
                _soundPlayed = true;
            }
        }
    }

    IEnumerator stopParticle()
    {        
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
