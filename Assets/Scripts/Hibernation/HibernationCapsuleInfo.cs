public enum CapsuleStatus
{
    UnFreezed,
    Opened,
    Empty,
    Freezed,
    UnPlugged,
    Broken
}

public class HibernationCapsuleInfo
{
    private CharacterInfo _character;

    public CharacterInfo Character
    {
        get { return _character; }
        set { _character = value; }
    }

    public CapsuleStatus Status { get; set; }

    public HibernationCapsuleInfo()
    {
        Status = CapsuleStatus.UnFreezed;
    }
 
    public void RollStatus()
    {
        if (Status == CapsuleStatus.Freezed || Status == CapsuleStatus.Empty)
        {
            Status = CapsuleStatus.UnFreezed;
        }
    }
}

