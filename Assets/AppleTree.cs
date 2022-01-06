using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Ўаблон дл€ создани€ €блок
    public GameObject applePrefab;

    // —корость движени€ €блони
    List<float> speed = new List<float>() { 10f, 30f, 30f, 100f };

    // –ассто€ние, на котором должно измен€тьс€ направление движени€ €блони
    public float leftAndRightEdge = 15f;

    // ¬еро€тность случайного изменени€ направлени€ движени€
    List<float> chanceToChangeDirections = new List<float>() { 0.02f, 0.1f, 0.1f, 0.2f };

    // „астота создани€ экземпл€ров €блок
    List<float> secondsBetweenAppleDrops = new List<float>() { 1f, 0.7f, 0.7f, 0.3f };

    // —двиг генерации пули по координате x
    public float xShift = 0.2f;

    // —двиг генерации пули по координате y
    public float yShift = -5.32f;

    public int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        // —брасывать €блоки раз в секунду
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
        // ѕростое перемещение
        Vector3 pos = transform.position;
        pos.x += speed[level] * Time.deltaTime;
        transform.position = pos;

        // »зменение направлени€
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
