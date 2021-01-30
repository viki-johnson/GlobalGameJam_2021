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

    private void Update() {
        if(isFull)
        {
            if(isActive)
            {
                mesh.material = active;
            } else {
                mesh.material = full;
            }
        } else {
            mesh.material = empty;
        }
    }

    public void Empty()
    {
        contents = description = "";
        isFull = false;
    }
}
