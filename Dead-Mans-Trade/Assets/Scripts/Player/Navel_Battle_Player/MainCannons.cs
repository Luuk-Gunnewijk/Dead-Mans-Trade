using UnityEngine;

public class MainCannons : MonoBehaviour
{
    [Header("Cannon")]
    [SerializeField] private GameObject cannon;

    [Header("FirePoints")]
    [SerializeField] private Transform firePointR;
    [SerializeField] private Transform firePointL;

    void Start()
    {
        
    }

    void Update()
    {
        ShootCannon();
    }

    private void ShootCannon()
    {  
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(cannon, firePointL.position, firePointL.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(cannon, firePointR.position, firePointR.rotation);
        }
    }
}
