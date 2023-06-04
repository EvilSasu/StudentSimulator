using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{

    public LevelLoaderScript loader;

    [SerializeField]
    GameObject tile, bottomTile, button;

    TMP_Text score;
    List<GameObject> stack;

    bool gameStart, gameEnd;

    public static Spawner instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<TMP_Text>();
        stack = new List<GameObject>();
        gameEnd = false;
        gameStart = false;
        stack.Add(bottomTile);
        //GetComponent<Renderer>().material.color = RandomColor();
        CreateTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnd || !gameStart) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (stack.Count > 1)
                stack[stack.Count - 1].GetComponent<Tile>().ScaleTile();
            if (gameEnd) return;
            StartCoroutine(MoveCamera());
            score.text = (stack.Count - 1).ToString();
            CreateTile();
        }
    }

    private Color RandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    IEnumerator MoveCamera()
    {
        float moveLength = 1.0f;
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        while (moveLength > 0)
        {
            float stepLength = 0.1f;
            moveLength -= stepLength;
            camera.transform.Translate(0, stepLength, 0, Space.World);
            yield return new WaitForSeconds(0.05f);
        }
    }

    void CreateTile()
    {
        GameObject previousTile = stack[stack.Count - 1];
        GameObject activeTile;

        activeTile = Instantiate(tile);
        stack.Add(activeTile);

        if (stack.Count > 2)
            activeTile.transform.localScale = previousTile.transform.localScale;

        activeTile.transform.position = new Vector3(previousTile.transform.position.x,
            previousTile.transform.position.y + previousTile.transform.localScale.y, previousTile.transform.position.z);

        activeTile.GetComponent<Renderer>().material.color = RandomColor();
        activeTile.GetComponent<Tile>().moveX = stack.Count % 2 == 0;
    }

    public void GameOver()
    {
        button.SetActive(true);
        gameEnd = true;
        StartCoroutine(EndCamera());
    }

    IEnumerator EndCamera()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 temp = camera.transform.position;
        Vector3 final = new Vector3(temp.x, temp.y - stack.Count * 0.5f, temp.z);
        float cameraSizeFinal = stack.Count * 0.65f;
        while (camera.GetComponent<Camera>().orthographicSize < cameraSizeFinal)
        {
            camera.GetComponent<Camera>().orthographicSize += 0.2f;
            temp = camera.transform.position;
            temp = Vector3.Lerp(temp, final, 0.2f);
            camera.transform.position = temp;
            yield return new WaitForSeconds(0.01f);
        }
        camera.transform.position = final;
    }

    public void StartButton()
    {
        if (gameEnd)
        {
            //Zmiana poziomu
            loader.LoadChoosenLevel(2);
        }
        else
        {
            button.SetActive(false);
            gameStart = true;
        }
    }
}