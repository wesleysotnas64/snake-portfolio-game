using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public float timeStap;
    public float currentTimeStap;
    public Vector2 currentDirection;
    public Vector2 lastDirection;

    void Start()
    {
        currentTimeStap = 0.0f;
        currentDirection = Vector2.zero;
        lastDirection = Vector2.zero;
    }

    void Update()
    {
        Controllers();
        Movement();
    }

    public void Controllers()
    {
        if (Input.GetKeyDown(KeyCode.W)) currentDirection = Vector2.up;
        if (Input.GetKeyDown(KeyCode.S)) currentDirection = Vector2.down;
        if (Input.GetKeyDown(KeyCode.A)) currentDirection = Vector2.left;
        if (Input.GetKeyDown(KeyCode.D)) currentDirection = Vector2.right;
    }

    public void Movement()
    {
        currentTimeStap += Time.deltaTime;
        if (currentTimeStap < timeStap) return;

        currentTimeStap = 0;
        if (-currentDirection == lastDirection) currentDirection = lastDirection;
        lastDirection = currentDirection;
        transform.position += (Vector3) currentDirection;
    }
}
