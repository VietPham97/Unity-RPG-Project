using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public GameObject player;
}
