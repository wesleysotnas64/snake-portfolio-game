using UnityEngine;

public class Food : MonoBehaviour
{

    void Start()
    {
        SetNewPosition();
    }

    public void SetNewPosition()
    {
        int x = Random.Range(-11, 12);
        int y = Random.Range(-6, 7);

        transform.position = new Vector3(x, y, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tail":
                SetNewPosition();
                break;

            default:
                break;
        }
    }
}
