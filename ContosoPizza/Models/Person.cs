using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Person {
    public int Id {
        get;
        set;
    }

    [Required] public string? Name {
        get;
        set;
    }

    [Required] public string? Lastname {
        get;
        set;
    }

    [Required] public string? Zipcode {
        get;
        set;
    }

    [Required] public string? City {
        get;
        set;
    }

    [Required] public Color? color {
        get;
        set;
    }

    public enum Color {
        blau = 1,
        grün = 2,
        violett = 3,
        rot = 4,
        gelb = 5,
        türkis = 6,
        weiß = 7,
    }
}