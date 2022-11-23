using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    GameObject player;
    Animator animator;
    int stackHeight;
    public GameObject fail;
    public GameObject success;
    public GameObject resBtn;
    public GameObject exitBtn;
    public GameObject nextBtn;
    void Start()
    {
        player = GameObject.Find("MainCube");
        var model = GameObject.Find("Player");
        animator = model.GetComponent<Animator>();
    }

   public void loseCubes()
    {
        stackHeight--;
        player.transform.position = new Vector3(transform.position.x, transform.position.y + stackHeight, transform.position.z);
        transform.localPosition = new Vector3(0, -stackHeight, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Collectible")
        {
            bool isCollected = other.gameObject.GetComponent<Collectible>().getCollected();
            if (!isCollected)
            {
                stackHeight += 1;
                other.gameObject.GetComponent<Collectible>().setCollected();
                other.gameObject.GetComponent<Collectible>().setIndex(stackHeight);
                other.gameObject.transform.parent = player.transform;
                player.transform.position = new Vector3(transform.position.x, transform.position.y + stackHeight, transform.position.z);
                transform.localPosition = new Vector3(0, -stackHeight, 0);
            }
        }
        else if(other.gameObject.tag == "Barrier" && stackHeight == 0)
        {
            animator.SetBool("gameOver", true);
            player.GetComponent<PlayerMovement>().enabled = false;
            fail.SetActive(true);
            resBtn.SetActive(true);
            exitBtn.SetActive(true);
        }
        else if (other.gameObject.tag == "FinishLine")
        {
            animator.SetBool("levelCompleted", true);
            player.GetComponent<PlayerMovement>().enabled = false;
            success.SetActive(true);
            nextBtn.SetActive(true);
        }

    }
}
