using System.Collections;
using System.Collections.Generic;
using Unity.Services.Vivox;
using UnityEngine;
using Unity.Netcode;

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
        }
    }

    private async void InitializeAsync()
    {

    }
}
