﻿using System.Collections.Generic;
using Invert.uFrame.MVVM;

public class InteractiveTutorials : uFrameMVVMPage
{
    public override string Name
    {
        get { return "Interactive Tutorials (Experimental)"; }
    }
    
    public override decimal Order
    {
        get { return -2; }
    }
}