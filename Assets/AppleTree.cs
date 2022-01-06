using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // ������ ��� �������� �����
    public GameObject applePrefab;

    // �������� �������� ������
    List<float> speed = new List<float>() { 10f, 30f, 30f, 100f };

    // ����������, �� ������� ������ ���������� ����������� �������� ������
    public float leftAndRightEdge = 15f;

    // ����������� ���������� ��������� ����������� ��������
    List<float> chanceToChangeDirections = new List<float>() { 0.02f, 0.1f, 0.1f, 0.2f };

    // ������� �������� ����������� �����
    List<float> secondsBetweenAppleDrops = new List<float>() { 1f, 0.7f, 0.7f, 0.3f };

    // ����� ��������� ���� �� ���������� x
    public float xShift = 0.2f;

    // ����� ��������� ���� �� ���������� y
    public float yShift = -5.32f;

    public int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ���������� ������ ��� � �������
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        Vector3 pos = transform.position;
        pos.x += xShift;
        pos.y += yShift;
        apple.transform.position = pos;
        Invoke("DropApple", secondsBetweenAppleDrops[level]);
    }

    // Update is called once per frame
    void Update()
    {
        // ������� �����������
        Vector3 pos = transform.position;
        pos.x += speed[level] * Time.deltaTime;
        transform.position = pos;

        // ��������� �����������
        if (pos.x < -leftAndRightEdge)
        {
            speed[level] = Mathf.Abs(speed[level]);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed[level] = -Mathf.Abs(speed[level]);
        }
        if (ScoreCounter.score == 1000 && level == 0)
        {
            level++;
        }
        else if (ScoreCounter.score == 3000 && level == 1)
        {
            level++;
            GameObject tree = Instantiate<GameObject>(this.gameObject);
            Vector3 pos2 = transform.position;
            tree.transform.position = pos2;
        }
        else if (ScoreCounter.score == 6000 && level == 2)
        {
            level++;
        }
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        if (Random.value<chanceToChangeDirections[level] )
        {
            speed[level] *= -1; // Change direction
        }
    }
}
