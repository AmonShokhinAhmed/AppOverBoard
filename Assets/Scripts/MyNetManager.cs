﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

public class MyNetManager : NetworkManager
{
    public static MyNetManager Instance;
    public NetworkDiscovery MyNetDiscovery;
    public bool isServer;
    public bool isClient;
    public bool waiting;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }


    void Start()
    {
        NetworkTransport.Init();
    }

    public void StartGame()
    {
        isServer = true;
        StartHost();
        MyNetDiscovery.Initialize();
        MyNetDiscovery.StartAsServer();
    }

    public void SearchGame()
    {
        StartCoroutine(CheckConnection());
    }

    IEnumerator CheckConnection()
    {
        MyNetDiscovery.Initialize();
        waiting = true;
        StartCoroutine("animateLookingForGame");
        yield return new WaitForSeconds(.5f);
        MyNetDiscovery.StartAsClient();
        yield return new WaitForSeconds(4.5f);
        waiting = false;
        yield return new WaitForSeconds(1f);
        if (IsClientConnected())
        {
            if (MyNetDiscovery.running)
            {
                MyNetDiscovery.StopBroadcast();
            }
            isClient = true;
            Connection.Instance.txtInfo.text = "Verbunden!";
            yield return new WaitForSeconds(1.2f);
        }
        else
        {
            Connection.Instance.txtInfo.text = "Nichts gefunden. Versuche es manuell.";
            StopClient();
            if (MyNetDiscovery.running)
            {
                MyNetDiscovery.StopBroadcast();
            }
            yield return new WaitForSeconds(.1f);
            Connection.Instance.ManualConnectLayout();

        }
    }
    IEnumerator animateLookingForGame()
    {

        while (waiting)
        {
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel    ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel .  ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel .. ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel ...";
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void ManualConnect()
    {
        
        StartCoroutine(ManualConnectEnter());
    }

    IEnumerator ManualConnectEnter()
    {
        
        if (Connection.Instance.IPInputField.text != "")
        {
            waiting = true;
            StartCoroutine("animateManualConnection");
            networkAddress = Connection.Instance.IPInputField.text;
            StartClient();
            yield return new WaitForSeconds(3f);
            waiting = false;
            yield return new WaitForSeconds(1.2f);
            if (IsClientConnected())
            {
                isClient = true;
                Connection.Instance.txtInfo.text = "Verbunden!";
            }
            else
            {
                Connection.Instance.txtInfo.text = "Nichts gefunden, probiers nochmal.";
                StopClient();
            }
        }
        else
        {
            Connection.Instance.txtInfo.text = "Gib eine Ip-Adresse ein.";
        }
    }
    IEnumerator animateManualConnection()
    {
        while (waiting)
        {
            Connection.Instance.txtInfo.text = "Manuelles verbinden    ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Manuelles verbinden .  ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Manuelles verbinden .. ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Manuelles verbinden ...";
            yield return new WaitForSeconds(0.3f);

        }
    }

    public void StopHosting()
    {
        if (isServer)
        {
            StopHost();
            NetworkServer.ClearLocalObjects();
            NetworkServer.ClearSpawners();
        }
        if (isClient)
        {
            StopHost();
            StopClient();
            
        }
        if (MyNetDiscovery.running)
        {
            MyNetDiscovery.StopBroadcast();
        }
            StopAllCoroutines();
        NetworkServer.Reset();
        NetworkTransport.Init();
        NetworkTransport.Shutdown();
        isServer = false;
        isClient = false;
        TimeManager.Instance.gameObject.SetActive(false);
        UIManager.Instance.Connection();
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        
    }

    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "Unknown";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        isServer = false;
        if (MyNetDiscovery.running)
        {
            MyNetDiscovery.StopBroadcast();
        }
        UIManager.Instance.Connection();
    }

    // public override void OnServerDisconnect(NetworkConnection conn)
    //{
    //    base.OnServerDisconnect(conn);
    //    EventDispatcher.TriggerEvent(Vars.ServerHandleDisconnect);
    //}


    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        isClient = false;
        UIManager.Instance.RestartScene();
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        if (IsClientConnected())
        {
            isClient = false;
        }
    }

    public override void OnServerDisconnect(NetworkConnection connection)
    {
        base.OnServerConnect(connection);
        UIManager.Instance.RestartScene();

    }
}
