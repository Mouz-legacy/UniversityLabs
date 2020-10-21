#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

bool Comp(pair <int, int> firstPair, pair <int, int> secondPair) {
    return firstPair.second < secondPair.second;
}

void SortOut(vector<pair<int, int>>& listNumbersPointer)
{
    for (int i = 0; i < listNumbersPointer.size() - 1; i++)
    {
        for (int j = i + 1; j < listNumbersPointer.size(); j++)
        {
            if (listNumbersPointer[i].first > listNumbersPointer[j].first)
            {
                listNumbersPointer.erase(listNumbersPointer.begin() + j);
                j--;
            }
        }

    }
    for (int i = 0; i < listNumbersPointer.size() - 1; i++)
    {
        if (listNumbersPointer[i].second == listNumbersPointer[i + 1].second)
        {
            listNumbersPointer.erase(listNumbersPointer.begin() + i);
            i--;
        }
    }
}

void FindLargeChain(vector<pair<int, int>>& listNumbersPointer, int amountMoney)
{
    if (amountMoney >= listNumbersPointer[0].second)
    {
        int rest = amountMoney % listNumbersPointer[0].second;
        if (rest != 0 && listNumbersPointer.size() != 1)
        {
            for (int i = listNumbersPointer.size() - 1; i > 0; i--)
            {
                if (listNumbersPointer[0].second + rest >= listNumbersPointer[i].second && amountMoney > listNumbersPointer[0].second)
                {
                    cout << listNumbersPointer[i].first;
                    amountMoney -= listNumbersPointer[i].second;
                    rest = rest + listNumbersPointer[0].second - listNumbersPointer[i].second;
                    i++;
                }
            }
        }
        while (amountMoney >= listNumbersPointer[0].second)
        {
            cout << listNumbersPointer[0].first;
            amountMoney -= listNumbersPointer[0].second;
        }
    }
    else
        cout << "-1";

}

int main()
{
    int currentMoney;
    vector<pair<int, int>> listNumbers(9);
    cin >> currentMoney;
    for (int i = 0; i < 9; i++)
    {
        int localPairHelper;
        cin >> localPairHelper;
        listNumbers[i].first = i + 1;
        listNumbers[i].second = localPairHelper;
    }
    sort(listNumbers.begin(), listNumbers.end(), Comp);
    SortOut(listNumbers);
    FindLargeChain(listNumbers, currentMoney);
}
