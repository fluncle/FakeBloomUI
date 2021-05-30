using UnityEngine;

public class FakeBloomDemoScene : MonoBehaviour
{
    private static readonly int ANIM_PARAM_IS_SELECTED = Animator.StringToHash("IsSelected");

    [SerializeField]
    private Transform _camera;

    [SerializeField]
    private Animator _cursor;

    [SerializeField]
    private Animator[] _icons;

    private Animator _selectedIcon;

    public void SelectIcon(Animator icon)
    {
        if(_selectedIcon != null)
        {
            _selectedIcon.SetBool(ANIM_PARAM_IS_SELECTED, false);
        }
        icon.SetBool(ANIM_PARAM_IS_SELECTED, true);
        _selectedIcon = icon;

        var localPosition = _cursor.transform.localPosition;
        localPosition.x = icon.transform.localPosition.x;
        _cursor.transform.localPosition = localPosition;
    }

    private void Update()
    {
        var eulerAngles = _camera.eulerAngles;
        eulerAngles.y += Time.deltaTime * 3f;
        _camera.eulerAngles = eulerAngles;
    }
}