using UnityEngine;

public class NewPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type.Equals("Normal"))
        {
            return new CheesePizza();
        }
        else if (type.Equals("Special"))
        {
            return new BulgogiPizza();
        }
        return null;
    }
}