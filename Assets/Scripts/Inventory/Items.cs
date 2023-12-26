using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] items = new int[] { 0, 5, 10 };
    public bool[] hasItems = new bool[] { true, true, true };

    private int currItem = 0;
    public int defence = 0;

    public Sprite[] sprites;

    public void Equip(int index)
    {
        if (hasItems[index])
        {
            currItem = index;
            defence = items[currItem];
        }
    }

    public void AddItem(int index)
    {
        hasItems[index] = true;
    }
}
