using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouse_Click : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigid_body;
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {

        if (Input.GetMouseButton(0))

        {

            Vector3 ms = Input.mousePosition;

            ms = Camera.main.ScreenToWorldPoint(ms);//获取鼠标相对位置

            //对象的位置

            Vector3 gunPos = this.transform.position;

            float fireangle;//发射角度

            //计算鼠标位置与对象位置之间的角度

            Vector2 targetDir = ms - gunPos;

            fireangle = Vector2.Angle(targetDir, Vector3.up);

            if (ms.x > gunPos.x)

            {

                fireangle = -fireangle;

            }

            rigid_body.velocity = 10*targetDir;
            //this.transform.eulerAngles = new Vector3(0, 0, fireangle);

        }

    }

}
