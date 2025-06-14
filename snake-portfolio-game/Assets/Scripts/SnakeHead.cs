using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public bool live;
    public float timeStap;
    public float currentTimeStap;
    public Vector2 currentDirection;
    public Vector2 lastDirection;
    public Vector2 lastPosition;

    private SnakeTail snakeTail;
    private Food food;

    void Start()
    {
        live = true;
        currentTimeStap = 0.0f;
        currentDirection = Vector2.zero;
        lastDirection = Vector2.zero;

        snakeTail = GameObject.Find("SnakeTail").GetComponent<SnakeTail>();
        food = GameObject.Find("Food").GetComponent<Food>();
    }

    void Update()
    {
        Controllers();
        Movement();
    }

    public void Controllers()
    {
        if (!live) return;

        if (Input.GetKeyDown(KeyCode.W)) currentDirection = Vector2.up;
        if (Input.GetKeyDown(KeyCode.S)) currentDirection = Vector2.down;
        if (Input.GetKeyDown(KeyCode.A)) currentDirection = Vector2.left;
        if (Input.GetKeyDown(KeyCode.D)) currentDirection = Vector2.right;
    }

    public void Movement()
    {
        if (!live) return;

        currentTimeStap += Time.deltaTime;
        if (currentTimeStap < timeStap) return;

        currentTimeStap = 0;
        if (-currentDirection == lastDirection) currentDirection = lastDirection;
        lastDirection = currentDirection;
        lastPosition = (Vector2)transform.position;
        transform.position += (Vector3)currentDirection;

        snakeTail.Movement();
    }

    public void Eat()
    {
        snakeTail.Grow();
        food.SetNewPosition();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter in trigger area.");
        switch (collision.gameObject.tag)
        {
            case "Tail":
                live = false;
                break;

            case "Wall":
                live = false;
                break;

            case "Food":
                Eat();
                break;

            default:
                break;
        }
    }
}
