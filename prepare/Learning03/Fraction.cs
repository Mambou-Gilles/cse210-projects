public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction(){
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber){
        _top = wholeNumber;
        _bottom =  1;
    }
    public Fraction(int top, int bottom){
        _top = top;
        _bottom = bottom;
    }
    public void Display(){
        var result = _top / _bottom;
        Console.WriteLine(result);
    }

    public int getTop(){
        return _top;
    }

    public void setTop(int top){
        _top = top;
    }
    public int getBottom(){
        return _bottom;
    }
    public void setBottom(int bottom){
        _bottom = bottom;
    }

    public string GetFractionString(){
        return $" {_top}/{_bottom}";
    }
    public double GetDecimalValue(){
        return (double)_top / (double)_bottom;
    }
    
}