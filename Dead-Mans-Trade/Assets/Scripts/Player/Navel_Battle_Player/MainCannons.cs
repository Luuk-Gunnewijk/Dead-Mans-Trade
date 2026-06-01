using UnityEngine;

public class MainCannons : MonoBehaviour
{
    [Header("Cannon")]
    [SerializeField] private GameObject cannon;

    void Start()
    {
        
    }

    void Update()
    {
        ShootCannon();
    }

    private void ShootCannon()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(cannon, transform.position, Quaternion.identity);
        }
    }
}
