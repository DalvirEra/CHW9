Console.WriteLine("Введите M: ");
int M = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите N: ");
int N = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("A = " + AkermanFunction(M,N));

int AkermanFunction(int m, int n){
    if (m == 0){
        return n+1; 
    }
    if (m > 0 && n == 0){
        return AkermanFunction(m-1,1);
    }
    if (m > 0 && n > 0){
        return AkermanFunction(m-1,AkermanFunction(m,n-1));
    }
    Console.WriteLine("Ошибка, возвращаю -1");
    return -1;
}