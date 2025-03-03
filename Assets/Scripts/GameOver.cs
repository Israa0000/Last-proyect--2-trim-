using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject panelGameOver;

    public void TurnPanelOn()
    {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
    }

    public void Restart()
    {
        Debug.Log("Restart");
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
