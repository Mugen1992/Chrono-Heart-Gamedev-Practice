// Локальная манипуляция временем.
// При активации способности: создаём сферу-область, находим ITimeAffectable, меняем их локальный timescale.
// Для отката: у объектов с "PositionHistory" проигрываем буфер позиций назад N миллисекунд.

public class TimeManager : MonoBehaviour {
    // TODO: SpawnTimeSphere(position, radius, mode: Slow/Speed/Rewind, duration)
    // TODO: Register/Unregister ITimeAffectable
    // TODO: RewindObject(obj, msBack)
}
