using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    [SerializeField] private Button stopConnectionButton;
    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button changeSceneButton;
    [SerializeField] private Button debugTextResetButton;

    [SerializeField] private Button changeIpButton;



    [SerializeField] private TextMeshProUGUI debugText;

    [SerializeField] private TextMeshProUGUI ipText;



    [SerializeField] private TextMeshProUGUI isServerText;
    [SerializeField] private TextMeshProUGUI isClientText;
    [SerializeField] private TextMeshProUGUI isClientConnectedText;
    [SerializeField] private TextMeshProUGUI playercountText;
    [SerializeField] private TextMeshProUGUI playersIdsText;
    [SerializeField] private TextMeshProUGUI clientIdText;
    [SerializeField] private TextMeshProUGUI debugLogText;



    private UnityTransport transport;

    private void Awake()
    {

        stopConnectionButton.onClick.AddListener(() => StopConnectionButtonPressed());
        serverButton.onClick.AddListener(() => ServerButtonPressed());
        hostButton.onClick.AddListener(() => HostButtonPressed());
        clientButton.onClick.AddListener(() => ClientButtonPressed());
        changeSceneButton.onClick.AddListener(() => ChangeSceneButtonPressed());
        debugTextResetButton.onClick.AddListener(() => debugText.text = string.Empty);

        changeIpButton.onClick.AddListener(() => ChangeIpButtonPressed());

        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        Application.logMessageReceived += Application_logMessageReceived;



    }



    private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
    { 
        debugLogText.text += "\n" + condition;
    }

    private void Update()
    {
        isServerText.text = NetworkManager.Singleton.IsServer.ToString();
        isClientText.text = NetworkManager.Singleton.IsClient.ToString();
        isClientConnectedText.text = NetworkManager.Singleton.IsConnectedClient.ToString();

    }

    private void StopConnectionButtonPressed()
    {
        NetworkManager.Singleton.Shutdown();
    }

    private void ServerButtonPressed()
    {
        NetworkManager.Singleton.StartServer();

    }

    private void HostButtonPressed()
    {
        NetworkManager.Singleton.StartHost();

    }

    private void ClientButtonPressed()
    {
        NetworkManager.Singleton.StartClient();
    }

    private void ChangeSceneButtonPressed()
    {
        if (!NetworkManager.Singleton.IsServer) return;

        Debug.Log("asd");
        GameManager.Instance.ClientChangeScene(1);
    }

    private void ChangeIpButtonPressed()
    {
        transport.ConnectionData.Address = transport.ConnectionData.Address.Equals("193.140.7.178") ? "127.0.0.1" : "193.140.7.178";
        ipText.text = transport.ConnectionData.Address;
    }

}
