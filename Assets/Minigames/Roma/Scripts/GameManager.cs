using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject startButt, endButt, player, playerCube, pizzaOpen, pizzaClose;

    [SerializeField]
    TMP_Text scoreTxt;

    [SerializeField]
    private int score;

    [SerializeField]
    private Vector3 startPos, offset;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        startButt.SetActive(true);

        score = 0;
        scoreTxt.text = score.ToString();

    }

    public void SpawnBlock()
    {
        startPos += offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
