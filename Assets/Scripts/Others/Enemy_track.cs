using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ⲿ�����ռ�
using Assets.Scripts.Character;

public class Enemy_track : MonoBehaviour
{
    [SerializeField] float speed = 10;

    // TODO : ��ȡ��ҵ�Transform
    Transform pTrasfrom;

    void Start()
    {
        pTrasfrom = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        //�ı�λ�ý���׷��
        if (pTrasfrom)
        {
            transform.up = pTrasfrom.position - transform.position;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("�Ҳ�����ң��������");
        }
        
    }
}
