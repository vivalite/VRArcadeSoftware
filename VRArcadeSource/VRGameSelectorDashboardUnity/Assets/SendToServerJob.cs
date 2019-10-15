using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections.TCP;
using System;
using UnityEngine;
using VRGameSelectorDTO;

public class SendToServerJob : ThreadedJob
{
    public ConnectionInfo connectionInfo;
    public VRCommand command;
    public bool isPingOnly = false;

    protected override void ThreadFunction()
    {
        try
        {
            TCPConnection conn = TCPConnection.GetConnection(connectionInfo);
            if (isPingOnly)
            {
                command = new VRCommand(Enums.ControlMessage.NONE);
            }

            conn.SendObject("Command", command);

            //Debug.Log("Connected!");
        }
        catch (Exception ex)
        {
            Debug.Log("Connection Error! " + ex.ToString());
        }

    }
    protected override void OnFinished()
    {

    }
}