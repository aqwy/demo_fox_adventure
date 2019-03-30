using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckTargetable : MonoBehaviour
{
    public GameObject[] deathPrefabs;
    public GameObject polymorphInto;
    public AudioClip polymorphAudioClip;
    public GameObject interactionCanvas;

    public UnityEvent onTarget = new UnityEvent();
    public UnityEvent onUntarget = new UnityEvent();
    public UnityEvent onAttack = new UnityEvent();
    public UnityEvent onInteract = new UnityEvent();
    public IntUnityEvent onApply = new IntUnityEvent();

    public void Target()
    {
        onTarget.Invoke();
    }

    public void Untarget()
    {
        onUntarget.Invoke();
    }

    public void Attack()
    {
        onAttack.Invoke();     
    }

    public void Die()
    {
        foreach (var prefab in deathPrefabs)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    /*public void Polymorph()
    {
        if (!HaveWand()) return;
        var entity = GetComponent<QuestEntity>();
        MessageSystem.SendMessage(this, "Polymorph", ((entity != null) ? entity.entityType.name : name));
        AudioSource.PlayClipAtPoint(polymorphAudioClip, Camera.main.transform.position);
        Instantiate(polymorphInto, transform.position, transform.rotation);
        Die();
    }*/

    /*private bool HaveWand()
    {
        var demoInventory = FindObjectOfType<DemoInventory>();
        if (demoInventory == null) return false;
        return demoInventory.GetItemCount(DemoInventory.WandSlot) > 0;
    }*/

    public void PlayAudio(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
    }

    public void Interact()
    {
        onInteract.Invoke();
        if (interactionCanvas.activeSelf)
        {
            interactionCanvas.SetActive(false);
        }
    }

    public void Apply(int itemIndex)
    {
        onApply.Invoke(itemIndex);
    }

}
