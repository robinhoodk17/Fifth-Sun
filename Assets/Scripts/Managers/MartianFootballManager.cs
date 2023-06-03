using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using TMPro;

public class MartianFootballManager : MonoBehaviour
{
    [SerializeField] private GameObject LaserShot;
    [SerializeField] private TextMeshProUGUI countdownTextBox;
    public Tilemap map;
    public GameObject UICountDown;
    private int playersJoined = 0;
    private int numberOfFootballPlayers ;
    public Camera _mainCamera;
    bool moving = false;
    int movingPlayerInt = 0;
    int shootingPlayerInt = 0;
    Dictionary<float, (GameObject,Vector3Int)> inputTimeDictionary = new Dictionary<float,(GameObject,Vector3Int)>();
    List<float> inputTimeList = new List<float>();
    float waitingtime = 10f;
    bool shotAnimation = false;
    float laserShotSpeed = 1f;
    GameObject laserShotInstance;
    public event EventHandler<EventHandlerArgsClass> playerDestroyed;
    public event EventHandler<EventHandlerArgsClass> gamePaused;
    public event EventHandler<EventHandlerArgsClass> gameUnPaused;
    private List<GameObject> destroyedPlayers = new List<GameObject>();

    public class EventHandlerArgsClass : EventArgs
    {
        public GameObject objeto;
    }
    // Start is called before the first frame update
    void Start()
    {
        numberOfFootballPlayers = GameObject.FindGameObjectsWithTag("FootballPlayer").Length;
    }
    private void FixedUpdate()
    {
        if(shootingPlayerInt >= numberOfFootballPlayers)
        {
            TurnFinish();
        }
        if(moving)
        {
            GameObject currentlyMovingPlayer = inputTimeDictionary[inputTimeList[movingPlayerInt]].Item1;
            Vector3Int targetposition = inputTimeDictionary[inputTimeList[movingPlayerInt]].Item2;
            Move(targetposition, currentlyMovingPlayer);
        }
        if(movingPlayerInt >= numberOfFootballPlayers)
        {
            moving = false;
            GameObject currentlyMovingPlayer = inputTimeDictionary[inputTimeList[shootingPlayerInt]].Item1;
            Vector3Int targetposition = inputTimeDictionary[inputTimeList[shootingPlayerInt]].Item2;
            Shoot(targetposition, currentlyMovingPlayer);
        }
        
    }

    public IEnumerator turnStart()
    {
        countdownTextBox.text = "Ready?";
        float countdownInterval = NextFloat(.1f,.8f);
        yield return new WaitForSeconds(2f);
        countdownTextBox.text = "3";
        yield return new WaitForSeconds(countdownInterval);
        countdownTextBox.text = "2";
        yield return new WaitForSeconds(countdownInterval);
        countdownTextBox.text = "1";
        yield return new WaitForSeconds(countdownInterval);
        countdownTextBox.text = "GO!";
        UICountDown.SetActive(true);
        gameUnPaused?.Invoke(this, new EventHandlerArgsClass {objeto = null});
        UICountDown.GetComponent<Animator>().Play("CountDownAnima");
        yield return new WaitForSeconds(waitingtime);
        UICountDown.SetActive(false);
        gamePaused?.Invoke(this, new EventHandlerArgsClass {objeto = null});
        Movements();
    }

    public IEnumerator rotateTextCountdown (float waitSeconds, string textInBox)
    {
        yield return new WaitForSeconds(waitingtime);
        countdownTextBox.text = textInBox;
    }

    public void TurnFinish()
    {
        moving = false;
        movingPlayerInt = 0;
        shootingPlayerInt = 0;
        GameObject[] players = GameObject.FindGameObjectsWithTag("FootballPlayer");
        inputTimeList.Clear();
        inputTimeDictionary.Clear();

        foreach(GameObject footballPlayer in players)
        {
            MartianFootballPlayer thisFootballPlayer = footballPlayer.GetComponent<MartianFootballPlayer>();
            thisFootballPlayer.direction = new Vector3Int(0,0,0);
            thisFootballPlayer.ShootorMove = false;
            thisFootballPlayer.playerMadeInput = false;
        }
        StartCoroutine(turnStart());
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        if(pi.playerIndex > 0)
        {
            StartCoroutine(turnStart());
        }
        Debug.Log(pi.playerIndex);
    }

