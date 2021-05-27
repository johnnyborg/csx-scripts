var rand = new Random();

for (int i = 0; i < 50; i++)
{
    
    var b = rand.Next(1, 11);
    Console.Write($"{b}: ");
    Console.WriteLine(b % 5 == 0 ? "Y" : "N");
}
