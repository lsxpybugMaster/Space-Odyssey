using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ʯ�ű������ڱ��������

public class Meteorite : MonoBehaviour
{
    [SerializeField]  float HP; //��������������С
    [SerializeField] float minHP; //��С����ֵ��С�ڴ���ʯ��ʧ
    float current_HP;

    Vector3 initScale; //�洢��ʼ��С
 
    void Start()
    {
        current_HP = HP;
        initScale = transform.localScale;
    }

    
    void Update()
    {
        //��������������С
        transform.localScale = (current_HP / HP) * initScale;
    }

    void DestoryMe()
    {

    }
    
    /// <summary>
    /// ����ҽű����ã���������ֵ
    /// </summary>
    /// <param name="dmg"></param>
    public void damaged(float dmg)
    {
        current_HP -= dmg;
        if(current_HP < minHP)
        {
            DestoryMe();
        }
    }
}
