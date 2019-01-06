using UnityEngine.Events;

// HandTargetを認識した時の動作
public class ImageController : DefaultTrackableEventHandler
{
    public UnityEvent OnTrackingAction; //マーカーを認識した時の処理
    public UnityEvent OffTrackingAction;//マーカーが外れた時の処理


    // マーカーが認識された場合の処理
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        OnTrackingAction.Invoke();
    }
    //マーカーが外された場合の処理
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        OffTrackingAction.Invoke();
    }
}
