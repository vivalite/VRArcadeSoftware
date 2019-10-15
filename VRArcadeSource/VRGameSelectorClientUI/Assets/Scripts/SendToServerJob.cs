using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections.TCP;
using System;
using VRGameSelectorDTO;

public class SendToServerJob : ThreadedJob
{
    public ConnectionInfo connectionInfo;
    public VRCommand command;
    public bool isPingOnly = false;
    //public Text textComponent;

    //private bool isConnected;

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

            //isConnected = true;
            //Debug.Log("Connected!");
        }
        catch (Exception)
        {
            //isConnected = false;
            //Debug.Log("Connection Error! " + ex.ToString());
        }
    }

    protected override void OnFinished()
    {
        //if (textComponent != null)
        //{
        //    if (isConnected)
        //        textComponent.text = "Connected to the server!";
        //    else
        //        textComponent.text = "Not connected to the server! Did you run the server program?";
        //}
    }
}