using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawn;
    [SerializeField] private int numberBulletsPerShot;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shotPeriod;
    [SerializeField] private float minShotRange;
    [SerializeField] private float maxShotRange;

    private float _timer;
    private TankMuzzleRotation _tankMuzzle;

    private void Awake()
    {
        _tankMuzzle = GetComponentInParent<TankMuzzleRotation>();
    }

    private void Update()
    {
        if(_tankMuzzle.CheckDistance())
        {
            _timer += Time.deltaTime;
            if (_timer > shotPeriod)
            {
                _timer = 0;
                Shot();
            }
        } 
    }

    private void Shot()
    {
        for (int i = 0; i < numberBulletsPerShot; i++)
        {
            float offset = Random.Range(minShotRange, maxShotRange);
            GameObject newBullet = Instantiate(bulletPrefab.gameObject, spawn.position + new Vector3(offset, offset, offset), spawn.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = spawn.forward * bulletSpeed;
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
