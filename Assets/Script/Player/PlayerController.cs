using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //instantiate objects
    public GameObject Missile;
    public Transform SpawnMissile;
    public AudioClip audioShot;

    //Variables 
    public float speed= 10f;
    public float rangMove;
    public float shootForce=1000f;
    public float shootRate=0.5f;
    private float shootRateTime = 1f;


    //Variable InputActions
    InputAction moveAction;
    InputAction shootAction;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        onMOve();
        OnShoot();
    }

    void onMOve(){
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if(transform.position.x < -rangMove){
            transform.position = new Vector3(-rangMove, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > rangMove){
            transform.position = new Vector3(rangMove, transform.position.y, transform.position.z);
        }
        
        transform.Translate(Vector3.right * Time.deltaTime * speed * moveValue);
    }

    void OnShoot()
    {
        bool shootValue = shootAction.IsInProgress();

        if(shootValue){
            if (Time.time > shootRateTime)
            {
            AudioManager.Instance.PlayFX("audioShot");
            GameObject newMissile;

            newMissile = Instantiate(Missile, SpawnMissile.position, SpawnMissile.rotation );
            newMissile.GetComponent<Rigidbody>().AddForce(SpawnMissile.forward * shootForce);
            shootRateTime = Time.time + shootRate;
            }
        }
        
    }


}
