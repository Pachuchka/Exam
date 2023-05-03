// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк,
// длина которых меньше, либо равна 3 символам. 
// Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
// При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

string [] ArrayDeclaration()
   {
        string [] newArray = {"это","массив","из строк","для","выполнения итогового задания","а это числа 1 2 36 7 4 <>"};
        return newArray;
   }

string [] NewRandomArray(string [] userArray)
    {
        
        int n = userArray.Length;
        string [] result = new string[n] ;
        int [] set = new int[n];
        var randomNum = new Random();
        for (int i = 0;i<n;i++)
        {
            set[i] =  randomNum.Next(0,2);
        }
        Hint_For_The_Reviewer(userArray, set, "массив строк, учавствовавших в результирующем массиве -> ");
        for (int j=0;j<n;j++)
        {
            result[j] = GenerateRandomSrting(userArray[j], set[j]);
        }
             
        return result;
    }    
string GenerateRandomSrting(string a, int b)
{
    string resultString = "";
    var randomNum = new Random();
    int n = a.Length;
    int [] symbols = new int[n];
    for (int i = 0;i<n;i++)
       {
           symbols[i] =  randomNum.Next(0,2);
       }
    for (int j=0;j<n;j++)
    {
        resultString = resultString + String.Concat(Enumerable.Repeat( a.Substring(j,1) , symbols[j]));
    }
    int randomLength = 0;
    if (resultString.Length>3)
    {
       randomLength =  randomNum.Next(1,4); 
    }
    else
    {
       randomLength =  randomNum.Next(1,resultString.Length+1);
    }
    resultString = String.Concat(Enumerable.Repeat(resultString.Substring(0,randomLength) , b));
    return resultString;
}

void PrintArray(string [] message)
{
    for (int i = 0; i<message.Length;i++)
	{
        if (message[i]!="")
        {
            Console.Write($" {message[i]};");
        }
        
    }
    
}

void Hint_For_The_Reviewer(string [] a, int [] b, string message)
{
    Console.WriteLine();
    Console.Write("Подсказка! Исходный массив: ");
    Console.Write("[");
    string str= string.Join("; ", a);
    Console.Write(str);
    Console.Write("]");
    Console.WriteLine();
    Console.Write(message);
    str = string.Join(" ", b);
    Console.Write(str);
    Console.WriteLine();
    Console.Write("Результат: ");
    Console.WriteLine();
    PrintArray(a);
    Console.Write(" -> ");
}

string [] myArray = ArrayDeclaration();
PrintArray(NewRandomArray(myArray));