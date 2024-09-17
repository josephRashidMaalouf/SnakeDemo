
//Förberedelser

//Jag hårdkodar in maten bara för att hålla det simpelt
var foodPosition = new Coordinate
{
    X = 5,
    Y = 5
};
Console.SetCursorPosition(foodPosition.X, foodPosition.Y);
Console.Write('¤');
Console.SetCursorPosition(0, 0);

//Skapa ormen
var snake = new Snake();

//Jag vill att ormen startar på 0,0 och att den börjar med tre kroppsdelar
snake.Body.Enqueue(new Coordinate { X = 0, Y = 0 });
snake.Body.Enqueue(new Coordinate { X = 1, Y = 0 });
snake.Body.Enqueue(new Coordinate { X = 2, Y = 0 });

//Rita ut ormen
foreach (var coordinate in snake.Body)
{
    Console.SetCursorPosition(coordinate.X, coordinate.Y);
    Console.Write('@');
}

while (true)
{

    ConsoleKeyInfo cki = new ConsoleKeyInfo();
    if (Console.KeyAvailable == false)
    {
        cki = Console.ReadKey();
    }
    if (cki.Key == ConsoleKey.LeftArrow)
    {
        var newHeadPosition = new Coordinate
        {
            X = -1,
            Y = 0
        };
        snake.Move(newHeadPosition, foodPosition);

    }
    else if (cki.Key == ConsoleKey.RightArrow)
    {
        var newHeadPosition = new Coordinate
        {
            X = 1,
            Y = 0
        };
        snake.Move(newHeadPosition, foodPosition);


    }
    else if (cki.Key == ConsoleKey.UpArrow)
    {
        var newHeadPosition = new Coordinate
        {
            X = 0,
            Y = -1
        };
        snake.Move(newHeadPosition, foodPosition);


    }
    else if (cki.Key == ConsoleKey.DownArrow)
    {
        var newHeadPosition = new Coordinate
        {
            X = 0,
            Y = 1
        };
        snake.Move(newHeadPosition, foodPosition);

    }
}

public class Coordinate()
{
    public int X;
    public int Y;
}

public class Snake()
{
    public Queue<Coordinate> Body = new Queue<Coordinate>();

    //Head är den första kroppsdelen, det vill säga den kroppsdel som står längst bak i kön
    public Coordinate Head => Body.Last();
    public void Move(Coordinate newHeadPosition, Coordinate foodPosition)
    {
        var newHead = new Coordinate
        {
            X = Head.X + newHeadPosition.X,
            Y = Head.Y + newHeadPosition.Y
        };
        //Här kan det vara lämpligt att kolla ifall det nya huvudets position krocker med kroppen eller väggen
        //Jag kommer strunta i detta för att hålla det simpelt

        //Ställ det nya huvuden längst bak i kön
        Body.Enqueue(newHead);

        //Rita ut det nya huvudet
        Console.SetCursorPosition(newHead.X, newHead.Y);
        Console.Write('@');

        //Kolla om mat finns på den nya positionen 
        bool foodOnNextPosition = newHead.X == foodPosition.X && newHead.Y == foodPosition.Y;




        //Om ormen har INTE har ätit, tar vi bort den sista kroppsdelen(svansen) som är längst fram i kön
        if (foodOnNextPosition == false)
        {
            var tail = Body.Dequeue();
            Console.SetCursorPosition(tail.X, tail.Y);
            Console.Write(' ');
        }
        else
        {
            //Här kan ni lägga in vad ni vill ska hända med maten.
            //Jag kommer strunta i detta. I programmet kommer maten bli osynlig,
            //men ändå finnas kvar. Prova gå över samma ruta fler gånger och se ormen växa
        }

    }
}