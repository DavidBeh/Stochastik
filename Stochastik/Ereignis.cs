namespace Stochastik;

public class Ereignis
{
    private readonly char _symbol;


    public Ereignis(char symbol)
    {
        _symbol = symbol;
    }
    
    
    private List<Ereignis> _ereignisList = new();

}