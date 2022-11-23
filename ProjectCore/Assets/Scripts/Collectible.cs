using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    bool collected = false;
    int index;
    public Collector collector;
    
    public bool getCollected()
    {
        return collected;
    }

    public void setCollected()
    {
       collected = true;
    }

    public void setIndex(int index)
    {
        this.index = index;
    }

    private void Update()
    {
        if(collected && transform.parent == collector.transform.parent)
        {
            transform.localPosition = new Vector3(0, -index, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Barrier")
        {
            collector.loseCubes();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
}
