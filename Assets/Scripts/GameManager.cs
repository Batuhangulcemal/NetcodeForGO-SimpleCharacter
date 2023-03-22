using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using BestHTTP;
using System;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += Singleton_OnClientConnectedCallback;
#if UNITY_SERVER
        ConfigureServer();
#endif
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsServer)
        {
            //NetworkManager.SceneManager.LoadScene("OtherScene", LoadSceneMode.Single);
        }
    }

    private void Singleton_OnClientConnectedCallback(ulong obj)
    {
        //Debug.Log("clientConnected");
    }

    private void ConfigureServer()
    {
        Debug.Log("ServerStarted");
        NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = "193.140.7.178";
        NetworkManager.Singleton.StartServer();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Debug.Log(Application.targetFrameRate);
    }

    public void ClientChangeScene(int sceneNumber)
    {
        NetworkManager.SceneManager.LoadScene("OtherScene", LoadSceneMode.Single);

        //SceneManager.LoadScene(sceneNumber);
    }



}
