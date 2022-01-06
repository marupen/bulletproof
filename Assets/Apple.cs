using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    List<float> speed = new List<float>() { 50f, 200f, 400f };

    public int level = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreCounter.score == 1000 && level == 0)
        {
            level++;
        }
        else if (ScoreCounter.score == 6000 && level == 1)
        {
            level++;
        }

        // Простое перемещение
        Vector3 pos = transform.position;
        pos.y += -speed[level] * Time.deltaTime;
        transform.position = pos;

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Добавить очки за пойманное яблоко
            ScoreCounter.score += 100;
        }
    }
}
