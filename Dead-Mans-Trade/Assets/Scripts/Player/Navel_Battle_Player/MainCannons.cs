using UnityEngine;
using System.Collections;

public class MainCannons : MonoBehaviour
{
    [Header("Cannon")]
    [SerializeField] private GameObject cannon;
    [SerializeField] private float cannonTimeL;
    [SerializeField] private float cannonTimeR;

    [Header("FirePoints")]
    [SerializeField] private Transform firePointR;
    [SerializeField] private Transform firePointL;

    private bool _canShootL = true;
    private bool _canShootR = true;

    void Update()
    {
        ShootLeftCannon();
        ShootRightCannon();

        Debug.Log("CanShootLeft" + _canShootL);
        Debug.Log("CanShootRight" + _canShootR);
    }

    private void ShootLeftCannon()
    {
        if (Input.GetKeyDown(KeyCode.Z) && _canShootL)
        {
            GameObject cannonBall = Instantiate(cannon, firePointL.position, firePointL.rotation);
            cannonBall.GetComponent<SpriteRenderer>().flipY = true;
            StartCoroutine(LeftCannonRoutine());
        } 
    }

    private void ShootRightCannon()
    {
        if (Input.GetKeyDown(KeyCode.C) && _canShootR)
        {
            GameObject cannonBall = Instantiate(cannon, firePointR.position, firePointR.rotation);
            cannonBall.GetComponent<SpriteRenderer>().flipY = false;
            StartCoroutine(RightCannonRoutine());
        }      
    }

    private IEnumerator LeftCannonRoutine()
    {
        _canShootL = false;
        yield return new WaitForSeconds(cannonTimeL);
        _canShootL = true;
    }

    private IEnumerator RightCannonRoutine()
    {
        _canShootR = false;
        yield return new WaitForSeconds(cannonTimeR);
        _canShootR = true;
    }
}
