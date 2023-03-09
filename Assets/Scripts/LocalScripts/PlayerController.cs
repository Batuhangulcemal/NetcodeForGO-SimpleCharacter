using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] Player player;

    private void Awake()
    {
        Instance = this;
    }

    public void SetLocalPlayer(Player _player)
    {
        player = _player;
        _player.gameObject.name = "LocalPlayer";
    }
}
