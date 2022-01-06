using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        // Координата Z камеры определяет, как далеко в трехмерном пространстве находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        // Преобразовать точку на двумерной плоскости экрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси X в координату X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        if (pos.x > 15)
        {
            pos.x = 15;
        }
        else if (pos.x < -15)
        {
            pos.x = -15;
        }
        this.transform.position = pos;
    }

    // OnCollisionEnter is called after collision with any gameObject
    void OnCollisionEnter(Collision coll)
    {
        // Получить ссылку на компонент ApplePicker главной камеры Main Camera
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        // Вызвать общедоступный метод AppleDestroyed() из apScript
        apScript.AppleDestroyed();
    }
}
