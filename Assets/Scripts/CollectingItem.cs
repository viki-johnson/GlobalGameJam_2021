using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingItem : MonoBehaviour
{
    public Crate _crate;
    public Customer _customer;
    public string holding;
    public bool atCounter;
    public Score _score;
    
    
    private void Update() {
        if (Input.GetKeyDown("space"))
        {
            // for picking up items 
            if(_crate != null)
            {
                if(_crate.isFull && holding == "")
                {
                    holding = _crate.contents;
                    _crate.isFull = false;
                }
                else if(!_crate.isFull && holding != "")
                {
                    holding = "";
                    _crate.isFull = true;
                }
            }

            // for delivering
            if(atCounter && holding != "")
            {
                if(_customer.item == holding)
                {
                    Debug.Log("well done");
                    _score.rewards += 10;
                } else {
                    Debug.Log("fail");
                }
                holding = "";
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // for picking up items 
        _crate = other.GetComponent<Crate>();
        if(_crate != null && _crate.isFull)
        {
            Debug.Log("hit " + _crate.contents);
            _crate.isActive = true;
        }

        // for delivering items
        if(other.GetComponent<Customer>() == true)
        {
            atCounter = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        // for picking up items 

        if(_crate != null && _crate.isFull)
        {
            Debug.Log("left " + _crate.contents);
            _crate.isActive = false;
        }


        // for delivering items
        if(other.GetComponent<Customer>() == true)
        {
            _customer = other.GetComponent<Customer>();
            atCounter = false;
        }
    }
}
