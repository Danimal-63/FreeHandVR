using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    private GameObject temp;
    public GameObject WFX_ExplosiveSmokeGroundBig;
    void Awake()
    {
        temp = GameObject.FindGameObjectWithTag("FxTemporaire");
    }
    private void OnCollisionEnter(Collision c)
    {
        health--;
        GameObject.Destroy(c.gameObject);
        if (health < 3)
        { 
            Instantiate(temp, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
