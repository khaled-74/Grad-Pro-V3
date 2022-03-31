using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;//, ringHealthBar;
                           // public Image[] healthPoints;

    public   float health; 
    float maxHealth = 100f;
    float lerpSpeed =0.1f;

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
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) { Heal(10f); }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) { Damage(10f); }
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
            health -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
    }
}