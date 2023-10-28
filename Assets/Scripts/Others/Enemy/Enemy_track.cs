using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ⲿ�����ռ�
using Assets.Scripts.Character;

public class Enemy_track : EnemyBase
{
    [SerializeField] float speed = 10;

    // TODO : ��ȡ��ҵ�Transform
    Transform pTrasfrom;

    #region �����߼�
    public override void damaged(int dmg)
    {
        base.damaged(dmg);
    }

    public override void die()
    {
        Debug.Log("��ɱ");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("������ң���ը");
            die();
        }
    }
    #endregion 

    new void Start()
    {
        base.Start();
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

        if (currentHP <= 0)
        {
            die();
        }

    }

    
}
