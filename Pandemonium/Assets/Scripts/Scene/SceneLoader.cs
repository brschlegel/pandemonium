using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Programmer: Durrell Bedassie 2020
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public bool change = false;
    string currentScene;

    public GameScoresManager scoreManager;
    public GlobalStats globalStats;
    public GameObject timer;

    public void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (timer.GetComponent<Timer>().timeRemaining == 0)
        {
            print("called load next scene");
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        switch (currentScene)
        {
            case "Menu":
                StartCoroutine(LoadScene("PlayerJoin"));
                break;
            case "PlayerJoin":
                StartCoroutine(LoadScene("ShopPhase"));
                break;
            case "ShopPhase":
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    StartCoroutine(LoadScene("Soccer"));
                    globalStats.minigameCount += 1;
                }
                else
                {
                    StartCoroutine(LoadScene("KingOfTheHill"));
                    globalStats.minigameCount += 1;
                }
                break;
            case "Soccer":
                if (globalStats.minigameCount == 4)
                {
                    StartCoroutine(LoadScene("End"));
                }
                else
                {
                    StartCoroutine(LoadScene("ShopPhase"));
                }
                break;
            case "KingOfTheHill":
                if (globalStats.minigameCount == 4)
                {
                    StartCoroutine(LoadScene("End"));
                }
                else
                {
                    StartCoroutine(LoadScene("ShopPhase"));
                }
                break;
            default:
                break;
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
