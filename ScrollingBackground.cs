using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Transform cameraTransform;         // カメラのTransform
    public float backgroundWidth = 20f;       // 背景1枚の横幅

    private Transform[] backgrounds;          // 子背景の配列

    void Start()
    {
        // 子オブジェクト（背景）を取得
        int childCount = transform.childCount;
        backgrounds = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            float distance = cameraTransform.position.x - bg.position.x;

            if (Mathf.Abs(distance) >= backgroundWidth)
            {
                // カメラから離れた背景を反対側に移動
                float direction = Mathf.Sign(distance);
                bg.position += new Vector3(backgroundWidth * backgrounds.Length * direction, 0f, 0f);
            }
        }
    }
}