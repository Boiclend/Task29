// Программа должна сортировать массивы двумя способами. Заполнение массивов выполнять автоматически, 
// с помощью генератора случайных чисел rand. Каждый алгоритм сортировки оформить как отдельную функцию, 
// которая возвращает значение характеризуемое трудоемкость алгоритма (например, количество сравнений чисел или время, которое было потрачено на сортировку).
// Выполнить сравнение алгоритмов на предмет эффективности.
// Сортировка выбором. Сначала выполняется поиск  минимального элемента в массиве, после чего сохраняется во временную переменную.
// Затем этот элемент удаляется в массиве, а все последующие за ним элементы передвигаются на одну позицию влево. 
// После этого сохраненный элемент заносится  в  последнюю позицию, которая освободилась после сдвига элементов влево.
// Шейкер-сортировка. Движение в прямом и обратном направлениях организовать с помощью одного цикла.

int[] FillArray(int[] arr) 
{
    Random rnd = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rnd.Next(1,9);
    }
    return arr;
}

int[] SortArrayChoiceMethod(int[] arr)
{
    int temp = 0;
    DateTime StartChoice = new DateTime();
    DateTime EndChoice = new DateTime();
    StartChoice = DateTime.Now;
    Console.WriteLine($"Старт сортировки время в милисекундах - {StartChoice.Millisecond}");
    for (int i = 0; i < arr.Length - 1; i++)
    {
        int min = i;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if(arr[min] > arr[j]) 
            {
                min = j;
            }
        }
        temp = arr[min];
        arr[min] = arr[i];
        arr[i] = temp;
    }
    EndChoice = DateTime.Now;
    Console.WriteLine($"Конец сортировки время в милисекундах - {EndChoice.Millisecond}");
    return arr;
}

int[] SortArrayShakerMethod(int[] arr)
{
    int b = 0;
    int l = 0;
    int r = arr.Length - 1;
    DateTime StartShake = new DateTime();
    DateTime EndShake = new DateTime();
    StartShake = DateTime.Now;
    Console.WriteLine($"Старт сортировки время в милисекундах - {StartShake.Millisecond}");
    while(l < r)
    {
        for (int i = l; i < r; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                b = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = b;
                b= i;
            }
        }
        r = b;
        if (l >= r)
        {
            break;
        } 
        for (int i = r; i > l; i--)
        {
            if (arr[i-1] > arr[i])
            {
                b = arr[i];
                arr[i] = arr[i-1];
                arr[i -1] = b;
                b = i;
            }
        }
        l = b;
    }
    EndShake = DateTime.Now;
    Console.WriteLine($"Конец сортировки время в милисекундах - {EndShake.Millisecond}");
    return arr;
}

void PrintArray(int[] arr) 
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);
    }
}

Console.WriteLine("Введите размер массива");
int size = int.Parse(Console.ReadLine());
int[] ArrayForShake = new int[size];
int[] ArrayForChoice = new int[size];
Console.WriteLine();
Console.WriteLine("Сортировка методом шейкера");
FillArray(ArrayForShake);
PrintArray(ArrayForShake);
Console.WriteLine();
SortArrayShakerMethod(ArrayForShake);
PrintArray(ArrayForShake);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Сортировка методом выбора");
FillArray(ArrayForChoice);
PrintArray(ArrayForChoice);
Console.WriteLine();
SortArrayChoiceMethod(ArrayForChoice);
PrintArray(ArrayForChoice);