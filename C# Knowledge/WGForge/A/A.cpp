#include <iostream>

using namespace std;

int main()
{
    int nSizeTable, kValueEnter;
    int counter = 0;
    cin >> nSizeTable >> kValueEnter;
    for (int i = 1; i <= nSizeTable; i++)
    {
        if (kValueEnter % i == 0 && kValueEnter / i <= nSizeTable)
            counter++;
    }
    cout << counter;
}