using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public bool isFull, isActive;
    public string contents;
    [TextArea(5,10)] public string description;
    public Material full, empty, active;
    public MeshRenderer mesh;
    public GameObject itemModel;

    private void Update() {
        if(isFull)
        {
            if(isActive)
            {
                mesh.material = active;
            } else {
                mesh.material = full;
            }
            // itemModel.SetActive(true);
        } else {
            mesh.material = empty;
            // itemModel.SetActive(false);
        }
    }

    public void Empty()
    {
        contents = description = "";
        isFull = false;
    }
}
