using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {
  
    public GameObject foodPrefab;

   
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    
    void Start () {
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }

    void Spawn() {
       
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        int y = (int)Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

       
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); 
    }
}