using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;
public class CreateAndJoinRoom : MonoBehaviourPunCallbacks, IConnectionCallbacks
{  
   public string txtNameRoom;

   public TMP_InputField txtInputRoomName;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        DontDestroyOnLoad(this);
        Debug.Log(txtNameRoom);
    }
    public  void CreateRoom()
    {
        txtNameRoom = txtInputRoomName.text;
        PhotonNetwork.CreateRoom(txtNameRoom) ;
    }

    
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    

    public override void OnConnectedToMaster()
    {
       


        
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("đã tạo được phòng");


    }

    public override void OnJoinedRoom()
    {
        Debug.Log("đã vô phòng");
        SceneManager.LoadScene("GAMEPLAY");
    }



}
