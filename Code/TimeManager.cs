using UnityEngine;
using System.Collections.Generic;

public enum TimeMode { Slow, Speed, Rewind }

public class TimeManager : MonoBehaviour {
    public float slowFactor = 0.5f;
    public float speedFactor = 1.5f;
    public float duration = 3f;

    public void SpawnTimeSphere(Vector3 position, float radius, TimeMode mode) {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
        foreach (var col in colliders) {
            ITimeAffectable obj = col.GetComponent<ITimeAffectable>();
            if (obj != null) {
                switch (mode) {
                    case TimeMode.Slow:
                        obj.SetTimeScale(slowFactor, duration);
                        break;
                    case TimeMode.Speed:
                        obj.SetTimeScale(speedFactor, duration);
                        break;
                    case TimeMode.Rewind:
                        obj.Rewind(1.5f); // 1.5 seconds back
                        break;
                }
            }
        }
    }
}
