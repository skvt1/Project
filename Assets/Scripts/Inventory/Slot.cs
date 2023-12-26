using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Sprite sprite; //������ ����� ��� ����� �����

    public Image icon; //������, ���� ����� ������������� ������
    public Image iconSlot;
    public void UpdateSlot(bool active) //���������� �����
    {
        if (active)
        {
            icon.sprite = sprite;
        }
        else
        {
            icon.sprite = iconSlot.sprite;
        }
    }
}
