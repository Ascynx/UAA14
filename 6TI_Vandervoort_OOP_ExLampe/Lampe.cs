namespace _6TI_Vandervoort_OOP_ExLampe;

public class Lampe
{
    private string _code;
    private bool _estActif = false;
    private int _couleur;

    public Lampe(string code, int couleur)
    {
        _code = code;
        _couleur = couleur;
    }

    public int GetCouleur()
    {
        return _couleur;
    }

    public string GetCode()
    {
        return _code;
    }

    public void SetActif(bool estActif)
    {
        _estActif = estActif;
    }

    public bool getActif()
    {
        return _estActif;
    }

    public override string ToString()
    {
        return "code: " + _code + ", couleur: " + _couleur + ", actif: " + _estActif;
    }
}