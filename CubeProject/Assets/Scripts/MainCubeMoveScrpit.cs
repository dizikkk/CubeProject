using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCubeMoveScrpit : MonoBehaviour {

    public float moveSpeed = 5f;  
    public GameObject[] myWaypoints;

    private WinScript WS;
    private GetLevel GL;
    public GameObject Finish;
  

    public int myWaypointId = 0;
  
    bool mouse;

    void Start()
    {
        GL = GameObject.FindObjectOfType<GetLevel>();
        WS = GameObject.FindObjectOfType<WinScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && mouse)
        {
            if (myWaypointId < myWaypoints.Length)
                StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        if (myWaypointId < myWaypoints.Length)
        {
            if (myWaypoints.Length != 0)
            {
                do
                {
                    transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypointId].transform.position, moveSpeed * Time.deltaTime);
                    if (Vector3.Distance(myWaypoints[myWaypointId].transform.position, transform.position) <= 0f)
                    {
                        myWaypointId++;
                    }
                    yield return null;
                } while (Vector3.Distance(myWaypoints[myWaypointId].transform.position, transform.position) > 0f);
            }
        }
    }

    void OnMouseEnter()
    {
        mouse = true;
    }
    void OnMouseExit()
    {
        mouse = false;
    }

    IEnumerator RestartGame()
    {
        StopCoroutine("Move");
        GL.LoseText.SetActive(true);
        yield return new WaitForSeconds(1f);
        GL.LoseText.SetActive(false);
        WS.Restart();
        WS.curGoal = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject != Finish)
        {
            StartCoroutine("RestartGame");
        }
        else
        {
            WS.curGoal += 1;
            WS.BspritesId += 1;
        }
    }
}
