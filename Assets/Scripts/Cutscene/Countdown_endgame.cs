using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown_endgame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdown;

    private void OnEnable()
    {
        StartCoroutine(countdownTxt());
    }

    IEnumerator countdownTxt()
    {
        _countdown.text = "3";
        yield return new WaitForSeconds(1f);
        _countdown.text = "2";
        yield return new WaitForSeconds(1f);
        _countdown.text = "1";
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
