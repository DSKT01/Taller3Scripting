﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Or : Root {

    bool exito;
    public override bool Action()
    {
        for (int i = 0; i < sons.Length; i++)
        {

            if (sons[i].Action())
            {
                exito = true;
                
   
                break;
            }
          
        }
        return exito;
    }
}
