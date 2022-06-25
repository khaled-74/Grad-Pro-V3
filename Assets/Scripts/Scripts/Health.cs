using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;//, ringHealthBar;
                           // public Image[] healthPoints;

    public GameObject looseMenuUI;

    public   float health; 
    float maxHealth = 100f;
    float lerpSpeed =0.1f;

    //Hit Effects
    public GameObject m_GotHitScreen;
   // public float hitFade= -0.01f;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = "Health: " + health + "%";
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

        if (m_GotHitScreen != null) 
        {
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0) 
            {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= 0.001f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }

    }

    void HealthBarFiller()
    {
        //healthBar.fillAmount = health / maxHealth;
          healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);
     //   ringHealthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

        //for (int i = 0; i < healthPoints.Length; i++)
        //{
        //    healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        //}
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
      //   ringHealthBar.color = healthColor;
    }

    //bool DisplayHealthPoint(float _health, int pointNumber)
    //{
    //    return ((pointNumber * 10) >= _health);
    //}

    public void Damage(float damagePoints)
    {
        if (health > 0)
        {
            health -= damagePoints;
            if (health == 0)
            {
                looseMenuUI.SetActive(true);
                Time.timeScale = 0f;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //Died condition 
            }
        }
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = 0.8f;
        m_GotHitScreen.GetComponent<Image>().color = color;

    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
    }
    
}