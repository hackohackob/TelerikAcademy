public class Chef
{
    
    private Carrot GetCarrot()
    {
        //...
    }

    private Potato GetPotato()
    {
        //...
    }

    private void Peel(Vegetable vegetable)
    {
        //...
    }
    private void Cut(Vegetable vegetable)
    {
        //...
    }

    private Bowl GetBowl()
    {
        //... 
    }
    public void Cook()
    {
        Bowl bowl=GetBowl();

        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);
        bowl.Add(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);
    }
}