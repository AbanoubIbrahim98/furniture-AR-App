using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item1", menuName = "AddItem/item")]
public class item : ScriptableObject
{
    public float price;
    public GameObject itemPrefab;
    public Sprite itemImage;
}
