using UnityEngine;
using Valve.VR;

public class LevelManager : MonoBehaviour
{
    public SteamVR_Action_Boolean anyKeyAction;
    public delegate void AnyKeyEventHandler();
    public event AnyKeyEventHandler OnAnyKey;

    private void Start()
    {
        anyKeyAction.AddOnStateDownListener(OnAnyKeyDown, SteamVR_Input_Sources.Any);
    }

    private void OnAnyKeyDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (OnAnyKey != null)
        {
            OnAnyKey.Invoke();
        }
    }
}
