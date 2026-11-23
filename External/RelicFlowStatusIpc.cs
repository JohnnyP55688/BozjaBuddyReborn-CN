using System;
using BozjaBuddyReborn.Automation;
using Dalamud.Plugin;
using Dalamud.Plugin.Ipc;

namespace BozjaBuddyReborn.External;

/// <summary>Read-only status contract consumed by RelicFlow.</summary>
public sealed class RelicFlowStatusIpc : IDisposable
{
    private readonly ICallGateProvider<int> _apiVersion;
    private readonly ICallGateProvider<bool> _isRunning;
    private readonly ICallGateProvider<string> _getStatus;
    private readonly ICallGateProvider<string> _getState;

    public RelicFlowStatusIpc(IDalamudPluginInterface pi, BozjaController controller)
    {
        _apiVersion = pi.GetIpcProvider<int>("BozjaBuddyReborn.ApiVersion");
        _isRunning = pi.GetIpcProvider<bool>("BozjaBuddyReborn.IsRunning");
        _getStatus = pi.GetIpcProvider<string>("BozjaBuddyReborn.GetStatus");
        _getState = pi.GetIpcProvider<string>("BozjaBuddyReborn.GetState");
        _apiVersion.RegisterFunc(() => 1);
        _isRunning.RegisterFunc(() => controller.Running);
        _getStatus.RegisterFunc(() => controller.Status);
        _getState.RegisterFunc(() => controller.State.ToString());
    }

    public void Dispose()
    {
        _apiVersion.UnregisterFunc();
        _isRunning.UnregisterFunc();
        _getStatus.UnregisterFunc();
        _getState.UnregisterFunc();
    }
}
