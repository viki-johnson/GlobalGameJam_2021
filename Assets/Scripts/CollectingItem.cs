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
    public GameObject holdingItem;
    public NewCustomer _newCustomer;
    
    
    private void Update() {
        if (Input.GetKeyDown("space"))
        {
            // for picking up items 
            if(_crate != null)
            {
                if(_crate.isFull && !holdingItem)
                {
                    // holding = _crate.contents;

                    holdingItem = _crate.itemModel;
                    holdingItem.transform.parent = this.transform;
                    holdingItem.transform.localPosition = new Vector3(0,0,0);

                    _crate.isFull = false;
                }
                else if(!_crate.isFull && holdingItem)
                {
                    // holding = "";

                    holdingItem.transform.parent = _crate.transform;
                    holdingItem.transform.localPosition = new Vector3(0,0,0);
                    holdingItem = null;

                    _crate.isFull = true;
                }
            }

            // for delivering
            if(atCounter && holdingItem)
            {

                if(_customer.item == holdingItem.name)
                {
                    Debug.Log("well done");
                    _score.rewards += 10;
                } else {
                    Debug.Log("fail");
                }
                holdingItem = null;
                _newCustomer.DeleteOld();
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
            // _customer = other.GetComponent<Customer>();
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
            atCounter = false;
        }
    }
}
