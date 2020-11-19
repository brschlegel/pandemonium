using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    // This is the object that we will be carrying from scene to scene that will hold the information for each player.
    public static GlobalStats instance;

    public List<PlayerInfo> playerStats = new List<PlayerInfo>();

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    // At start, load data from previous scene.
    private void Start()
    {
        playerStats = GlobalStats.instance.playerStats;
    }

    // When changing scene, save data from scene.
    public void SavePlayerInfo()
    {
        GlobalStats.instance.playerStats = playerStats;
    }
}
