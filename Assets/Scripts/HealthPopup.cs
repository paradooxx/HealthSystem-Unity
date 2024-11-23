using TMPro;
using UnityEngine;

public class HealthPopup : MonoBehaviour
{
    [SerializeField] private float textMoveSpeed = 4f;
    [SerializeField] private float disappearTime = 1f;
    [SerializeField] private float disappearSpeed = 1f;

    private TMP_Text popUpText;
    private Color textColor;

    public static HealthPopup Create(Transform healthPopUpObject, Vector2 position, float damageAmount)
    {
        Transform healthPopupTransform = Instantiate(healthPopUpObject, position, Quaternion.identity);

        HealthPopup healthPopup = healthPopupTransform.GetComponent<HealthPopup>();
        healthPopup.Setup(damageAmount);

        return healthPopup;
    }

    private void Awake()
    {
        popUpText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        textColor = popUpText.color;
    }

    private void Setup(float damageAmount)
    {
        popUpText.text = damageAmount.ToString();
    }

    // private void Start()
    // {
    //     popUpText.text = "-100".ToString();
    // }

    private void Update()
    {
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
