public class Shape
{
    private string _color;
    //getter of color
    public string GetColor()
    {
        return _color;
    }
    //setter of color
    public void SetColor(string color)
    {
        _color = color;
    }
    //constructor that accepts a color and sets it
    public Shape(string color)
    {
        _color = color;
    }

    public virtual double GetArea(){
        return -1;
    }


}