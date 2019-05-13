using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace Gamekit2D
{
    public class DirectorTrigger : MonoBehaviour
    {
        public enum TriggerType
        {
            Once, Everytime,
        }

        [Tooltip("This is the gameobject which will trigger the director to play.  For example, the player.")]
        /*public GameObject triggeringGameObject;*/
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
}