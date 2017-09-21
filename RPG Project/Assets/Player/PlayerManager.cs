using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
