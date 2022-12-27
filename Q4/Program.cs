Console.WriteLine("(Можно хоть 200 если влезет на экран)");
Console.WriteLine("Введите M: ");
int M = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите N: ");
int N = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("По рекурсии ");
int[,] array = new int[M,N];
int SizeX = array.GetLength(0);
int SizeY = array.GetLength(1);
Array2DPrint(SpiralFillRecursive(array,SizeX,SizeY));

Console.WriteLine();
Console.WriteLine("По ссылкам ");
int[,] SecondArray = new int[M,N];
Array2DPrint(SpiralFillNormal(SecondArray));


// Я честно тут уже начал эксперементировать с рекурсией. Заполняет внешнюю стенку и переходит к следующей незаполненной "стенке".
// Не спрашивайте почему это вообще существует через рекурсию =)
int[,] SpiralFillRecursive(int[,] array, int SizeX, int SizeY, int StartingSum = 1, int StartX = 0, int StartY = 0){
    int TempStY = StartY;
    int TempStX = StartX;
    for(; TempStY<SizeY; TempStY++){ // Верхняя линия
        array[TempStX,TempStY] = StartingSum++;
    }
    TempStY--;

    for(TempStX+=1; TempStX<SizeX; TempStX++){ // Правая линия
        array[TempStX,TempStY] = StartingSum++;
    }
    TempStX--;

    for(TempStY = SizeY-2; TempStY>=StartY;TempStY--){ // Нижняя линия
        array[TempStX,TempStY] = StartingSum++;
    }
    TempStY++;

    for(int SizeXtemp = SizeX-2; SizeXtemp>StartX;SizeXtemp--){ // Левая линия
        array[SizeXtemp,TempStY] = StartingSum++;
    }

    SizeX -=1;
    SizeY -=1;
    if (SizeX >=1 && SizeY > 1){
        SpiralFillRecursive(array,SizeX,SizeY, StartingSum, StartX+1,StartY+1); // След. Внутренний блок
    }
    return array;
}


// А тут я баловался с указателями
int[,] SpiralFillNormal(int[,] array){
    int CoordX = array.GetLength(0)-1;
    int CoordY = array.GetLength(1);
    int PointX = 0;
    int PointY = 0;
    int Sum = 1;
    ref int Line = ref CoordY;
    ref int OtherLine = ref CoordX;
    ref int TempLine = ref CoordY;
    ref int LineMover = ref PointY;
    ref int OtherMover = ref PointX;
    ref int TempMover = ref PointY;
    int County = 0;
    int Change = 0;
    int Additive = 1;
    while (Sum != (array.GetLength(0)*array.GetLength(1))+1){
        if (County!=Line){
            array[PointX,PointY] = Sum++;
            LineMover += Additive;
            County++;
        }
        if (County==Line){
            County = 0;
            LineMover = LineMover + (Additive*-1); //make the Place smaller then lenght
            //replace coordLine
            TempLine = ref Line; // t => y
            Line = ref OtherLine; // y => x,
            OtherLine = ref TempLine; // x => y-1
            OtherLine = OtherLine -1;
            //replace coodfiller
            TempMover = ref LineMover;
            LineMover = ref OtherMover;
            OtherMover = ref TempMover;
            LineMover = LineMover+Additive; // Make the new Place skip first item 
            // When x changes to y, now do -1 instead of 1. and take 2 steps back (like from 4 to 2)
            if (Change == 0){
                Change++; 
            }
            else{ 
                Change--;
                LineMover = LineMover + (Additive*-2);
                Additive = Additive* -1;
            }
        }
    }
    return array;
}


void Array2DPrint(int[,] matrix){
    for (int i = 0; i<matrix.GetLength(0); i++){
        for (int j = 0; j < matrix.GetLength(1); j++){
            Console.Write(matrix[i,j] + " ");
        }
        Console.WriteLine();
    }
}

