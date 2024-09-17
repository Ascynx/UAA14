using System.Collections;

namespace _6TI_Vandervoort_OOP_ExLampe;

public class Interrupteur
{
    private string _code;

    private bool _estActif = false;
    private string? _codeLampe = null;

    public Interrupteur(string code)
    {
        _code = code;
    }
    
    public string GetCode()
    {
        return _code;
    }

    public bool GetActif()
    {
        return _estActif;
    }

    public void switchStatut(Lampe? lampe)
    {
        _estActif = !_estActif;
        lampe?.SetActif(_estActif);
    }

    public string? GetCodeLampe()
    {
        return _codeLampe;
    }

    public void SetCodeLampe(string codeLampe)
    {
        _codeLampe = codeLampe;
    }
    
    public override string ToString()
    {
        return "code: " + _code + ", actif: " + _estActif + ", code lampe: " + _codeLampe;
    }
}