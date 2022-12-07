using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleController : MonoBehaviour
{
    bool inverted = false;
    Rigidbody rb;
    
    int missedInARow = 0;

    InvertInvoker invoker;

    bool hitHappened = false;

    bool runOnce = false;

    GameObject reference;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        invoker = new InvertInvoker();
    }

    // Update is called once per frame
    void Update()
    {
        //moving the reticle
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //rb.velocity += new Vector3(-1, 0, 0);
            transform.position +=new Vector3(-1, 0, 0);
            Debug.Log("Moving");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
             //rb.velocity += new Vector3(1, 0, 0);
              transform.position +=new Vector3(1, 0, 0);
              Debug.Log("Moving");
        }
        if (!inverted)
        {if (Input.GetKeyDown(KeyCode.UpArrow))
        {
             //rb.velocity += new Vector3(0, 1, 0);
              transform.position +=new Vector3(0, 1, 0);
              Debug.Log("Moving");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
             //rb.velocity += new Vector3(0, -1, 0);
              transform.position +=new Vector3(0, -1, 0);
              Debug.Log("Moving");
        }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
        {
             //rb.velocity += new Vector3(0, 1, 0);
              transform.position +=new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
             //rb.velocity += new Vector3(0, -1, 0);
              transform.position +=new Vector3(0, -1, 0);
        }
        }

        //for hitting the ducks
        if (missedInARow >=2 && !runOnce)
        {
            ICommand command = new InvertCommand(this);
            invoker.AddCommand(command);
            runOnce = true;
        }

        //check if missed ducks
        if (!hitHappened && Input.GetKeyDown(KeyCode.Space))
        {
            missedInARow +=1;
        }
        else if (hitHappened&& Input.GetKeyDown(KeyCode.Space))
        {
            missedInARow -=1;
            if (missedInARow <0)
                missedInARow = 0;

            //deactivate
            reference.SetActive(false);
            
        }
        Debug.Log(missedInARow);
    }
    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Duck" || other.collider.isTrigger)
        {
            hitHappened = true;
            reference = other.gameObject;
            Debug.Log("We are colliding");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                missedInARow -=1;
                if (missedInARow <0)
                    missedInARow = 0;
                //deactivate
                reference.SetActive(false);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Duck" || other.isTrigger)
        {
            hitHappened = true;
            reference = other.gameObject;
            Debug.Log("We are colliding");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                missedInARow -=1;
                if (missedInARow <0)
                    missedInARow = 0;
                //deactivate
                reference.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Duck" ||other.isTrigger )
        {
            hitHappened = false;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.collider.tag == "Duck" ||other.collider.isTrigger )
        {
            hitHappened = false;
        }
    }
    public void SetInverted()
    {
        inverted = true;
    }
}
