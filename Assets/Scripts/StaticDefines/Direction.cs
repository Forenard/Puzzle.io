public class Direction
{
    public enum Type
    {
        up = 0,
        right = 1,
        down = 2,
        left = 3
    }
    public static (int,int,Type)[] DxDy=new (int,int,Type)[]{(0,1,(Type)0),(1,0,(Type)1),(0,-1,(Type)2),(-1,0,(Type)3)};
    public static Type Invert(Type dir){return (Type)(((int)dir+2)%4);}
}