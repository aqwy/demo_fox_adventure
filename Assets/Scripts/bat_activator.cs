using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_activator : MonoBehaviour
{
    public ParticleSystem bats;

    private void Start()
    {
        bats.gameObject.SetActive(false);
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
        }
    }

    IEnumerator stopParticle()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
