using UnityEngine;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;

    
    public int regenTime = 6;

    int currentResistance;

    private void Start()
    {
        currentResistance = maxResistance;
    }

    private void Update()
    {
        transform.localScale = new Vector3(8, 8 * currentResistance/ 5, 1);
    }

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    public void Damage(int damage)
    {
        currentResistance -= damage;
    }

    public void Regenerate()
    {
        currentResistance++;
    }
}