public class CheesePizza : Pizza
{
    public string Name
    {
        get => "CheesePizza";
    }
    
    public string Sauce1
    {
        get
        {
            return "Tomato Sauce";
        }
    }
    
    public string Sauce2
    {
        get => "Tomato Sauce";
    }
    
    public string Sauce3 => "Tomato Sauce";
}