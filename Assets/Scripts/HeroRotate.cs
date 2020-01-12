using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRotate : MonoBehaviour
{
    public float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        //var mousePosition = Input.mousePosition;
        //mousePosition.z = transform.position.z - Camera.main.transform.position.z; // это только для перспективной камеры необходимо
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты
        //var angle = Vector3.Angle(Vector3.right, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
        ////transform.eulerAngles = new Vector3(0f, transform.position.y < mousePosition.y ? angle : -angle, 0f);//немного магии на последок
        //transform.rotation = Quaternion.Euler(0f, angle, 0f);



        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Debug.Log(mousePosition.ToString());

        // Тот самый поворот
        // вычисляем разницу между текущим положением и положением мыши
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        // вычисляемый необходимый угол поворота
        float rotation_y = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        // Применяем поворот вокруг оси Z
        transform.rotation = Quaternion.Euler(0f, rotation_y, 0f);
    }
}
