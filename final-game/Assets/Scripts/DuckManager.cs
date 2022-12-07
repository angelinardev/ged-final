using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DuckManager : MonoBehaviour
{
    public WaitForSeconds delay = new WaitForSeconds(5f);
    // Start is called before the first frame update
    void Start()
    {
        SpawnDuck();
    }

    // Update is called once per frame
    void Update()
    {
        //every 5 seconds, spawn new duck
        //StartCoroutine(WaitforSpawn());
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawnDuck();
        }
    }
    void SpawnDuck()
    {
         Vector3 randPosition = new Vector3(Random.Range(-10, 10), Random.Range(-5, 10), 0);
        
        var firstDuck = ObjectPooler.instance.SpawnFromPool("Duck", randPosition, new Quaternion(0f, 0f, 0f, 0f));
        //set the location
        firstDuck.transform.position = randPosition;
        firstDuck.SetActive(true);

        Debug.Log("Trying to spawn");
    }
    private IEnumerator WaitforSpawn()
    {
        SpawnDuck();
        //wait
        //Debug.Log("Waiting");
        yield return delay;
        //after waiting
       
        //Debug.Log("Done waiting");  
          
    }
}
