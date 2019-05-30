using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;


public class Director : MonoBehaviour
{
    public enum TriggerType
    {
        Once, Everytime,
    }

    public PlayableDirector director;
    public TriggerType triggerType;
    public UnityEvent OnDirectorPlay;
    public UnityEvent OnDirectorFinish;
    [HideInInspector]
    protected bool m_AlreadyTriggered;

    void Start()
    {
        if (triggerType == TriggerType.Once && m_AlreadyTriggered)
            return;

        director.Play();
        m_AlreadyTriggered = true;
        OnDirectorPlay.Invoke();
        Invoke("FinishInvoke", (float)director.duration);
    }

    void FinishInvoke()
    {
        OnDirectorFinish.Invoke();
    }

}
