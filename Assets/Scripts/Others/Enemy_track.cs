using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ⲿ�����ռ�
using Assets.Scripts.Character;

public class Enemy_track : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float hp = 100;

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

    void ZeroHP()
    {

    }

    /// <summary>
    /// ����ҽű����ã���������ֵ
    /// </summary>
    /// <param name="dmg"></param>
    public void damaged(float dmg)
    {
        hp -= dmg;
        if (hp < 0)
        {
            ZeroHP();
        }
    }
}
