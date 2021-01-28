using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;


public class VRInputModule : BaseInputModule
{

    public Camera camera;
    public SteamVR_Input_Sources targetSource;
    public SteamVR_Action_Boolean clickAction;

    private GameObject currentObject = null;
    private PointerEventData data = null;
    

    protected override void Awake()
    {
        base.Awake();

        data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        data.Reset();
        data.position = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2);
        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        currentObject = data.pointerCurrentRaycast.gameObject;

        m_RaycastResultCache.Clear();

        HandlePointerExitAndEnter(data, currentObject);

        if (clickAction.GetStateDown(targetSource))
        {
            ProcessPress(data);
        }

        if (clickAction.GetStateUp(targetSource))
        {
            ProcessRelease(data);
        }
    }

    public PointerEventData GetData()
    {
        return (data);
    }

    private void ProcessPress(PointerEventData data)
    {
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(currentObject, data, ExecuteEvents.pointerDownHandler);

        if (newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);
        }

        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = currentObject;
    }

    private void ProcessRelease(PointerEventData data)
    {
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        GameObject newPointerUp = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        if (data.pointerPress == newPointerUp)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        eventSystem.SetSelectedGameObject(null);

        data.pressPosition = Vector3.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
