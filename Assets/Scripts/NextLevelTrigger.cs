using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private LevelManager _levelmanager;
    private void Start()
    {
        _levelmanager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerPlatformerController>())
        {
            _levelmanager.GoNextLevel();
        }
    }
}
