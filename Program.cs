// Задача: Написать программу, которая из имеющегося массива строк, формирует массив строк, 
// длина которых, меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, 
// либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться 
// коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// ["hello", '2', "world", ":-)"] -> ["2", ":-)"]
// ["1234", "1567", "-2", "computer science"] -> ["-2"]


const int maxLength = 3;

string[] array = SetArray();
string[] selectionArray = SelectionArray(value: array,
                               maxStringLength: maxLength);
Console.WriteLine();
Console.WriteLine($"[{ArrayToString(array)}] -> [{ArrayToString(selectionArray)}]");
Console.WriteLine();


/// <summary>
/// Преобразование массива значений типа string в строку
/// </summary>
/// <param name="value">Массив значений</param>
/// <returns>Строка значений массива</returns>
string ArrayToString(string[] value)
{
    string result = string.Empty;
    for (int i = 0; i < value.Length; i++)
    {
        if (i + 1 != value.Length)
        {
            result += $"\"{value[i]}\", ";
        }
        else
        {
            result += $"\"{value[i]}\"";
        }
    }
    return result;
}


/// <summary>
/// Сортировка значений типа string в зависимости от длины
/// </summary>
/// <param name="value">Массив значений</param>
/// <param name="maxStringLength">Максимальная длина строки</param>
/// <returns>Отсортированный массив</returns>
string[] SelectionArray(string[] value, int maxStringLength)
{
    string[] result = new string[0];
    foreach (string element in value)
    {
        if (element.Length <= maxStringLength)
        {
            Array.Resize(ref result, result.Length + 1);
            result[result.Length - 1] = element;
        }
    }
    return result;
}


/// <summary>
/// Заполнение массива значениями типа string
/// </summary>
/// <returns>Массив значений типа string</returns>
string[] SetArray()
{
    string[] result = new string[0];
    string strValue = string.Empty;
    while (true)
    {
        Console.WriteLine($"Введите значение [{result.Length}] (Для окончания цикла ввода нажмите Esc):");
        strValue = ReadFromConsole();
        if (strValue == string.Empty)
        {
            Console.WriteLine("Нажали Esc, выходим из цикла ввода массива");
            break;
        }
        Array.Resize(ref result, result.Length + 1);
        result[result.Length - 1] = strValue;
    }
    return result;
}


/// <summary>
/// Чтение строки с консоли и фиксация нажатия кнопки Esc
/// </summary>
/// <returns>Строка string или string.Empty если нажали Esc</returns>
string ReadFromConsole()
{
    string result = string.Empty;
    while (true)
    {
        var k = Console.ReadKey(true);
        switch (k.Key)
        {
            case ConsoleKey.Backspace:
                if (result.Length > 0)
                {
                    result = result.Remove(startIndex: result.Length - 1, count: 1);
                    Console.Write(value: $"{k.KeyChar} {k.KeyChar}");
                }
                break;
            case ConsoleKey.Enter:
                if (result != string.Empty)
                {
                    Console.WriteLine();
                    return result;
                }
                else
                {
                    break;
                }
            case ConsoleKey.Escape:
                return string.Empty;
            default:
                Console.Write(value: k.KeyChar);
                result += k.KeyChar;
                break;
        }
    }
}

