using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private bool haveCoin;
    public GameObject coin;
    private Renderer renderer;
    private Color newColor;

    private int score = 0;
    private int state = 0;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        Vector3 random = new Vector3(Random.Range(-16, 16), 1, Random.Range(-6, 10));
        Instantiate(coin, random, coin.transform.rotation);
    }

    void Update()
    {
        StateMachine();
        if (state == 2)
        {
            newColor = new Color(255, 0, 0);
            renderer.material.SetColor("_Color", newColor);
        }
        else
        {
            newColor = new Color(0, 0, 255);
            renderer.material.SetColor("_Color", newColor);
        }
    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Coin"))
        {
            if (haveCoin == false)
            {
                haveCoin = true;
                Debug.Log("Coin Collected");
            }
        }

        if (col.gameObject.CompareTag("House"))
        {
            if (haveCoin == true)
            {
                Vector3 position = new Vector3(Random.Range(-16, 16), 1, Random.Range(-6, 10));
                Instantiate(coin, position, coin.transform.rotation);
                score++;
                Debug.Log("Score: " + score);
                haveCoin = false;
            }
        }
    }

    private void StateMachine()
    {
        if (state == 0)
        {
            Debug.Log("Idle");
        }
        if (state == 1)
        {
            Debug.Log("Moving");
        }
        if (state == 2)
        {
            Debug.Log("Exciting");
        }
        if (haveCoin == true)
        {
            state = 2;
        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            state = 1;
        }
        else
        {
            state = 0;
        }
    }
}
