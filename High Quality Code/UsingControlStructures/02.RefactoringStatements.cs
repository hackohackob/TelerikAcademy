class RefactoringStatements
{
    Potato potato=GetPotato();
    //... 
    if(potato != null)
    {
        if(potato.HasNotBeenPeeled || potato.IsRotten)
        {
            throw new VegetableException();
        }

	    Cook(potato);
    }


    if (x >= MIN_X && x <= MAX_X &&
        y >= MIN_Y && y <= MAX_Y && 
        canVisitCell)
    {
        VisitCell();
    }    
}

