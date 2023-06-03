using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MartianFootballControls : MonoBehaviour
{
    private bool nextPlayerPressed;
    private bool previousPlayerPressed;
    private bool shotConfirmed;
    private bool movementConfirmed;
    private GameObject selectedPlayer;
    private List<GameObject> players = new List <GameObject>();
    private Tilemap map;
    [HideInInspector] public int inputNumber;
    [HideInInspector] public int numberOfFootballPlayers;

    private float timeBeforeNextSelection = .4f;
    private float lastSelection = 0f;
    private Vector2 inputDirection;
    private bool gamePaused = true;
    // Start is called before the first frame update
    void Start()
    {
        inputNumber = GetComponent<PlayerInput>().playerIndex;
        foreach(GameObject footballPlayer in GameObject.FindGameObjectsWithTag("FootballPlayer"))
        {
            players.Add(footballPlayer);
        }
        MartianFootballManager gameManager =  GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<MartianFootballManager>();
        gameManager.playerDestroyed += PlayerDestroyed;
        gameManager.gamePaused += pauseGame;
        gameManager.gameUnPaused += unPauseGame;
        int playerNumber = 0;
        numberOfFootballPlayers = 0;
        bool weSelectedPlayer = false;
        foreach(GameObject footballPlayer in players)
        {
            if(footballPlayer.GetComponent<MartianFootballPlayer>().playerController == inputNumber)
            {
                footballPlayer.GetComponent<MartianFootballPlayer>().playernumber = playerNumber;
                playerNumber++;
                numberOfFootballPlayers++;
                if(!weSelectedPlayer)
                {
                    selectedPlayer = footballPlayer;
                    footballPlayer.GetComponent<MartianFootballPlayer>().GetsSelected();
                    weSelectedPlayer = true;
                }
            }
        }

        map = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<MartianFootballManager>().map;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePaused) {return;}
        if(nextPlayerPressed)
        {
            SelectNextPlayer();
        }
        if(previousPlayerPressed && ! nextPlayerPressed)
        {
            SelectPreviousPlayer();
        }
        if(!(nextPlayerPressed || previousPlayerPressed))
        {
            if(movementConfirmed || shotConfirmed)
            {
                CheckDirection();
            }
        }
    }

    private void CheckDirection()
    {
        Vector3Int currentposition = GridPosition(selectedPlayer);
        Vector3Int newPosition = new Vector3Int(0,0,0);
        selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = true;
        #region checkdirectionofmovement
        if(inputDirection.x > .07f)
        {
            if(inputDirection.y > .07f)
            {
                if(currentposition.y % 2 == 0)
                {
                    newPosition = new Vector3Int(0,1,0);
                }
                else{ newPosition = new Vector3Int(1,1,0);}
            }
            else if(inputDirection.y < -.07f)
            {
                if(currentposition.y % 2 == 0)
                {
                    newPosition = new Vector3Int(-1,1,0);
                }
                else{ newPosition = new Vector3Int(0,1,0);}
            }
        }
        else if (inputDirection.x < -.07f)
        {
            if(inputDirection.y > .07f)
            {
                if(currentposition.y % 2 == 0)
                {
                    newPosition = new Vector3Int(0,-1,0);
                }
                else{ newPosition = new Vector3Int(1,-1,0);}
            }
            else if(inputDirection.y < -.07f)
            {
                if(currentposition.y % 2 == 0)
                {
                    newPosition = new Vector3Int(-1,-1,0);
                }
                else{ newPosition = new Vector3Int(0,-1,0);}
            }

        }
        else
        {
            if(inputDirection.y > .07f)
            {
                newPosition = new Vector3Int(1,0,0);
            }
            else if (inputDirection.y < -.07f)
            {
                newPosition = new Vector3Int(-1,0,0);
            }
            else
            {
                newPosition = new Vector3Int(0,0,0);;
            }

        }
        #endregion
        selectedPlayer.GetComponent<MartianFootballPlayer>().direction = newPosition;
        selectedPlayer.GetComponent<MartianFootballPlayer>().inputTime = Time.time;
        if(shotConfirmed)
        {
            selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = false;
            selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = false;
            int x = 0;
            int y = 0;
            if(inputDirection.x > .07f && inputDirection.y > .07f)
            {
                x = 1;
                y = 1;
                selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = true;
                selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = false;
            }
            if(inputDirection.x > .07f && inputDirection.y < -.07f)
            {
                x = 1;
                y = -1;
                selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = true;
                selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = false;

            }
            if(inputDirection.x < -.07f && inputDirection.y > .07f)
            {
                x = -1;
                y = 1;
                selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = true;
                selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = false;
            }
            if(inputDirection.x < -.07f && inputDirection.y < -.07f)
            {
                x = -1;
                y = -1;
                selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = true;
                selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = false;

            }
            if(inputDirection.y > .07f && inputDirection.x < .07f && inputDirection.x > -.07f)
            {
                x = 0;
                y = 1;
                selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = true;
                selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = false;
            }
            if(inputDirection.y < -.07f && inputDirection.x < .07f && inputDirection.x > -.07f)
            {
                x = 0;
                y = -1;
                selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = true;
                selectedPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput = false;
            }
            selectedPlayer.GetComponent<MartianFootballPlayer>().direction = new Vector3Int(x,y,0);

        }
        else
        {selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove = false;}
        Debug.Log(selectedPlayer.GetComponent<MartianFootballPlayer>().direction + "input: " + inputDirection + "shoot or move: " + selectedPlayer.GetComponent<MartianFootballPlayer>().ShootorMove);
    }
    public void onNextPlayer(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            nextPlayerPressed = true;
        }

        if(context.performed)
        {
            nextPlayerPressed = true;
        }

        if(context.canceled)
        {
            nextPlayerPressed = false;
            lastSelection = Time.time - timeBeforeNextSelection;
        }

    }

    public void onPreviousPlayer(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            previousPlayerPressed = true;
        }

        if(context.performed)
        {
            previousPlayerPressed = true;
        }

        if(context.canceled)
        {
            previousPlayerPressed = false;
            lastSelection = Time.time - timeBeforeNextSelection;
        }

    }

    public void ConfirmShot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            shotConfirmed = true;
        }

        if(context.performed)
        {
            shotConfirmed = true;
        }

        if(context.canceled)
        {
            shotConfirmed = false;
        }

    }

    public void ConfirmMovement(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            movementConfirmed = true;
        }

        if(context.performed)
        {
            movementConfirmed = true;
        }

        if(context.canceled)
        {
            movementConfirmed = false;
        }

    }


    private void SelectNextPlayer()
    {
        if(Time.time - lastSelection > timeBeforeNextSelection)
        {
            lastSelection = Time.time;
            int newselectedplayernumber;
            int selectedplayernumber = selectedPlayer.GetComponent<MartianFootballPlayer>().playernumber;
            selectedPlayer.GetComponent<MartianFootballPlayer>().GetsDeselected();
            if(selectedplayernumber >= numberOfFootballPlayers-1)
            {
                newselectedplayernumber = 0;
            }
            else
            {
                newselectedplayernumber = selectedplayernumber+1;
            }
            foreach(GameObject footballPlayer in players)
            {
                if(footballPlayer.GetComponent<MartianFootballPlayer>().playerController == inputNumber && footballPlayer.GetComponent<MartianFootballPlayer>().playernumber == newselectedplayernumber)
                {

                    selectedPlayer = footballPlayer;
                    selectedPlayer.GetComponent<MartianFootballPlayer>().GetsSelected();
                }
            }
        }
    }

    private void SelectPreviousPlayer()
    {
        if(Time.time - lastSelection > timeBeforeNextSelection)
        {
            lastSelection = Time.time;
            int newselectedplayernumber;
            int selectedplayernumber = selectedPlayer.GetComponent<MartianFootballPlayer>().playernumber;
            selectedPlayer.GetComponent<MartianFootballPlayer>().GetsDeselected();
            if(selectedplayernumber <= 0)
            {
                newselectedplayernumber = numberOfFootballPlayers-1;
            }
            else
            {
                newselectedplayernumber = selectedplayernumber-1;
            }
            foreach(GameObject footballPlayer in players)
            {
                if(footballPlayer.GetComponent<MartianFootballPlayer>().playerController == inputNumber && footballPlayer.GetComponent<MartianFootballPlayer>().playernumber == newselectedplayernumber)
                {

                    selectedPlayer = footballPlayer;
                    selectedPlayer.GetComponent<MartianFootballPlayer>().GetsSelected();
                }
            }
        }
    }

    private Vector3Int GridPosition(GameObject thisobject)
    {
        Vector3 position = thisobject.transform.position;
        Vector3Int gridposition = map.WorldToCell(position);
        return gridposition;
    }

    public void Direction(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    private void PlayerDestroyed(object sender, MartianFootballManager.EventHandlerArgsClass e)
    {
        players.Remove(e.objeto);
        Debug.Log("after destroying, we have this amount of players: " + players.Count);
        int playerNumber = 0;
        numberOfFootballPlayers = 0;
        bool weSelectedPlayer = false;
        foreach(GameObject footballPlayer in players)
        {
            if(footballPlayer.GetComponent<MartianFootballPlayer>().playerController == inputNumber)
            {
                footballPlayer.GetComponent<MartianFootballPlayer>().playernumber = playerNumber;
                playerNumber++;
                numberOfFootballPlayers++;
                if(!weSelectedPlayer)
                {
                    selectedPlayer = footballPlayer;
                    footballPlayer.GetComponent<MartianFootballPlayer>().GetsSelected();
                    weSelectedPlayer = true;
                }
            }
        }
    }

    private void pauseGame(object sender, MartianFootballManager.EventHandlerArgsClass e)
    {
        gamePaused = true;
    }

    private void unPauseGame(object sender, MartianFootballManager.EventHandlerArgsClass e)
    {
        gamePaused = false;
    }
}
