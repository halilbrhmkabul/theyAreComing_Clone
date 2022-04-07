using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class scr_UiManager : MonoBehaviour
{
    public static scr_UiManager Instance;
    [SerializeField] GameObject levelStart;
    [SerializeField] GameObject levelRestart;
    [SerializeField] GameObject levelNext;
    [SerializeField] GameObject gameUI;

    //[SerializeField] TextMeshProUGUI moneyText;

    public bool GameActive;

    public List<GameObject> LevelPrefabs;
    int level;
    void Awake()
    {
        if(Instance==null)
            Instance = this;
        else
            Destroy(Instance);



        level = PlayerPrefs.GetInt("level");

        if (level<LevelPrefabs.Count)
        {
            Instantiate(LevelPrefabs[level]);
        }
        else
        {
            Instantiate(LevelPrefabs[Random.Range(0, LevelPrefabs.Count)]);
        }
        
    }
  
  

    public void StartLevel()
    {
        GameActive = true;
        levelStart.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        Debug.Log("StartLevel");
        scr_PlayerController.Instance.GameStart();
    }


    public void LoseGame()
    {
        //restart game
        Debug.Log("Lose Game");
        scr_PlayerController.Instance.PlayAnimation("Idle");
        scr_PlayerController.Instance.GameEnd();
        GameActive = false;
        levelRestart.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        // next level
        Debug.Log("Next Level");
        scr_PlayerController.Instance.PlayAnimation("Idle");
        GameActive = false;
        level++;
        PlayerPrefs.SetInt("level",level);
        levelNext.gameObject.SetActive(true);
    }

 
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}
