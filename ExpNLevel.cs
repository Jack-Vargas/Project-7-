using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpNLevel : MonoBehaviour
{
    public int exp;
    public int level;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            exp++;
            ExpGet();
        }
    }

    public void ExpGet()
    {
        level = (int) Mathf.Clamp(exp / 10, 0, 5); // ok so clamp automaticaly limits a number to being between the max and min found
                                                   // in the middle and third part of the argument. here we devide the exp by ten so
                                                   // it only goes up every ten exp.
                                                   // this only works if the exp to level ratio is liniar. for example
                                                   // xp 1 = lv1, x2 = lv 2, xp 999 = lv 3. wont work
                                                    
    }

}
