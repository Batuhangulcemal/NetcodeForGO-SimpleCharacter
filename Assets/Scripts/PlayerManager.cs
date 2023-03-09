using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private TextMeshProUGUI playersText;
    [SerializeField] private TextMeshProUGUI playerCountText;
    [SerializeField] private TextMeshProUGUI clientIdText;


    [ServerRpc(RequireOwnership = false)]
    public void RefreshPlayerListServerRpc(ServerRpcParams serverRpcParams = default)
    {
        ulong clientId = serverRpcParams.Receive.SenderClientId;

        if (NetworkManager.ConnectedClients.ContainsKey(clientId))
        {         
            ClientRpcParams crpcParams= new ClientRpcParams();
            crpcParams.Send.TargetClientIds = new ulong[] { clientId };

            string tmp = "";
            int count = NetworkManager.ConnectedClients.Count;

            foreach (ulong id in NetworkManager.Singleton.ConnectedClientsIds)
            {
                tmp += id.ToString() + " ";
            }



            RefreshListClientRpc(tmp, count, clientId, crpcParams);
        }
    }

    [ClientRpc]
    private void RefreshListClientRpc(string text, int count, ulong clientId, ClientRpcParams clientRpcParams = default)
    {
        playersText.text = text;
        playerCountText.text = count.ToString();
        clientIdText.text = clientId.ToString();
        
    }

}
