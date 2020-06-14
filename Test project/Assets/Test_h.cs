using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_h : MonoBehaviour
{
    public Rigidbody2D rigid_body;
    private Vector3 targetpos;
    //private LineRenderer linerenderer;
    private void Start()
    {
        //linerenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
            //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段
            Vector3 direction = mouse - obj;
            //将Z轴置0,保持在2D平面内
            direction.z = 0f;
            //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1
            direction = direction.normalized;
            //transform.up = direction;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction);
            if (hit.collider.CompareTag("Wall") && hit.collider != null) //
            {
                Debug.Log(hit.collider.tag);
                targetpos = hit.point;
                //transform.up = direction;
                rigid_body.velocity = 25 * direction;
                
            }
        }
    }

}
