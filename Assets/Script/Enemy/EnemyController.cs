using UnityEngine;

public class EnemyController : MonoBehaviour
{

    float speedEnemy = 2;
    

    void Start()
    {
        
    }
    
    private void Update() {
         transform.Translate(Vector3.down * Time.deltaTime*speedEnemy);
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Missile")) 
        {
            GameObject.Destroy(gameObject);
            GameObject.Destroy(other.gameObject);
        }
    }

}

