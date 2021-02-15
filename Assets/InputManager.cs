using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string PlayerID = "Player1";
    protected Vector2 _primaryMovement = Vector2.zero;
    protected Vector2 _secondaryMovement = Vector2.zero;
    public bool SmoothMovement = true;
    protected string _axisHorizontal;
    protected string _axisVertical;
    protected string _axisSecondaryHorizontal;
    protected string _axisSecondaryVertical;
    protected string _axisShoot;
    protected string _axisShootSecondary;
    public Vector2 PrimaryMovement { get { return _primaryMovement; } }
    private void Initialize()
    {
        _axisHorizontal = PlayerID + "_Horizontal";
        _axisVertical = PlayerID + "_Vertical";
        _axisSecondaryHorizontal = PlayerID + "_SecondaryHorizontal";
        _axisSecondaryVertical = PlayerID + "_SecondaryVertical";
        _axisShoot = PlayerID + "_ShootAxis";
        _axisShootSecondary = PlayerID + "_SecondaryShootAxis";
    }
    private void Awake()
    {
        Initialize();
    }
    private void Update()
    {
        if (SmoothMovement)
        {
            _primaryMovement.x = Input.GetAxis(_axisHorizontal);
            _primaryMovement.y = Input.GetAxis(_axisVertical);
        }
        else
        {
            _primaryMovement.x = Input.GetAxisRaw(_axisHorizontal);
            _primaryMovement.y = Input.GetAxisRaw(_axisVertical);
        }
    }
}