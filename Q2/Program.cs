Console.WriteLine("Введите N: ");
int N = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите M: ");
int M = Convert.ToInt32(Console.ReadLine());
int Sum;
if (N<M){
    Sum = SumNaturalRange(N, M);
}
else{
    Sum = SumNaturalRange(M, N);
}
Console.WriteLine(Sum);


int SumNaturalRange(int N, int M){
    if (N <= M){
        return N+SumNaturalRange(N+1,M);
    }
    else{
        return 0;
    }
}
