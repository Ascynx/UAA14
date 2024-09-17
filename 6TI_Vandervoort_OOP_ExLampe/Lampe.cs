namespace _6TI_Vandervoort_OOP_ExLampe;

public class Lampe
{
    private string _code;
    private bool _estActif = false;
    private int _couleur;

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
        set
        {
            _estActif = value;
        }
    }

    public int Couleur
    {
        get
        {
            return _couleur;
        }
    }

    public Lampe(string code, int couleur)
    {
        _code = code;
        _couleur = couleur;
    }

    public override string ToString()
    {
        return "code: " + _code + ", couleur: " + _couleur + ", actif: " + _estActif;
    }
}