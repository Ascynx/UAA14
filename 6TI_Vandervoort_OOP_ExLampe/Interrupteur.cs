using System.Collections;

namespace _6TI_Vandervoort_OOP_ExLampe;

public class Interrupteur
{
    private readonly string _code;

    private bool _estActif = false;
    private string? _codeLampe = null;

    public string CodeLampe
    {
        get
        {
            return _codeLampe;
        }
        set
        {
            _codeLampe = value;
        }
    }

    public string Code
    {
        get
        {
            return _code;
        }
    }

    public bool Actif
    {
        get
        {
            return _estActif;
        }
    }

    public Interrupteur(string code)
    {
        _code = code;
    }

    public void switchStatut(Lampe? lampe)
    {
        _estActif = !_estActif;
        if (lampe != null && (_codeLampe != null && lampe.Code == _codeLampe))
        {
            //seulement si la lampe donnée est non nulle et est la même que la lampe liée à cet interrupteur.
            lampe.Actif = _estActif;
        }
    }
    
    public override string ToString()
    {
        return "code: " + _code + ", actif: " + _estActif + ", code lampe: " + _codeLampe;
    }
}