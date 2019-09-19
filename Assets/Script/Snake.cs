using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
	
	bool ate = false;

	bool isDied = false;
    
	public GameObject tailPrefab;

	
	Vector2 dir = Vector2.right;
    private string formattedTime = "0s";
    private int score = 0;
    
    List<Transform> tail = new List<Transform>();
    private int time = 0;
   
    private void OnGUI()
    {
       GUI.Label(new Rect((Screen.width / 10) * 2 , 40, 100, 20),  "Time: " + formattedTime);
        GUI.Label(new Rect((Screen.width / 10) * 2, 60, 100, 20), "Player1 Score: " + score);
    
    }
    void Start () {
	
		InvokeRepeating("Move", 0.3f, 0.3f);
        InvokeRepeating("updateTime", 1, 1);
    }

	
	void Update () {
		if (!isDied) {
			
			if (Input.GetKey (KeyCode.RightArrow))
				dir = Vector2.right;
			else if (Input.GetKey (KeyCode.DownArrow))
				dir = -Vector2.up;    // '-up' means 'down'
			else if (Input.GetKey (KeyCode.LeftArrow))
				dir = -Vector2.right; // '-right' means 'left'
			else if (Input.GetKey (KeyCode.UpArrow))
				dir = Vector2.up;
		} else {
			if (Input.GetKey(KeyCode.R)){
				
				tail.Clear();

				
				transform.position = new Vector3(0, 0, 0);
                score = 0;
              
                isDied = false;
			}
		}
	}
    private void updateTime()
    {
        time++;
        if (time < 60)
        {
            formattedTime = time + "s";
        }
        else if (time < 60 * 60)
        {
            formattedTime = time / 60 + "m " + (time - time / 60 * 60) + "s";
        }
        else if (time < 60 * 60 * 60)
        {
            int hours = (time / (3600));
            int minutes = ((time - (hours * 3600)) / 60);
            int seconds = time - (hours * 3600) - (minutes * 60);
            formattedTime = hours + "h "
                + minutes + "m "
                + seconds + "s";
        }
    }

    void Move() {
		if (!isDied) {
			
			Vector2 v = transform.position;

			
			transform.Translate (dir);

			
			if (ate) {
                score++;
			
				GameObject g = (GameObject)Instantiate (tailPrefab,
					              v,
					              Quaternion.identity);

				
				tail.Insert (0, g.transform);

			
				ate = false;
			} else if (tail.Count > 0) {	
					tail.Last ().position = v;
                
					tail.Insert (0, tail.Last ());
					tail.RemoveAt (tail.Count - 1);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		
   
		if (coll.name.StartsWith("Food")) {
			
			ate = true;
			
			Destroy(coll.gameObject);
		} else { 
			isDied = true;
           
		}
	}
}
 