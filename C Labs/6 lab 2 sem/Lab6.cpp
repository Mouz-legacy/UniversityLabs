#include <iostream>

using namespace std;

typedef char tSurname[20];
typedef char tName[20];
typedef int tKurs;
typedef int tGroup;
typedef int tViolations;
typedef char tNumber[20];
typedef int tRoom;
typedef int tFloor;

enum Faculty
{
    FKP = 1,
    FITU,
    FKSIS,
    FRE,
    FIK,
    IEF,
    VF
};

struct node
{
    tRoom room;
    tFloor floor;
    tSurname surname;
    tName name;
    tKurs kurs;
    tGroup group;
    tViolations violations;
    Faculty faculty;
    struct node* Next, * Prev;
};

node* root = NULL;

struct node* Init()
{
    struct node* lst;
    lst = (struct node*)malloc(sizeof(struct node));
    return(lst);
};

int main()
{
    node my = *Init();
    printf_s("enter");
    scanf_s("%s", my.name);
}