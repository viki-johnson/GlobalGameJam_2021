using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class NewCustomer : MonoBehaviour
{
    public string[] possibleItems;
    public GameObject[] itemModels;
    public Crate[] _crates;
    public Customer _customer;

    // Start is called before the first frame update
    void Start()
    {
        NewOrder();
    }

    public void NewOrder()
    {
        int choice = Random.Range(0, possibleItems.Length);
        _customer.item = possibleItems[choice];

        foreach(Crate c in _crates)
        {
            c.contents = possibleItems[Random.Range(0, possibleItems.Length)];
            c.isFull = true;
        }
        _crates[Random.Range(0, _crates.Length)].contents = possibleItems[choice];

        // set the models
        foreach(Crate c in _crates)
        {
            GameObject go = Instantiate(itemModels[System.Array.IndexOf(possibleItems, c.contents)], c.transform);
            go.name = c.contents;
            c.itemModel = go;

        }

    }

    public void DeleteOld()
    {
        foreach(Crate c in _crates)
        {
            Destroy(c.itemModel);
            c.contents = "";
        }
        NewOrder();
    }
}
