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
       
        SceneManager.activeSceneChanged +=  SceneChange;
    }
    
    public void SceneChange(Scene current, Scene nxt){
        timer = GameObject.Find("Timer");
        currentScene = nxt.name;
        Transform im = transform.GetChild(1);
        foreach(Transform c in im){
            c.position = transform.position;
        }
        if(currentScene == "ShopPhase"){
            timer.GetComponent<ShopTimer>().endEvent.AddListener(LoadNextSceneEvent) ;
        }
        else if(timer != null){
            timer.GetComponent<Timer>().endEvent.AddListener(LoadNextSceneEvent) ;
            if(currentScene == "Soccer"){
                timer.GetComponent<Timer>().manager = transform.GetChild(0).gameObject;
            }
        }
    }
    private void Update()
    { 
    
    }

    //super hacky
    public void LoadNextSceneEvent(GameObject go){
        Debug.Log("called from event");
          LoadNextScene();
    }
    public void LoadNextScene()
    {
        int rand = Random.Range(0, 2);
        switch (currentScene)
        {
            case "Menu":
                StartCoroutine(LoadScene("PlayerJoin"));
                break;
            case "PlayerJoin":
                StartCoroutine(LoadScene("ShopPhase"));
                //if (rand == 0)
                //{
                //    StartCoroutine(LoadScene("Soccer"));
                //    globalStats.minigameCount += 1;
                //}
                //else
                //{
                //    StartCoroutine(LoadScene("KingOfTheHill"));
                //    globalStats.minigameCount += 1;
                //}
                break;
            case "ShopPhase":
                 rand = Random.Range(0, 2);
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
                      rand = Random.Range(0, 2);
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
                      rand = Random.Range(0, 2);
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
