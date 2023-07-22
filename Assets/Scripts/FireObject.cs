using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public float damage = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            // 몬스터 체력 감소 
            // 오브젝트 삭제
            Debug.Log("오브젝트 충돌 Monster");
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("오브젝트 충돌 Ground");
            Destroy(gameObject);
        }
    }
}
