using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevel : MonoBehaviour
{

    [SerializeField] public GameObject[] Level_array;
    public int LvlIndex;
    public GameObject LoseText;
    // Start is called before the first frame update
    void Start()
    {
        Level_array[LvlIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitLevel()
    {

    }
}
