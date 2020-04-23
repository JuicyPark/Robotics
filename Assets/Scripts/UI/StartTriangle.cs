using UnityEngine;
using UnityEngine.UI;

public class StartTriangle : MonoBehaviour
{

    [SerializeField]
    Image triangleImage;

    [SerializeField]
    Animator animator;

    Color randomColor = new Color(0.5f,0.5f,0.5f);
    public void GetReady(bool ready)
    {
        animator.SetBool("isActivated", ready);
    }
}
