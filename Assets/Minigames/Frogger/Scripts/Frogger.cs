using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Frogger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Sprite idleSprite;
    public Sprite leapSprite;
    public Sprite deadSprite;

    private Vector3 spawnPosition;
    private float farthestRow;
    private bool cooldown;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            Move(Vector3.down);
        }
    }

    private void Move(Vector3 direction)
    {
        if (cooldown) {
            return;
        }

        Vector3 destination = transform.position + direction;

        Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));
        Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));

        if (barrier != null) {
            return;
        }

        // death obstacle
        if (obstacle != null)
        {
            transform.position = destination;
            Death();
        }

        else
        {

            if (destination.y > farthestRow)
            {
                farthestRow = destination.y;
                FindObjectOfType<GameManager>().AdvancedRow();
            }

            // Start leap animation
            StopAllCoroutines();
            StartCoroutine(Leap(destination));
        }
    }

    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;

        float elapsed = 0f;
        float duration = 0.125f;


        spriteRenderer.sprite = leapSprite;
        cooldown = true;

        while (elapsed < duration)
        {
 
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }


        transform.position = destination;
        spriteRenderer.sprite = idleSprite;
        cooldown = false;
    }

    public void Respawn()
    {
        StopAllCoroutines();

        transform.rotation = Quaternion.identity;
        transform.position = spawnPosition;
        farthestRow = spawnPosition.y;

        spriteRenderer.sprite = idleSprite;

        gameObject.SetActive(true);
        enabled = true;
        cooldown = false;
    }

    public void Death()
    {

        StopAllCoroutines();
        enabled = false;

        transform.rotation = Quaternion.identity;
        spriteRenderer.sprite = deadSprite;

        FindObjectOfType<GameManager>().Died();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hitObstacle = other.gameObject.layer == LayerMask.NameToLayer("Obstacle");

        if (enabled && hitObstacle) {
            Death();
        }
    }

}
