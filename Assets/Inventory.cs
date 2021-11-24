using System;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    private IInventoryInput _input;

    private int _selected;

    private void Start()
    {
        _input = GetComponentInParent<IInventoryInput>();
    }

}