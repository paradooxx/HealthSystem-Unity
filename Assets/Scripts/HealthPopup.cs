using TMPro;
using UnityEngine;

public class HealthPopup : MonoBehaviour
{
    // set these values according to your game settings
    [SerializeField] private float textMoveSpeed = 4f;
    [SerializeField] private float disappearTime = 1f;
    [SerializeField] private float disappearSpeed = 1f;

    private TMP_Text popUpText;
    private Color textColor;

    // call this function when you need to create healthPopup for damage or healing
    public static HealthPopup Create(Transform healthPopUpObject, Vector2 position, float healthAmount, bool isDamage)
    {
        Transform healthPopupTransform = Instantiate(healthPopUpObject, position, Quaternion.identity);

        HealthPopup healthPopup = healthPopupTransform.GetComponent<HealthPopup>();
        healthPopup.Setup(healthAmount, isDamage);

        return healthPopup;
    }

    private void Awake()
    {
        popUpText = GetComponent<TMP_Text>();
    }

    private void Setup(float damageAmount, bool isDamage)
    {
        //isDamage is used to check whether the player is taking damage or healing
        if(isDamage)
        {
            popUpText.text = "-" + damageAmount.ToString();
            popUpText.color = Color.red;
            textColor = popUpText.color;
        }
        else
        {
            popUpText.text = "+" + damageAmount.ToString();
            popUpText.color = Color.green;
            textColor = popUpText.color;
        }
    }

    private void Update()
    {
        //you can add your own customization to the popup effects
        transform.position += new Vector3(0, textMoveSpeed) * Time.deltaTime;

        disappearTime -= Time.deltaTime;
        if(disappearTime < 0)
        {
            textColor.a -= disappearSpeed * Time.deltaTime;
            popUpText.color = textColor;

            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
