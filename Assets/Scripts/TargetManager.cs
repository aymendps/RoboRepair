using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public TMP_InputField instructionText;
    public Button runItButton;

    private Movable _target = null;

    private void Update()
    {
        UpdateTarget();
        UpdateButton();
    }

    private void UpdateTarget()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
            Vector2.zero);

        if (!hit) return;
        if (!hit.transform.gameObject.CompareTag("Movable")) return;

        targetText.text = hit.transform.gameObject.name;
        _target = hit.transform.gameObject.GetComponent<Movable>();
    }

    private void UpdateButton()
    {
        runItButton.interactable = _target != null && !string.IsNullOrEmpty(instructionText.text);
    }

    public void RunIt()
    {
        // SetGravity acceleration
        // SetVelocity velocity
        // SetBounce bounce
        // SetForce impulse

        if (instructionText.text.Contains("SetVelocity ") && SpellManual.Instance.hasVelocity)
        {
            var variable = instructionText.text.Substring(instructionText.text.IndexOf("SetVelocity ") + 12);
            if (int.TryParse(variable, out var x))
            {
                _target.SetVelocity(x/2f);
            }
            else
            {
                Debug.Log("invalid number");
            }
        }
        else if (instructionText.text.Contains("SetGravity ") && SpellManual.Instance.hasGravity)
        {
            var variable = instructionText.text.Substring(instructionText.text.IndexOf("SetGravity ") + 11);
            if (variable.ToLower().Trim() == "true")
            {
                _target.SetGravity(true);
            }
            else if (variable.ToLower().Trim() == "false")
            {
                _target.SetGravity(false);
            }
            else
            {
                Debug.Log("invalid number");
            }
        } else if (instructionText.text.Contains("AddForce ") && SpellManual.Instance.hasForce)
        {
            var variables = instructionText.text.Substring(instructionText.text.IndexOf("AddForce ") + 9);
            if (variables.Trim().Length < 3)
            {
                Debug.Log("invalid length");
            }
            else
            {
                var spaceIndex = variables.Trim().IndexOf(" ");
                var stringX = variables.Substring(0, spaceIndex);
                var stringY = variables.Substring(spaceIndex + 1);
                if (int.TryParse(stringX, out var x) && int.TryParse(stringY, out var y))
                {
                    _target.AddForce(new Vector2(x, y));
                }
                else
                {
                    Debug.Log("invalid number");
                }
            }
        }
    }
}