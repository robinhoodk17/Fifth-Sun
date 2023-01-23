using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    [HideInInspector]
    public int pilot = 0;
    [HideInInspector]
    public int gunner = 0;
    [HideInInspector]
    public Dictionary<int, bool> playerReady = new Dictionary<int, bool>();
    [HideInInspector]
    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Singleton - trying to create another instance of singleton!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("player joined" + pi.playerIndex);
        playerReady[pi.playerIndex] = false;
    }

    public void TryToLoadGame()
    {
        foreach(int player in playerReady.Keys)
        {
            if (!playerReady[player])
            {
                return;
            }
            Debug.Log(player);
        }
        
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("PlayerAssign"))
        {
            player.GetComponent<Allcontrols>().LoadedTrack = true;
            player.GetComponent<Allcontrols>().SelectionPhase = false;
            player.GetComponent<Allcontrols>().isInsideBox = false;
            player.GetComponent<PlayerInput>().actions.FindActionMap("PlayerSelect").Disable();

        }
        SceneManager.LoadScene(1);
        

    }
}
