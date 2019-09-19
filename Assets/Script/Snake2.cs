using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake2 : MonoBehaviour
{
   
    bool ate = false;

  
    bool isDied = false;
    private int score2 = 0;
   
    public GameObject tailPrefab;

  
    Vector2 dir = Vector2.right;

    
    List<Transform> tail = new List<Transform>();
    
    void Start()
    {
        
        InvokeRepeating("Move", 0.3f, 0.3f);
    }
    private void OnGUI()
    {
       
        GUI.Label(new Rect((Screen.width / 3) * 2, 60, 100, 20), "Player2 Score: " + score2);


      
    }
    
    void Update()
    {
        if (!isDied)
        {
            if (Input.GetKey(KeyCode.D))
                dir = Vector2.right;
            else if (Input.GetKey(KeyCode.S))
                dir = -Vector2.up;    // '-up' means 'down'
            else if (Input.GetKey(KeyCode.A))
                dir = -Vector2.right; // '-right' means 'left'
            else if (Input.GetKey(KeyCode.W))
                dir = Vector2.up;
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
               
                tail.Clear();

              
                transform.position = new Vector3(0, 0, 0);
                score2 = 0;
                
                isDied = false;
            }
        }
    }

    void Move()
    {
        if (!isDied)
        {
            
            Vector2 v = transform.position;

            
            transform.Translate(dir);

         
            if (ate)
            {
                score2++;
                
                GameObject g = (GameObject)Instantiate(tailPrefab,
                                  v,
                                  Quaternion.identity);

                
                tail.Insert(0, g.transform);

               
                ate = false;
            }
            else if (tail.Count > 0)
            {   
               
                tail.Last().position = v;

                
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("Food"))
        {
           
            ate = true;

         
            Destroy(coll.gameObject);
        }
        else
        {   
            isDied = true;
          
        }
    }
}
