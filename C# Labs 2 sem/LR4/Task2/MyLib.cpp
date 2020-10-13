#include "pch.h"
#include "framework.h"
#include "MyLib.h"


extern "C" double __declspec(dllexport) __stdcall SquareRect(double Side1, double Side2)
{
	return Side1 * Side2;
}

extern "C" double __declspec(dllexport) __stdcall SquareTr(double Side1, double Side2)
{
	return Side1 * Side2 * 0.5;
}