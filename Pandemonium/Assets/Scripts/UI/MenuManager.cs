using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void NextLevelButton(int index)
    {
        Application.LoadLevel(index);
    }
}
