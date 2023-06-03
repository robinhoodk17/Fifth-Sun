using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartianFootballPlayer : MonoBehaviour
{
    [HideInInspector] public bool playerMadeInput = false;
    public int playerController;
    public int playernumber;
    public GameObject SelectionCursor;
    public bool ShootorMove;
    public Vector3Int direction;
    public float inputTime;
    public float moveSpeedAnimation = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SelectionCursor.SetActive(false);
        
    }

    public void GetsSelected()
    {
        SelectionCursor.SetActive(true);
    }

    public void GetsDeselected()
    {
        SelectionCursor.SetActive(false);
    }
}
