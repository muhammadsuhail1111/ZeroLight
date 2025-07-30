using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Cardcontroller cd;
    public GameObject startGamePanel;
    public GameObject infoPanel;
    public GameObject LevelsPanel;
    // public GameObject settingsPanel;
    public void RestartGame()
    {
        // Logic to restart the game
        cd.gridLayoutGroup.enabled = true;

        for (int i = cd.gridtransform.childCount - 1; i >= 0; i--)
        {
            Destroy(cd.gridtransform.GetChild(i).gameObject);
        }
        cd.gameoverpanel.SetActive(false);
        cd.PrepareSprites();
        cd.InstantiateCards();
        cd.StartCoroutine(cd.Setgridlayout());
        cd.numberofturns = 5; // Reset turns
        Debug.Log("Game restarted!");
    }
    public void startGame()
    {

        startGamePanel.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void info()
    {
        infoPanel.SetActive(true);
    }
    public void backinfo()
    {
        infoPanel.SetActive(false);
    }
    public void StartBtn()
    {
        LevelsPanel.SetActive(true);
    }
    // public void settings()
    // {
    //     settingsPanel.SetActive(true);
    // }
    public void Beginner()
    {
        SceneManager.LoadScene(1);
    }
    public void Amateur()
    {
        SceneManager.LoadScene(2);
    }
    public void semipro()
    {
        SceneManager.LoadScene(3);
    }
    public void Pro()
    {
        SceneManager.LoadScene(4);
    }
    public void legend()
    {
        SceneManager.LoadScene(5);
    }
    public void LevelsPanelback()
    {
        LevelsPanel.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetProgress()
    {
        LockLevels.Instance.ResetProgress();
    }
}
