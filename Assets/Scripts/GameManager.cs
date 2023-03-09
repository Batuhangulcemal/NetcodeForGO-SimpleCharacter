using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += Singleton_OnClientConnectedCallback;
#if UNITY_SERVER
        Debug.Log("ServerStarted");
        NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = "193.140.7.178";
        NetworkManager.Singleton.StartServer();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Debug.Log(Application.targetFrameRate);
#endif
    }

    private void Singleton_OnClientConnectedCallback(ulong obj)
    {
        //Debug.Log("clientConnected");
    }


}
