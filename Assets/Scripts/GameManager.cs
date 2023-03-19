using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using BestHTTP;
using System;

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
        CreateOrUpdateStatus();
#endif
    }

    private void Singleton_OnClientConnectedCallback(ulong obj)
    {
        //Debug.Log("clientConnected");
    }

    //should refactor
    private void CreateOrUpdateStatus()
    {
        string serverName = "server-7771";
        string userCount = "31";
        string maxUserCapacity = "60";
        string up = "true";
        string full = "false";
        string json = $"{{\"serverName\":\"{serverName}\",\"userCount\":\"{userCount}\",\"maxUserCapacity\":\"{maxUserCapacity}\",\"up\":\"{up}\",\"full\":\"{full}\"}}";

        var request = new HTTPRequest(new Uri("http://193.140.7.178:7769/api/status/update"), HTTPMethods.Post, OnCreateOrUpdateFinished);

        request.SetHeader("Content-Type", "application/json; charset=UTF-8");
        request.RawData = System.Text.Encoding.UTF8.GetBytes(json);

        request.Send();
    }

    private void OnCreateOrUpdateFinished(HTTPRequest originalRequest, HTTPResponse response)
    {
        if (response.StatusCode != 200)
        {
            Debug.Log("CreateStatus Failed");
        }
    }


}
