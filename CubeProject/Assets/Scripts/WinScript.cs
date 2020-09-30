using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

    private GetLevel GL;
    

    [SerializeField] private int Goal;
    public int curGoal;
    public int BspritesId;

    [SerializeField] private GameObject[] MainCubes;
    [SerializeField] private GameObject[] StartPosition;

    public int _curLVL;

    // Use this for initialization
    void Start()
    {
       
        GL = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GetLevel>();
        _curLVL = GL.LvlIndex;
    }

    // Update is called once per frame
    void Update() {

        if (curGoal == Goal)
        {
            GL.Level_array[_curLVL].SetActive(false);
            GL.Level_array[_curLVL + 1].SetActive(true);
            _curLVL++;
        }
    }

    public void Restart()
    {
        for (int i = 0; i < MainCubes.Length; i++)
        {
            MainCubes[i].transform.position = StartPosition[i].transform.position;
            MainCubes[i].GetComponent<MainCubeMoveScrpit>().myWaypointId = 0;
        }
    }
}
