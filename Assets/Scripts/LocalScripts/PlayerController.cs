using Cinemachine;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] public Player player;
    [SerializeField] public CinemachineFreeLook CMcamera;
    [SerializeField] public Transform HeadTransform;

    private void Awake()
    {
        Instance = this;
    }

    public void AttachPlayer(Player _player)
    {
        player = _player;
        transform.SetParent(player.transform, false);

        CMcamera.Follow = HeadTransform;
        CMcamera.LookAt = HeadTransform;

        GetComponent<PlayerAnimation>().enabled = true;

    }

    public void DetachPlayer()
    {
        GetComponent<PlayerAnimation>().enabled = false;

        player = null;
        transform.SetParent(null);

    }
}
