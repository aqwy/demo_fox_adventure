using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_npc : MonoBehaviour
{
    public float speed = 2.0f;
    public SpriteRenderer sprite;
    public Transform maxRight;
    public Transform maxLeft;

    private Animator _anim;
    private bool _dirRight = true;
    private bool _moving = true;
    private float _walkCounter;
    private int _walkID;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _walkCounter = Random.Range(3f, 6f);
        _walkID = Animator.StringToHash("isWalking");
    }
    void Update()
    {
        checkDir();
    }

    private void checkDir()
    {
        if (_moving)
        {
            _anim.SetBool(_walkID, true);
            _walkCounter -= Time.deltaTime;

            if (_dirRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                if (transform.position.x >= maxRight.transform.position.x)
                {
                    sprite.flipX = true;
                    _dirRight = false;
                    Debug.Log("flip " + sprite.flipX);
                }
            }
            else
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
                if (transform.position.x <= maxLeft.transform.position.x)
                {
                    sprite.flipX = false;
                    _dirRight = true;
                    Debug.Log("flip " + sprite.flipX);
                }
            }

            if (_walkCounter < 0f)
            {
                stopMoving();
            }
        }
        else 
        {
            continueMoving();
        }
    }
    private void stopMoving()
    {
        _moving = false;
        _walkCounter = Random.Range(3f, 6f);
        _anim.SetBool(_walkID, false);
    }
    private void continueMoving()
    {
        StartCoroutine(waiting());
    }
    private IEnumerator waiting()
    {
        float waitCount = Random.Range(2f, 4f);
        yield return new WaitForSeconds(waitCount);

        _moving = true;
    }
    private void randomDir()
    {
        int changeDir = Random.Range(0, 1);
        if (changeDir > 0)
        {
            _dirRight = true;
            sprite.flipX = true;
        }
        else
        {
            _dirRight = false;
            sprite.flipX = false;
        }
    }  
}
