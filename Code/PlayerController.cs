// Управление персонажем (Ког).
// Ввод: горизонталь, прыжок, dash.
// Прыжок: учитываем coyoteTime (~0.12s) и jumpBuffer (~0.1s).
// Wall-slide: снижение вертикальной скорости при касании стены.
// Dash: однонаправленный импульс + i-frames (~0.12s), КД 1.0s.

public class PlayerController : MonoBehaviour {
    // Параметры
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public float dashForce;
    public float dashCooldown;

    // TODO: HandleInput(), MoveHorizontal(), TryJump(), TryDash(), ApplyGravity()
    // TODO: GroundCheck() via raycast; WallCheck() for wall-slide
}
