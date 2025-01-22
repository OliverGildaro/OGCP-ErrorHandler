
namespace helpers.Elementos;

public class Elemento
{
    private char openParen = '(';
    private char openBrack = '[';
    private char openKey = '{';
    private char closeParen = ')';
    private char closeBrack = ']';
    private char closeKey = '}';
    private char[] openElements;
    private char[] closeElements;

    public Elemento()
    {
        this.openElements = new char[3];
        this.closeElements = new char[3];
    }

    public bool AddElement(char element)
    {
        bool isValid = true;
        if(element == openParen || element == openBrack || element == openKey) 
        {
            isValid = isValidOpenElement(element);
        }else if(element == closeParen || element == closeBrack || element == closeKey){
            isValid = isValidCloseElement(element);
        }

        return isValid;
    }

    private bool isValidOpenElement(char element)
    {

        int i = 0; 
        bool isValid = true;
        if (openElements[i] == '\0')
        {
            this.openElements[i] = element;
            return isValid;
        }

        foreach (var current in openElements)
        {
            i++;
            if(current==element) 
            {
                isValid = false;
                break;
            } 

            if(isValidOpenOrder(current, element) && this.openElements[i] == '\0')
            {
                this.openElements[i] = element;
                break;
            }
        }

        return isValid;
    }

    private bool isValidCloseElement(char element)
    {
        int i = 0;
        bool isValid = true;
        if (closeElements[i] == '\0')
        {
            this.closeElements[i] = element;
            return isValid;
        }

        foreach (var current in closeElements)
        {
            i++;
            if (current == element)
            {
                isValid = false;
                break;
            }

            if (isValidCloseOrder(current, element) && this.openElements[i] == '\0')
            {
                this.closeElements[i] = element;
                break;
            }
        }

        return isValid;
    }

    private bool isValidOpenOrder(char existingChar, char newChar)
    {
        bool isValid = true;
        ElementsEnum? existingCharPriority = this.GetPriorityOpenChar(existingChar);
        ElementsEnum? newCharPriority = this.GetPriorityOpenChar(newChar);

        return IsValid(existingCharPriority, newCharPriority);
    }

    private bool isValidCloseOrder(char existingChar, char newChar)
    {
        bool isValid = true;
        ElementsEnum? existingCharPriority = this.GetPriorityOpenChar(existingChar);
        ElementsEnum? newCharPriority = this.GetPriorityOpenChar(newChar);

        return IsValid(newCharPriority, existingCharPriority);
    }

    private ElementsEnum? GetPriorityOpenChar(char element)
    {
        ElementsEnum? priority = null;

        if(element == openParen)
        {
            priority = ElementsEnum.PARENTHESYS;
        } else if(element == openBrack){
            priority = ElementsEnum.BRAQUETS;
        } else if(element == openKey) {
            priority = ElementsEnum.KEYS;
        }

        return priority;
    }

    private bool IsValid(ElementsEnum? firstElement, ElementsEnum? secondElement)
    {
        bool isValid = true;
        if(firstElement == null || secondElement == null) 
        {
            isValid = false;
        }

        if(firstElement > secondElement)
        {
            isValid = false;
        }
        
        return isValid;
    }

    private bool IsValidClose(ElementsEnum? firstElement, ElementsEnum? secondElement)
    {
        bool isValid = true;
        if (firstElement == null || secondElement == null)
        {
            isValid = false;
        }

        if (firstElement < secondElement)
        {
            isValid = false;
        }

        return isValid;
    }

    private ElementsEnum? GetPriorityCloseChar(char element)
    {
        ElementsEnum? priority = null;

        if(element == closeParen)
        {
            priority = ElementsEnum.PARENTHESYS;
        } else if(element == closeBrack){
            priority = ElementsEnum.BRAQUETS;
        } else if(element == closeKey) {
            priority = ElementsEnum.KEYS;
        }

        return priority;
    }

    public bool Evaluate()
    {

        bool isValid = false;

        if (openElements[0] != '\0' )
        {
            isValid = Validate(openElements[0], closeElements[2], ElementsEnum.PARENTHESYS);
        }
        if(openElements[1] != '\0')
        {
            isValid = Validate(openElements[1], closeElements[1], ElementsEnum.BRAQUETS);
        }
        if(openElements[2] != '\0')
        {
            isValid = Validate(openElements[2], closeElements[0], ElementsEnum.KEYS);
        }

        return isValid;
    }


    private bool Validate(char first, char second, ElementsEnum elements)
    {
        switch (elements)
        {
            case ElementsEnum.PARENTHESYS:
                return openElements[0] == openParen
                    && closeElements[2] == closeParen;
            case ElementsEnum.BRAQUETS:
                return openElements[1] == openBrack &&
                    closeElements[1] == closeBrack;
            case ElementsEnum.KEYS:
                return openElements[2] == openKey &&
                    closeElements[0] == closeKey;
            default:
                return false;
        }
    }

    private enum ElementsEnum
    {
        PARENTHESYS =1,
        BRAQUETS =2,
        KEYS =3,
    }
}