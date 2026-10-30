using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI youWinText;

    private void OnEnable()
    {
        GameEvents.OnVictory += FinishGame;
    }

    private void OnDisable()
    {
        GameEvents.OnVictory -= FinishGame;
    }

    private void FinishGame()
    {
        youWinText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Start()
    {
        youWinText.gameObject.SetActive(false);
    }
}
