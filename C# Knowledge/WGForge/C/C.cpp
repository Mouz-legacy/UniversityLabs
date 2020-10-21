#include <iostream>

using namespace std;

char CountSymbol(int kValue, int sizeX, int sizeY)
{
    int size = sizeX > sizeY ? sizeX : sizeY;//k+1

    return '0';
}

int main()
{
    int kEnterValue = 0, tStringsAmount = 0, sizeX = 0, sizeY = 0;
    cin >> tStringsAmount;
    cin >> kEnterValue;
    char* SymbolsArray = new char[tStringsAmount];
    /* for (int i = 0; i < tStringsAmount; i++)
     {
         cin >> sizeX >> sizeY;
         SymbolsArray[i] = CountSymbol(kEnterValue, sizeX, sizeY);
     }*/
    int k = kEnterValue;
    int** massQ = new int* [20];
    for (int i = 0; i < 20; i++)
        massQ[i] = new int[20];
    for (int i = 0; i < 20; i++)
        for (int j = 0; j < 20; j++)
            massQ[i][j] = 0;
    for (int i = 19; i >= 0; i--)
        for (int j = 19; j >= 0; j--)
        {
            if (massQ[i][j] == 0)
            {
                if (i - 1 >= 0)
                    massQ[i - 1][j] = 1;
                if (j - 1 >= 0)
                    massQ[i][j - 1] = 1;
                if (i - k >= 0 && j - k >= 0)
                    massQ[i - k][j - k] = 1;
            }
        }
    for (int i = 0; i < 20; i++)
    {
        for (int j = 0; j < 20; j++)
            if (massQ[i][j] == 0)
                cout << '-' << ' ';
            else cout << '+' << ' ';
        cout << endl;
    }

}


