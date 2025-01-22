using ArtForAll.Shared.ErrorHandler;
using helpers.Elementos;

public class Balancer 
{
    private Elemento elemento;

    public Balancer() 
    {
        this.elemento = new Elemento();
    }

    public bool AddElements(string input) 
    {
        bool isValid = true;
        foreach(char elem in input)
        {
            isValid = elemento.AddElement(elem);
            if(isValid == false)
            {
                return isValid; 
            }
        }

        return isValid;
    }

    internal bool Evaluate(string input)
    {
        bool isValid = true;
        isValid = this.AddElements(input);

        if (isValid is false)
        {
            return isValid;
        }

        isValid = elemento.Evaluate();

        return isValid;
    }
}