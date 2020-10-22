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
    public Text text;
    public float transitionTime = 1f;

    public bool change = false;
    public string[] sceneNames = new string[3];
    string chosenScene;
    string currentScene;

    public void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        text.text = "This is scene " + currentScene + "\nPress the 1, 2, or 3 keys to change the current scene.\nScene transition demo.";
    }

    //public void LoadNextScene()
    //{
    //    StartCoroutine(LoadScene(chosenScene));
    //}

    IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void Scene1Change(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            print("scene1change");
            StartCoroutine(LoadScene(sceneNames[0]));
        }
    }

    public void Scene2Change(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            print("scene2change");
            StartCoroutine(LoadScene(sceneNames[1]));
        }
    }

    public void Scene3Change(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            print("scene3change");
            StartCoroutine(LoadScene(sceneNames[2]));
        }
    }
    
}
