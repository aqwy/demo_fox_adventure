using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingMainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("StartMenuVariant2", LoadSceneMode.Single);
    }
}
