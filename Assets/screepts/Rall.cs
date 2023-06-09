using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rall : MonoBehaviour
{
    private float deltaTime;
    public string stoppingSlot;
    public int random;

    void Start()
    {
        stop = true;
        Rolling();
        stop = false;
    }
    

    private IEnumerator Rolling() //рух та рандом котів
    {
        stop = false;
        deltaTime = 0.3f;
        random = Random.Range(0, 10);
        for (int i = 0; i < random; i++)
        {
            while (i < random && transform.position.y >= -550)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 280);
                yield return new WaitForSeconds(deltaTime);
                i++;
            }
            while (i < random && transform.position.y <= 550)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 280);
                yield return new WaitForSeconds(deltaTime);
                i++;
            }
        }
        
    }


}

