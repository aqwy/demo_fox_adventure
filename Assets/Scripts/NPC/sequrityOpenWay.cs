using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequrityOpenWay : MonoBehaviour
{
    public BoxCollider2D blockCollider;
    private void Start()
    {
        blockCollider = GetComponent<BoxCollider2D>();
        blockCollider.isTrigger = false;
    }
    public void checkQuestState()
    {
        string state = QuestLog.CurrentQuestState("2st_minigame_Quest");
        Debug.Log("2st_minigame_Quest:= " + state);

        if (state == "success")
        {
            blockCollider.isTrigger = true;
        }
    }
}
