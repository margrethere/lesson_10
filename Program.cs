// Создаём массив случайных строк
string[] CreateRandomStringArray(int ArrayLen, int StringMaxLen)
{
    string[] strings = new string[ArrayLen];

    for (int i = 0; i < ArrayLen; i++)
    {
        strings[i] = "";
        int CurrentStringLen = new Random().Next(3, StringMaxLen + 1);
        for (int j = 0; j < CurrentStringLen; j++)
        {
            int LowUp = new Random().Next(0, 2);
            
            if (LowUp == 0) 
            {
                strings[i] += (char) ('A' + new Random().Next(0, 26));
            } else
            {
                strings[i] += (char) ('a' + new Random().Next(0, 26));
            }
        }
    }

    return strings;
}

// Вывод массива строк
string ShowStringArray(string[] array)
{
    string result = "";
    int ArrayLen = array.Length;

    for (int i = 0; i < ArrayLen; i++)
    {
        result += array[i] + " ";
    }

    return result;
}

// Подсчёт строк массива, начинающихся с гласной буквы
int StringsBeginsWithVowelLetterCount(string[] array)
{
    int result = 0;
    int ArrayLen = array.Length;
    char[] VowelLetters = {'A', 'E', 'I', 'O', 'U', 'Y'};

    for (int i = 0; i < ArrayLen; i++)
    {
        char CurrentString = array[i].ToUpper()[0];     // Нас интересует только первая буква
        bool ThisLetter = false;                        // Предполагаем, что она не является гласной

        for (int j = 0; j < VowelLetters.Length; j++)
        {
            if (CurrentString == VowelLetters[j]) 
            {
                ThisLetter = true;                      // Всё-таки буква гласная
                break;                                  // Прерываем цикл
            }
        }
        if (ThisLetter) result++;
    }

    return result;
}

// Слияние парных строк
string[] MergingAdjacentStrings(string[] array)
{
    int ArrayLen = array.Length;
    int NewArrayLen = array.Length % 2 == 0 ? ArrayLen / 2 : ArrayLen / 2 + 1;
    string[] result = new string[NewArrayLen];
    int index = 0;

    for (int i = 0; i < ArrayLen - 1; i+= 2)
    {
        result[index++] = array[i] + array[i + 1];
    }

    // В том случае, если длина исходного массива нечётная
    if (ArrayLen / 2 < NewArrayLen) 
    {
        result[index] = array[ArrayLen - 1];
    }

    return result;
}


Console.Clear();
Console.WriteLine("-------------- Задача 1 --------------");

string[] StringArray = CreateRandomStringArray(ArrayLen: (new Random().Next(5, 11)), StringMaxLen: 5);
Console.WriteLine("Массив случайных строк : " + "\n" + ShowStringArray(StringArray));
Console.WriteLine("\nКоличество строк, начинающихся с гласной буквы : " + StringsBeginsWithVowelLetterCount(StringArray));

Console.WriteLine("\n-------------- Задача 2 --------------");
StringArray = CreateRandomStringArray(ArrayLen: (new Random().Next(5, 11)), StringMaxLen: 5);
Console.WriteLine("Исходный массив строк : " + "\n" + ShowStringArray(StringArray));
string[] NewStringArray = MergingAdjacentStrings(StringArray);
Console.WriteLine("\nНовый массив : " + "\n" + ShowStringArray(NewStringArray));
Console.WriteLine("\nДлина исходного массива = " + StringArray.Length);
Console.WriteLine("Длина нового массива = " + NewStringArray.Length);