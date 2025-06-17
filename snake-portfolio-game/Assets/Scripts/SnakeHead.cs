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
    private SceneController sceneController;

    void Start()
    {
        Reset();

        snakeTail = GameObject.Find("SnakeTail").GetComponent<SnakeTail>();
        food = GameObject.Find("Food").GetComponent<Food>();
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
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
        sceneController.Scored();
    }

    public void Dead()
    {
        live = false;
        sceneController.GameOver();
    }

    public void Reset()
    {
        live = true;
        currentTimeStap = 0.0f;
        currentDirection = Vector2.zero;
        lastDirection = Vector2.zero;
        lastPosition = Vector2.zero;
        transform.position = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tail":
                Dead();
                break;

            case "Wall":
                Dead();
                break;

            case "Food":
                Eat();
                break;

            default:
                break;
        }
    }
}
