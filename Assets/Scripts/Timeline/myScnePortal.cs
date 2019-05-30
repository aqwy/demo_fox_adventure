using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

public class myScnePortal : MonoBehaviour
{
    [SerializeField] private ScenePortal _scenePortal;

    private void OnEnable()
    {
        _scenePortal.UsePortal();
    }
}
