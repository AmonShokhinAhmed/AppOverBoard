﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rules : MonoBehaviour
{
    public Button btn_places;
    public Button btn_evil;
    public Button btn_good;
    public Button btn_winCon;
    public Button btn_hints;
    public Button btn_movement;
    public Button btn_player;
    public Button btn_backPlace;
    public Button btn_backEvil;
    public Button btn_backGood;
    public Button btn_backWinCon;
    public Button btn_backHints;
    public Button btn_backMovement;

    public Canvas places1;
    public Canvas places2;
    public Canvas places3;
    public Canvas places4;
    public Canvas evil1;
    public Canvas evil2;
    public Canvas evil3;
    public Canvas evil4;
    public Canvas good1;
    public Canvas good2;
    public Canvas winCon;
    public Canvas hints;
    public Canvas movement;

    void btnToPrivatePlayer()
    {
        UIManager.Instance.PrivatePlayer();
    }

    void btnToRulesPlace1()
    {
        UIManager.Instance.RulesPlace1();
    }

    void btnToRulesPlace2()
    {
        UIManager.Instance.RulesPlace2();
    }

    void btnToRulesPlace3()
    {
        UIManager.Instance.RulesPlace3();
    }

    void btnToRulesPlace4()
    {
        UIManager.Instance.RulesPlace4();
    }

    void btnToRulesEvil1()
    {
        UIManager.Instance.RulesEvil1();
    }

    void btnToRulesEvil2()
    {
        UIManager.Instance.RulesEvil2();
    }

    void btnToRulesEvil3()
    {
        UIManager.Instance.RulesEvil3();
    }

    void btnToRulesEvil4()
    {
        UIManager.Instance.RulesEvil4();
    }

    void btnToRulesGood1()
    {
        UIManager.Instance.RulesGood1();
    }

    void btnToRulesGood2()
    {
        UIManager.Instance.RulesGood2();
    }

    void btnToRulesWinCon()
    {
        UIManager.Instance.RulesWinCon();
    }

    void btnToRulesHints()
    {
        UIManager.Instance.RulesHints();
    }

    void btnToRulesMovement()
    {
        UIManager.Instance.RulesMovement();
    }

    void btnToContents()
    {
        UIManager.Instance.Rules();
    }

    private void OnEnable()
    {
        btn_places.onClick.RemoveAllListeners();
        btn_places.onClick.AddListener(btnToRulesPlace1);

        btn_evil.onClick.RemoveAllListeners();
        btn_evil.onClick.AddListener(btnToRulesEvil1);

        btn_good.onClick.RemoveAllListeners();
        btn_good.onClick.AddListener(btnToRulesGood1);

        btn_winCon.onClick.RemoveAllListeners();
        btn_winCon.onClick.AddListener(btnToRulesWinCon);

        btn_hints.onClick.RemoveAllListeners();
        btn_hints.onClick.AddListener(btnToRulesHints);

        btn_movement.onClick.RemoveAllListeners();
        btn_movement.onClick.AddListener(btnToRulesMovement);

        btn_player.onClick.RemoveAllListeners();
        btn_player.onClick.AddListener(btnToPrivatePlayer);

        btn_backPlace.onClick.RemoveAllListeners();
        btn_backPlace.onClick.AddListener(btnToContents);

        btn_backGood.onClick.RemoveAllListeners();
        btn_backGood.onClick.AddListener(btnToContents);

        btn_backEvil.onClick.RemoveAllListeners();
        btn_backEvil.onClick.AddListener(btnToContents);

        btn_backHints.onClick.RemoveAllListeners();
        btn_backHints.onClick.AddListener(btnToContents);

        btn_backMovement.onClick.RemoveAllListeners();
        btn_backMovement.onClick.AddListener(btnToContents);

        btn_backWinCon.onClick.RemoveAllListeners();
        btn_backWinCon.onClick.AddListener(btnToContents);
    }

    private void Update()
    {
        Touch touch = Input.GetTouch(0);

        if (places1.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.Rules();

            else if (touch.position.x > 0)
                UIManager.Instance.RulesPlace2();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.RulesPlace2();
        }

        if (places2.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.RulesPlace1();

            else if (touch.position.x > 0)
                UIManager.Instance.RulesPlace3();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.RulesPlace3();
        }

        if (places3.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.RulesPlace2();

            else if (touch.position.x > 0)
                UIManager.Instance.RulesPlace4();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.RulesPlace4();
        }

        if (places4.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.RulesPlace3();

            else if (touch.position.x > 0)
                UIManager.Instance.Rules();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.Rules();
        }

        if (evil1.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.Rules();

            else if (touch.position.x > 0)
                UIManager.Instance.RulesEvil2();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.RulesEvil2();
        }

        if (evil2.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.RulesEvil1();

            else if (touch.position.x > 0)
                UIManager.Instance.RulesEvil3();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.RulesEvil3();
        }

        if (evil3.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.RulesEvil2();

            else if (touch.position.x > 0)
                UIManager.Instance.RulesEvil4();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.RulesEvil4();
        }

        if (evil4.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.RulesEvil3();

            else if (touch.position.x > 0)
                UIManager.Instance.Rules();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.Rules();
        }

        if (good1.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.Rules();

            else if (touch.position.x > 0)
                UIManager.Instance.RulesGood2();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.RulesGood2();
        }

        if (good2.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.RulesGood1();

            else if (touch.position.x > 0)
                UIManager.Instance.Rules();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.Rules();
        }

        if (winCon.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.Rules();

            else if (touch.position.x > 0)
                UIManager.Instance.Rules();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.Rules();
        }

        if (hints.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.Rules();

            else if (touch.position.x > 0)
                UIManager.Instance.Rules();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.Rules();
        }

        if (movement.enabled == true)
        {
            if (touch.position.x <= 0)
                UIManager.Instance.Rules();

            else if (touch.position.x > 0)
                UIManager.Instance.Rules();

            if (Input.GetKeyDown(KeyCode.Space))
                UIManager.Instance.Rules();
        }
    }

}