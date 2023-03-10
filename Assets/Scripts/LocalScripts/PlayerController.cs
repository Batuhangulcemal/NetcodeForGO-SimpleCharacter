using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] public Player player;

    private void Awake()
    {
        Instance = this;
    }

    public void AttachPlayer(Player _player)
    {
        player = _player;
        transform.SetParent(player.transform, false);

        GetComponent<PlayerAnimation>().enabled = true;
    }

    public void DetachPlayer()
    {
        GetComponent<PlayerAnimation>().enabled = false;

        player = null;
        transform.SetParent(null);

    }
}
