using Assets.Scripts.Character.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ɱ����յ���Դ
public class Resources : MonoBehaviour, IAbsorb
{
    // ����Դ��energy
    [SerializeField] int energy;

    public int GetEnergy()
    {
        Debug.Log("��������");
        return energy;
    }    
}
