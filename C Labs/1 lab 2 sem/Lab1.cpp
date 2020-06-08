#include <stdio.h>

int main()
{
	int a = 0, k = 3;
	printf_s("Enter number = ");
	scanf_s("%d", &a);

	for (int l = 1;;l++)
	{
		k = (k << 2);

		if (l == 2)
		{
			l = 0;
			k += 3;
		}

		if (k > a) break;

		for (int i = sizeof(k) * 8 - 1; i >= 0; --i)
		{
			printf_s("%d",k&(1<<i)?1:0);
		}

		printf("\n");
		printf_s("%d \n", k);

	}
}