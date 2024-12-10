using System.Collections;
using System.Collections.Generic;
using Unity.Services.Vivox;
using UnityEngine;
using Unity.Netcode;
using Unity.Services.Core;
using Unity.Services.Authentication;

public class VivoxPlayer : NetworkBehaviour
{
    [SerializeField] private GameObject _localPlayerHead;
    private Vector3 _lastPlayerHeadPos;

    private string _gameChannelName = "Test3DChannel";
    private bool IsIn3DChannel = false;
    private Channel3DProperties _player3DProperties;

    private int _clientID;
    [SerializeField] private int _newVolumeMinusPlus50 = 0;

    private float _nextPosUpdate;

    private void Start()
    {
        if (IsLocalPlayer)
        {
            InitializeAsync();

            VivoxService.Instance.LoggedIn += onLoggedIn;
            VivoxService.Instance.LoggedOut += onLoggedOut;
        }
    }

    private void Update()
    {
        if (IsIn3DChannel && IsLocalPlayer)
        {
            if ( Time.time > _nextPosUpdate)
            {
                updatePlayer3DPos();
                _nextPosUpdate += 0.3f;
            }
        }
        {
            
        }
    }

    private async void InitializeAsync()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        await VivoxService.Instance.InitializeAsync();
        Debug.Log("Vivox: Initialize successfull");
    }

    private void onLoggedIn()
    {
        if (VivoxService.Instance.IsLoggedIn)
        {
            Debug.Log("Vivox: Client" + _clientID + "Login successfull");
        }
        else
        {
            Debug.Log("Player: Cannot sign into Vivox, check your credentials and token settings");
        }
    }

    private void onLoggedOut()
    {
        IsIn3DChannel = false;

        VivoxService.Instance.LeaveAllChannelsAsync();
        Debug.Log("Vivox: Left from all channels");
        VivoxService.Instance.LogoutAsync();
        Debug.Log("Vivox: Logged out from Vivox");
    }
}
