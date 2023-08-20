

public class Weapon : MonoBehaviour {

    public float range = 100f;
    public int bulletsPerMag = 30;
    public int bulletsLeft = 200;

    public int currentBullets;

    public Transform shootPoint;

    public float fireRate = 10f;

    float fireTimer;

    //Use This for Installation
    void Start(){

        currentBullets = bulletsPerMag;
    }

    //Update
    void Update(){

        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

    }

    private void Fire()
    {
        if (fireTimer < fireRate) return;

        RaycastHit hit;

        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " found!");
        }

        currentBullets--;
        fireTimer = 0.0f;
    }

}