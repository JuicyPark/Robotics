using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    PhotonManager photonManager;
    [SerializeField]
    StartTriangle startTriangle;
    void Start()
    {
        BindEvents();
    }

    void OnDestroy()
    {
        UnBindEvents();
    }

    void BindEvents()
    {
        photonManager.Ready += startTriangle.GetReady;
    }

    void UnBindEvents()
    {
        photonManager.Ready -= startTriangle.GetReady;
    }
}
