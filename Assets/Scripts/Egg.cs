using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Egg : MonoBehaviour
{

    public float breakPoint = -5.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < breakPoint)
        {
            GameManager.Instance.Gameover();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "InsideBasket")
        {
            //Increase score
            GameManager.Instance.AddScore();

            Destroy(gameObject);
        }
    }
}
