using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezVisual
{
    public class Movimientos
    {


        public Movimientos()
        {
        }

        public bool MovimientoPeon(string[,] tablero, int x, int y, int x2, int y2)
        {
            if (tablero[x, y] == "White_Pawn")
            {
                if (x2 == x + 1 && y2 == y)
                {
                    return true;
                }
                else if (x2 == x + 2 && y2 == y)
                {
                    return true;
                }
                else if (x2 == x + 1 && y2 == y + 1)
                {
                    return true;
                }
                else if (x2 == x + 1 && y2 == y - 1)
                {
                    return true;
                }
            }
            else if (tablero[x, y] == "Black_Pawn")
            {
                if (x2 == x - 1 && y2 == y)
                {
                    return true;
                }
                else if (x2 == x - 2 && y2 == y)
                {
                    return true;
                }
                else if (x2 == x - 1 && y2 == y + 1)
                {
                    return true;
                }
                else if (x2 == x - 1 && y2 == y - 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool MovimientoTorre(int x, int y, int x2, int y2, string[,] tablero, int alto, int ancho)
        {
            int xIndex = x / ancho;
            int yIndex = y / alto;
            int x2Index = x2 / ancho;
            int y2Index = y2 / alto;
            bool continuar = false;

            switch (yIndex)
            {
                case 7:
                    yIndex = 0;
                    break;
                case 6:
                    yIndex = 1;
                    break;
                case 5:
                    yIndex = 2;
                    break;
                case 4:
                    yIndex = 3;
                    break;
                case 3:
                    yIndex = 4;
                    break;
                case 2:
                    yIndex = 5;
                    break;
                case 1:
                    yIndex = 6;
                    break;
                case 0:
                    yIndex = 7;
                    break;
                default:
                    break;
            }

            switch (y2Index)
            {
                case 7:
                    y2Index = 0;
                    break;
                case 6:
                    y2Index = 1;
                    break;
                case 5:
                    y2Index = 2;
                    break;
                case 4:
                    y2Index = 3;
                    break;
                case 3:
                    y2Index = 4;
                    break;
                case 2:
                    y2Index = 5;
                    break;
                case 1:
                    y2Index = 6;
                    break;
                case 0:
                    y2Index = 7;
                    break;
                default:
                    break;
            }

            
            if (x2Index == xIndex)
            {
                int inicio = Math.Min(yIndex, y2Index); // 7, 5 -> 5
                int fin = Math.Max(yIndex, y2Index); // 7, 5 -> 7


                for (int i = inicio + 1; i < fin; i++)
                {
                    MessageBox.Show("Pieza " + tablero[i, xIndex] + " Valor i " + i + " valor x " + xIndex);
                    if (!string.IsNullOrWhiteSpace(tablero[i, xIndex]))
                    {
                        return false;
                    }
                    else
                    {
                        continuar = true;
                    }
                }
                if (continuar)
                {
                    return true;
                }
            }
            else if (y2Index == yIndex)
            {
                int inicio = Math.Min(xIndex, x2Index); // 0, 3 -> 0
                int fin = Math.Max(xIndex, x2Index); // 0, 3 -> 3
                for (int i = inicio + 1; i < fin; i++)
                {
                    MessageBox.Show("Pieza " + tablero[yIndex, i] + " Valor i " + i + " valor y " + yIndex);
                    if (!string.IsNullOrWhiteSpace(tablero[yIndex, i]))
                    {
                    //MessageBox.Show("Pieza " + tablero[yIndex, i] + " Valor i " + i + " valor y " + yIndex);
                        return false;
                    }
                    else
                    {
                        continuar = true;
                    }
                    
                }
                if (continuar)
                {
                    return true;
                }
            }

            return false;

        }

        public bool MovimientoCaballo(string[,] tablero, int x, int y, int x2, int y2)
        {
            if (tablero[x, y] == "White_Knight" || tablero[x, y] == "Black_Knight")
            {
                if (x2 == x + 2 && y2 == y + 1)
                {
                    return true;
                }
                else if (x2 == x + 2 && y2 == y - 1)
                {
                    return true;
                }
                else if (x2 == x - 2 && y2 == y + 1)
                {
                    return true;
                }
                else if (x2 == x - 2 && y2 == y - 1)
                {
                    return true;
                }
                else if (x2 == x + 1 && y2 == y + 2)
                {
                    return true;
                }
                else if (x2 == x + 1 && y2 == y - 2)
                {
                    return true;
                }
                else if (x2 == x - 1 && y2 == y + 2)
                {
                    return true;
                }
                else if (x2 == x - 1 && y2 == y - 2)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
