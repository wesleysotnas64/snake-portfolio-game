using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public GameObject blockTail;
    private List<GameObject> tail;
    private SnakeHead snakeHead;
    void Start()
    {
        tail = new List<GameObject>();
        snakeHead = GameObject.Find("SnakeHead").GetComponent<SnakeHead>();
    }

    public void Grow()
    {
        GameObject bt = Instantiate(blockTail);
        bt.transform.parent = transform;
        tail.Add(bt);
    }

    public void Movement()
    {
        if (tail.Count > 0)
        {
            GameObject auxBlockTail = tail[0];
            tail.RemoveAt(0);
            tail.Add(auxBlockTail);
            tail.Last().transform.position = snakeHead.lastPosition;
        }
    }
    
}
