Console.WriteLine("Введите N: ");
int N = Convert.ToInt32(Console.ReadLine());
NcounterToOne(N);

void NcounterToOne(int N){
    Console.Write(N);
    if (N!= 1){
        Console.Write(", ");
        NcounterToOne(N-1);
    }
}