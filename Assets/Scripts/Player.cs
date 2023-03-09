using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public override void OnGainedOwnership()
    {
        base.OnGainedOwnership();
        Debug.Log("GainedOwnership");
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Debug.Log("NetworkSpawn");

        if (IsLocalPlayer)
        {
            PlayerController.Instance.SetLocalPlayer(this);
        }
        
    }





}
