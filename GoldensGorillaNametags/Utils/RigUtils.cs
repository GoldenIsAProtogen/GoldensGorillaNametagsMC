using System;
using Photon.Pun;

namespace GoldensGorillaNametags.Utils;

public static class RigUtils
{
    // ReSharper disable once InconsistentNaming
    public static int ping(this VRRig rig)
    {
        try
        {
            CircularBuffer<VRRig.VelocityTime> history = rig.velocityHistoryList;
            if (history != null && history.Count > 0)
            {
                double ping = Math.Abs((history[0].time - PhotonNetwork.Time) * 1000);
                ping = Math.Clamp(Math.Round(ping), 0, int.MaxValue);

                return (int)ping;
            }
        }
        catch
        {
            // ignored
        }

        return int.MaxValue;
    }
}