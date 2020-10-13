using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Logger
{

    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);

        static void Main(string[] agrs)
        {

            int Key = 0;

            do
            {
                Key = Convert.ToInt32(Console.ReadKey().Key);
                Console.Clear();

                if (!Convert.ToBoolean(GetAsyncKeyState(160)))  
                {
                    switch (Key)
                    {
                        
                        case 65: Console.Write('a'); Thread.Sleep(1000) ; Console.Clear(); break;//Нижний регистр
                        case 66: Console.Write('b'); Thread.Sleep(1000); Console.Clear(); break;
                        case 67: Console.Write('c'); Thread.Sleep(1000); Console.Clear(); break;
                        case 68: Console.Write('d'); Thread.Sleep(1000); Console.Clear(); break;
                        case 69: Console.Write('e'); Thread.Sleep(1000); Console.Clear(); break;
                        case 70: Console.Write('f'); Thread.Sleep(1000); Console.Clear(); break;
                        case 71: Console.Write('g'); Thread.Sleep(1000); Console.Clear(); break;
                        case 72: Console.Write('h'); Thread.Sleep(1000); Console.Clear(); break;
                        case 73: Console.Write('i'); Thread.Sleep(1000); Console.Clear(); break;
                        case 74: Console.Write('j'); Thread.Sleep(1000); Console.Clear(); break;
                        case 75: Console.Write('k'); Thread.Sleep(1000); Console.Clear(); break;
                        case 76: Console.Write('l'); Thread.Sleep(1000); Console.Clear(); break;
                        case 77: Console.Write('m'); Thread.Sleep(1000); Console.Clear(); break;
                        case 78: Console.Write('n'); Thread.Sleep(1000); Console.Clear(); break;
                        case 79: Console.Write('o'); Thread.Sleep(1000); Console.Clear(); break;
                        case 80: Console.Write('p'); Thread.Sleep(1000); Console.Clear(); break;
                        case 81: Console.Write('q'); Thread.Sleep(1000); Console.Clear(); break;
                        case 82: Console.Write('r'); Thread.Sleep(1000); Console.Clear(); break;
                        case 83: Console.Write('s'); Thread.Sleep(1000); Console.Clear(); break;
                        case 84: Console.Write('t'); Thread.Sleep(1000); Console.Clear(); break;
                        case 85: Console.Write('u'); Thread.Sleep(1000); Console.Clear(); break;
                        case 86: Console.Write('v'); Thread.Sleep(1000); Console.Clear(); break;
                        case 87: Console.Write('w'); Thread.Sleep(1000); Console.Clear(); break;
                        case 88: Console.Write('x'); Thread.Sleep(1000); Console.Clear(); break;
                        case 89: Console.Write('y'); Thread.Sleep(1000); Console.Clear(); break;
                        case 90: Console.Write('z'); Thread.Sleep(1000); Console.Clear(); break;
                        case 96: Console.Write('0'); Thread.Sleep(1000);  Console.Clear(); break;//Цифровая клавиатура
                        case 97: Console.Write('1'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 98: Console.Write('2'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 99: Console.Write('3'); Thread.Sleep(1000); Console.Clear(); break;
                        case 100: Console.Write('4'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 101: Console.Write('5'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 102: Console.Write('6'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 103: Console.Write('7'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 104: Console.Write('8'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 105: Console.Write('9'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 160: Console.Write("Left Shift"); Thread.Sleep(1000); Console.Clear(); break;//Символы и Крайние кнопки
                        case 219: Console.Write('['); Thread.Sleep(1000); Console.Clear(); break;
                        case 221: Console.Write(']'); Thread.Sleep(1000); Console.Clear(); break;
                        case 192: Console.Write('`'); Thread.Sleep(1000); Console.Clear(); break;
                        case 187: Console.Write('='); Thread.Sleep(1000); Console.Clear(); break;
                        case 189: Console.Write('-'); Thread.Sleep(1000); Console.Clear(); break;
                        case 186: Console.Write(';'); Thread.Sleep(1000); Console.Clear(); break;
                        case 222: Console.Write("\\'\\"); Thread.Sleep(1000); Console.Clear(); break;
                        case 191: Console.Write('/'); Thread.Sleep(1000); Console.Clear(); break;
                        case 188: Console.Write(','); Thread.Sleep(1000); Console.Clear(); break;
                        case 190: Console.Write('.'); Thread.Sleep(1000); Console.Clear(); break;
                        case 8: Console.Write("BackSpace"); Thread.Sleep(1000); Console.Clear(); break;
                        case 9: Console.Write("Tab"); Thread.Sleep(1000); Console.Clear(); break;
                        case 20: Console.Write("Caps Lock"); Thread.Sleep(1000); Console.Clear(); break;
                        case 13: Console.Write("Enter"); Thread.Sleep(1000); Console.Clear(); break;
                        case 27: Console.Write("fEsc"); Thread.Sleep(1000); Console.Clear(); break;
                        case 37: Console.Write("Left"); Thread.Sleep(1000); Console.Clear(); break;
                        case 38: Console.Write("Up"); Thread.Sleep(1000); Console.Clear(); break;
                        case 39: Console.Write("Right"); Thread.Sleep(1000); Console.Clear(); break;
                        case 40: Console.Write("Down"); Thread.Sleep(1000); Console.Clear(); break;
                        case 162: Console.Write("leftCtrl "); Thread.Sleep(1000); Console.Clear(); break;
                        case 163: Console.Write("rightCtrl "); Thread.Sleep(1000); Console.Clear(); break;
                        case 164: Console.Write("leftAlt "); Thread.Sleep(1000); Console.Clear(); break;
                        case 165: Console.Write("rightAlt "); Thread.Sleep(1000); Console.Clear(); break;
                        case 33: Console.Write("pgUp "); Thread.Sleep(1000); Console.Clear(); break;
                        case 34: Console.Write("pgDown "); Thread.Sleep(1000); Console.Clear(); break;
                        case 32: Console.Write("Space "); Thread.Sleep(1000); Console.Clear(); break;
                        case 91: Console.Write("Win"); Thread.Sleep(1000); Console.Clear(); break;
                        default: Console.Write("Unknown Enter"); Thread.Sleep(1000); Console.Clear(); break;
                    }
                }
                else
                {
                    switch (Key) 
                    {
                        case 48: Console.Write(')'); Thread.Sleep(1000);  Console.Clear(); break;//Символы над цифровой
                        case 49: Console.Write('!'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 50: Console.Write('@'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 51: Console.Write('#'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 52: Console.Write('$'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 53: Console.Write('%'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 54: Console.Write('^'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 55: Console.Write('&'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 56: Console.Write('*'); Thread.Sleep(1000);  Console.Clear(); break;
                        case 57: Console.Write('('); Thread.Sleep(1000);  Console.Clear(); break;

                        case 65: Console.Write('A'); Thread.Sleep(1000); Console.Clear(); break;//Верхний регистр
                        case 66: Console.Write('B'); Thread.Sleep(1000); Console.Clear(); break;
                        case 67: Console.Write('C'); Thread.Sleep(1000); Console.Clear(); break;
                        case 68: Console.Write('D'); Thread.Sleep(1000); Console.Clear(); break;
                        case 69: Console.Write('E'); Thread.Sleep(1000); Console.Clear(); break;
                        case 70: Console.Write('F'); Thread.Sleep(1000); Console.Clear(); break;
                        case 71: Console.Write('G'); Thread.Sleep(1000); Console.Clear(); break;
                        case 72: Console.Write('H'); Thread.Sleep(1000); Console.Clear(); break;
                        case 73: Console.Write('I'); Thread.Sleep(1000); Console.Clear(); break;
                        case 74: Console.Write('J'); Thread.Sleep(1000); Console.Clear(); break;
                        case 75: Console.Write('K'); Thread.Sleep(1000); Console.Clear(); break;
                        case 76: Console.Write('L'); Thread.Sleep(1000); Console.Clear(); break;
                        case 77: Console.Write('M'); Thread.Sleep(1000); Console.Clear(); break;
                        case 78: Console.Write('M'); Thread.Sleep(1000); Console.Clear(); break;
                        case 79: Console.Write('O'); Thread.Sleep(1000); Console.Clear(); break;
                        case 80: Console.Write('P'); Thread.Sleep(1000); Console.Clear(); break;
                        case 81: Console.Write('Q'); Thread.Sleep(1000); Console.Clear(); break;
                        case 82: Console.Write('R'); Thread.Sleep(1000); Console.Clear(); break;
                        case 83: Console.Write('S'); Thread.Sleep(1000); Console.Clear(); break;
                        case 84: Console.Write('T'); Thread.Sleep(1000); Console.Clear(); break;
                        case 85: Console.Write('U'); Thread.Sleep(1000); Console.Clear(); break;
                        case 86: Console.Write('V'); Thread.Sleep(1000); Console.Clear(); break;
                        case 87: Console.Write('W'); Thread.Sleep(1000); Console.Clear(); break;
                        case 88: Console.Write('X'); Thread.Sleep(1000); Console.Clear(); break;
                        case 89: Console.Write('Y'); Thread.Sleep(1000); Console.Clear(); break;
                        case 90: Console.Write('Z'); Thread.Sleep(1000); Console.Clear(); break;
                        case 219: Console.Write('{'); Thread.Sleep(1000); Console.Clear(); break;//Символы
                        case 221: Console.Write('}'); Thread.Sleep(1000); Console.Clear(); break;
                        case 192: Console.Write('~'); Thread.Sleep(1000); Console.Clear(); break;
                        case 187: Console.Write('+'); Thread.Sleep(1000); Console.Clear(); break;
                        case 189: Console.Write('_'); Thread.Sleep(1000); Console.Clear(); break;
                        case 186: Console.Write(':'); Thread.Sleep(1000); Console.Clear(); break;
                        case 222: Console.Write('"'); Thread.Sleep(1000); Console.Clear(); break;
                        case 191: Console.Write('?'); Thread.Sleep(1000); Console.Clear(); break;
                        case 188: Console.Write('<'); Thread.Sleep(1000); Console.Clear(); break;
                        case 190: Console.Write('>'); Thread.Sleep(1000); Console.Clear(); break;



                        default: Console.Write("Unknown Enter"); Thread.Sleep(1000); Console.Clear(); break;

                    }
                }
                
                
            }
            while (true);
            
        }
    }
}