    public void Movements()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("FootballPlayer");
        numberOfFootballPlayers = players.Length;
        foreach(GameObject footballPlayer in players)
        {
            MartianFootballPlayer thisFootballPlayer = footballPlayer.GetComponent<MartianFootballPlayer>();
            inputTimeList.Add(thisFootballPlayer.inputTime);
            Vector3Int targetPosition;
            if(thisFootballPlayer.GetComponent<MartianFootballPlayer>().ShootorMove)
            {
                targetPosition = thisFootballPlayer.GetComponent<MartianFootballPlayer>().direction;
            }
            else
            {
                targetPosition = map.WorldToCell(thisFootballPlayer.transform.position) + thisFootballPlayer.GetComponent<MartianFootballPlayer>().direction;
            }
            inputTimeDictionary[thisFootballPlayer.inputTime] = (footballPlayer, targetPosition);
        }
        inputTimeList.Sort((a,b) => a.CompareTo(b));
        movingPlayerInt = 0;
        moving = true;
    }

    private GameObject cellHasPlayer(Vector3Int position)
    {
        Vector3 target = Camera.main.WorldToScreenPoint(map.GetCellCenterWorld(position));        
        var ray = Camera.main.ScreenPointToRay(target);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform.gameObject;
            return selection;
        }
        else
        {
            return null;
        }
    }

    private void Move(Vector3Int finalPosition, GameObject footballPlayer)
    {
        if(footballPlayer.GetComponent<MartianFootballPlayer>().playerMadeInput && (cellHasPlayer(finalPosition) == footballPlayer || cellHasPlayer(finalPosition) == null) && !footballPlayer.GetComponent<MartianFootballPlayer>().ShootorMove)
        {
            Vector3 startposition = footballPlayer.transform.position;
            float moveSpeedAnimation = footballPlayer.GetComponent<MartianFootballPlayer>().moveSpeedAnimation;
            Vector3 target = map.GetCellCenterLocal(finalPosition);
            if(Vector3.Distance(startposition, target) <= .11f)
            {
                footballPlayer.transform.position = target;
                movingPlayerInt++;
            }
            else
            {
                
                Vector3 heading = target - startposition;
                heading.Normalize();
                Vector3 velocity = heading * moveSpeedAnimation;
                footballPlayer.transform.forward = heading;
                footballPlayer.transform.SetPositionAndRotation(footballPlayer.transform.position + velocity * Time.fixedDeltaTime, Quaternion.identity);
            }
        }
        else
        {
            movingPlayerInt++;
        }
    }

    private void Shoot(Vector3Int shootDirection, GameObject footballPlayer)
    {
        Debug.Log(shootingPlayerInt);
        if(destroyedPlayers.Contains(footballPlayer))
        {
            shootingPlayerInt++;
            return;
        }
        if(footballPlayer.GetComponent<MartianFootballPlayer>().ShootorMove)
        {
            if(!shotAnimation)
            {
                laserShotInstance = Instantiate(LaserShot, footballPlayer.transform.position + new Vector3(0,0,-1), Quaternion.identity);
                shotAnimation = true;
            }
            else
            {
                Vector3Int currentposition = map.WorldToCell(laserShotInstance.transform.position);
                Vector3Int targetPosition = new Vector3Int(0,0,0);
                #region CalculateTargetPosition
                if(shootDirection.x >0)
                {
                    if(shootDirection.y >0)
                    {
                        if(currentposition.y % 2 == 0)
                        {
                            targetPosition = currentposition + new Vector3Int(0,1,0);
                        }
                        else{ targetPosition = currentposition + new Vector3Int(1,1,0);}
                    }
                    else if(shootDirection.y < 0)
                    {
                        if(currentposition.y % 2 == 0)
                        {
                            targetPosition = currentposition + new Vector3Int(-1,1,0);
                        }
                        else{ targetPosition = currentposition + new Vector3Int(0,1,0);}
                    }
                }
                else if (shootDirection.x < 0)
                {
                    if(shootDirection.y > .0)
                    {
                        if(currentposition.y % 2 == 0)
                        {
                            targetPosition = currentposition + new Vector3Int(0,-1,0);
                        }
                        else{ targetPosition = currentposition + new Vector3Int(1,-1,0);}
                    }
                    else if(shootDirection.y < 0)
                    {
                        if(currentposition.y % 2 == 0)
                        {
                            targetPosition = currentposition + new Vector3Int(-1,-1,0);
                        }
                        else{ targetPosition = currentposition + new Vector3Int(0,-1,0);}
                    }

                }
                else
                {
                    if(shootDirection.y > 0)
                    {
                        targetPosition = currentposition +  new Vector3Int(1,0,0);
                    }
                    else if (shootDirection.y < 0)
                    {
                        targetPosition = currentposition +  new Vector3Int(-1,0,0);
                    }
                }
                #endregion
                Vector3 targetPositionInWorld = map.GetCellCenterWorld(targetPosition);
                Vector3 currentCellCenterInWorld = map.GetCellCenterWorld(map.WorldToCell(laserShotInstance.transform.position));
                if(Vector3.Distance(laserShotInstance.transform.position, currentCellCenterInWorld) <= .11f)
                {
                    if((cellHasPlayer(currentposition + new Vector3Int(0,0,1)) != null && cellHasPlayer(currentposition + new Vector3Int(0,0,1))!= footballPlayer) || !map.HasTile(currentposition + new Vector3Int(0,0,1)))
                    {
                        playerGetsShot(cellHasPlayer(currentposition + new Vector3Int(0,0,1)));
                        Destroy(laserShotInstance);
                        shotAnimation = false;
                        shootingPlayerInt++;
                    }
                    else
                    {
                        Vector3 heading = targetPositionInWorld - laserShotInstance.transform.position;
                        heading.Normalize();
                        Vector3 velocity = heading * laserShotSpeed;
                        laserShotInstance.transform.forward = heading;
                        laserShotInstance.transform.SetPositionAndRotation(laserShotInstance.transform.position + velocity * Time.fixedDeltaTime, Quaternion.identity);
                    }
                }
                else
                {
                    Vector3 heading = targetPositionInWorld - laserShotInstance.transform.position;
                    heading.Normalize();
                    Vector3 velocity = heading * laserShotSpeed;
                    laserShotInstance.transform.forward = heading;
                    laserShotInstance.transform.SetPositionAndRotation(laserShotInstance.transform.position + velocity * Time.fixedDeltaTime, Quaternion.identity);
                }
            }

        }
        else
        {
            shootingPlayerInt++;
        }
    }

    private void playerGetsShot(GameObject footballPlayer)
    {
        foreach(GameObject jugadorDeFutbol in GameObject.FindGameObjectsWithTag("FootballPlayer"))
        {
            jugadorDeFutbol.GetComponent<MartianFootballPlayer>().GetsDeselected();
        }
        destroyedPlayers.Add(footballPlayer);
        Destroy(footballPlayer);
        playerDestroyed?.Invoke(this, new EventHandlerArgsClass {objeto = footballPlayer});
    }

    static float NextFloat(float min, float max){
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }
}
