using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject wallBlock;
    public int setUp;
    void Start()
    {
        switch (setUp)
        {
            case 1:
                SetUp01();
                break;

            default:
                break;
        }
    }

    private void SetUp01()
    {
        GameObject wb = null;
        for (int i = -7; i < 8; i++)
        {
            for (int j = -12; j < 13; j++)
            {
                if (i == -7 || i == 7 || j == -12 || j == 12)
                {
                    wb = Instantiate(wallBlock);
                    wb.transform.position = new Vector3(j, i, 0.0f);
                    wb.transform.parent = transform;
                }
            }
        }
    }

}
