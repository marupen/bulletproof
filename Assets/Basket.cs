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
        // �������� ������� ���������� ��������� ���� �� ������ �� Input
        Vector3 mousePos2D = Input.mousePosition;

        // ���������� Z ������ ����������, ��� ������ � ���������� ������������ ��������� ��������� ����
        mousePos2D.z = -Camera.main.transform.position.z;

        // ������������� ����� �� ��������� ��������� ������ � ���������� ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // ����������� ������� ����� ��� X � ���������� X ��������� ����
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
        // �������� ������ �� ��������� ApplePicker ������� ������ Main Camera
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        // ������� ������������� ����� AppleDestroyed() �� apScript
        apScript.AppleDestroyed();
    }
}
