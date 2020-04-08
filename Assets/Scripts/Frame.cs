using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] Frame[] sideFrames;

    public void OnSideFrames()
    {
        foreach(var sideFrame in sideFrames)
        {
            if (sideFrame == null)
                return;

            if (!sideFrame.gameObject.activeSelf)
                sideFrame.gameObject.SetActive(true);
        }
    }
}
