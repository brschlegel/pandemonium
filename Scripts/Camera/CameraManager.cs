using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private string levelName;
    private bool gameOver = false;

    private Vector3 position;
    private Quaternion rotation;

    public GameObject playerWinner;

    // Start is called before the first frame update
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        position = this.transform.position;
        rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Based on the mini-game, the camera will react differently.
    /// </summary>
    private void CameraMovement()
    {
        switch (levelName)
        {
            case "Soccer":
                // The camera luckily stays stationary during this mini-game.
                if (gameOver)
                {
                    ZoomOnWinner(playerWinner);
                }
                break;
            case "KingOfTheSinkingIsland":
                if (gameOver)
                {
                    ZoomOnWinner(playerWinner);
                }
                break;
            case "Shop":
                if (gameOver)
                {
                    ZoomOnWinner(playerWinner);
                }
                break;
            default:
                if (gameOver)
                {
                    ZoomOnWinner(playerWinner);
                }
                break;
        }
    }

    /// <summary>
    /// Whenever a player wins, we will zoom in on that player.
    /// </summary>
    private void ZoomOnWinner(GameObject winner)
    {
        position = new Vector3(winner.transform.position.x, this.transform.position.y, winner.transform.position.z);
        transform.LookAt(winner.transform);
    }
}
