using UnityEngine;

public class PlayerNB : MonoBehaviour
{
    public static PlayerNB Instance;
    private void Awake()
    {
        Instance = this;
    }
}
