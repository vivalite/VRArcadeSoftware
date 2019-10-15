using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Valve.VR;
using VRGameSelectorDTO;

public class SendRunningGameJob : ThreadedJob
{
    public RunningGameInfo OutputRunningGameInfo;
    public ConnectionInfo connectionInfo;

    protected override void ThreadFunction()
    {
        GetRunningGames();

    }
    protected override void OnFinished()
    {
        SendToServerJob sendToServerJob = new SendToServerJob();

        if (OutputRunningGameInfo != null)
        {
            VRCommand cmd = new VRCommand(Enums.ControlMessage.UNITY_DASHBOARD_GETRUNNINGGAMES, OutputRunningGameInfo);
            sendToServerJob.connectionInfo = connectionInfo;
            sendToServerJob.command = cmd;
            sendToServerJob.Start();

        }
    }

    private void GetRunningGames()
    {
        RunningGameInfo runningGameInfo = new RunningGameInfo();

        List<AppInfo> lAppInfo = new List<AppInfo>();


        CVRApplications app = OpenVR.Applications;
        StringBuilder sbAppkey = new System.Text.StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);
        StringBuilder sbLaunchType = new System.Text.StringBuilder((Int32)OpenVR.k_unMaxPropertyStringSize);
        StringBuilder sbBinaryPath = new System.Text.StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);

        uint appCount = app.GetApplicationCount();

        for (uint i = 0; i < appCount; i++)
        {
            sbAppkey.Length = 0; sbAppkey.Capacity = 0;
            sbLaunchType.Length = 0; sbLaunchType.Capacity = 0;
            sbAppkey = new StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);
            sbLaunchType = new StringBuilder((Int32)OpenVR.k_unMaxPropertyStringSize);
            sbBinaryPath = new System.Text.StringBuilder((int)OpenVR.k_unMaxApplicationKeyLength);

            EVRApplicationError err = app.GetApplicationKeyByIndex(i, sbAppkey, OpenVR.k_unMaxApplicationKeyLength);

            string appkey = sbAppkey.ToString();

            uint procId = app.GetApplicationProcessId(appkey);

            app.GetApplicationPropertyString(appkey, EVRApplicationProperty.LaunchType_String, sbLaunchType, OpenVR.k_unMaxPropertyStringSize, ref err);
            app.GetApplicationPropertyString(appkey, EVRApplicationProperty.BinaryPath_String, sbBinaryPath, OpenVR.k_unMaxPropertyStringSize, ref err);

            bool isDashboard = app.GetApplicationPropertyBool(appkey, EVRApplicationProperty.IsDashboardOverlay_Bool, ref err);

            string selfName = Process.GetCurrentProcess().MainModule.FileName;

            if (sbLaunchType.ToString() == "binary" && !isDashboard && procId > 0 && sbBinaryPath.ToString() != selfName)
            {
                //fileN = Process.GetProcessById((int)procId).MainModule.FileName;
                //Debug.Log(appkey + "|||" + procId + "|||" + sbBinaryPath.ToString() + "|||" + fileN);

                AppInfo appInfo = new AppInfo((int)procId, sbBinaryPath.ToString());

                lAppInfo.Add(appInfo);
            }
        }

        runningGameInfo.RunningGames = lAppInfo;

        OutputRunningGameInfo = runningGameInfo;

    }
}