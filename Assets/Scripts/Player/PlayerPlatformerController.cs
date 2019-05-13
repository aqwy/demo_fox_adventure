using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.QuestMachine;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float accelerationRun = 1.20f;
    public string interactButton = "F";

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool m_FacingRight;
    public List<CheckTargetable> m_targets = new List<CheckTargetable>();
    private bool _facingRight = true;
    private bool _dialog;
    private Vector2 _move;
    private QuestGiver _questGiver;
    private float _npcSpeed;

    // Use this for initialization
    void Awake()
    {
        _dialog = false;
        _move = Vector2.zero;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _questGiver = FindObjectOfType<QuestGiver>();
    }

    protected override void ComputeVelocity()
    {
        canMoving();

        /* if ((Input.GetAxis("Horizontal") != 0f || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
             && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
             return;*/

        if (Input.GetButtonDown(interactButton))
        {
            Debug.Log("Pressed F");
            Interact();
        }

        /*if (Input.GetButtonDown("Shift") && grounded)
        {
            velocity.x = velocity.x * accelerationRun;
        }*/

        if (Input.GetButtonDown("Jump") && grounded)
        {
            /*velocity.y = jumpTakeOffSpeed;*/
            _animator.SetTrigger("FoxGoesJump");
        }
        /*else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }*/

        /*bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }*/

        if (_move.x > 0 && m_FacingRight)
        {
            Flip();     // ... flip the player.
        }

        else if (_move.x < 0 && !m_FacingRight)
        {
            Flip();     // ... flip the player.
        }

        if (_animator)
        {
            _animator.SetBool("grounded", grounded);
            _animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        }

        targetVelocity = _move * maxSpeed;
    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void canMoving()
    {
        if (_questGiver)
        {
            if (_questGiver.questDialogueUI.isVisible)
            {
                _dialog = true;
            }
            else
            {
                _dialog = false;
            }
        }

        if (!_dialog)
        {
            _move.x = Input.GetAxis("Horizontal");
        }
        else
        {
            _move = Vector2.zero;
        }
    }
    private void Interact()
    {
        CleanTargetList();
        /*var inventory = FindObjectOfType<DemoInventory>();*/
        for (int i = 0; i < m_targets.Count; i++)
        {
            /*if (inventory.usingIndex != -1)
            {
                MessageSystem.SendMessageWithTarget(this, m_targets[i], "Use", "Wand");
            }
            else
            {*/
            m_targets[i].Interact();
            /* }*/
        }
    }
    private void CleanTargetList()
    {
        m_targets.RemoveAll(t => (t == null || !t.gameObject.activeInHierarchy));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var newTarget = collision.GetComponent<CheckTargetable>();
        if (newTarget == null) return;
        m_targets.Add(newTarget);
        newTarget.Target();

        GameObject movingNPC = collision.gameObject;
        if (movingNPC.GetComponent<MovingbetweenPoints>())
        {
            _npcSpeed = movingNPC.GetComponent<MovingbetweenPoints>().speed;
            movingNPC.GetComponent<MovingbetweenPoints>().speed = 0f;
            movingNPC.transform.Translate(Vector2.zero);
        }
        Debug.Log("detect qg");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var oldTarget = collision.GetComponent<CheckTargetable>();
        if (oldTarget == null) return;
        m_targets.Remove(oldTarget);
        oldTarget.Untarget();

        GameObject movingNPC = collision.gameObject;
        if (movingNPC.GetComponent<MovingbetweenPoints>())
        {
            movingNPC.GetComponent<MovingbetweenPoints>().speed = _npcSpeed;
        }
    }
}