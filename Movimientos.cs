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

        public bool MovimientoTorre(int x, int y, int x2, int y2, string[,] tablero)
        {
            int xIndex = x / 74;
            int yIndex = y / 63;
            int x2Index = x2 / 74;
            int y2Index = y2 / 63;
            bool continuar = false;

            MessageBox.Show("Posicion Y inicial " + yIndex.ToString());
            MessageBox.Show("Posicion X inicial " + xIndex.ToString());
            MessageBox.Show("Posicion Y final " + y2Index.ToString());
            MessageBox.Show("Posicion x final " + x2Index.ToString());


            /*
             if (tablero2[i, columna].Equals(BGB + "    ") || tablero2[i, columna].Equals(BGN + "    "))
                {
                    continuar = true;
                }
                else
                {
                    return false;
                }
             */
            if (x2Index == xIndex)
            {
                int inicio = Math.Max(yIndex, y2Index); // 7, 5 -> 7
                int fin = Math.Min(yIndex, y2Index); // 7, 5 -> 5
                for (int i = inicio - 1; i >= fin; i--)
                {
                    MessageBox.Show("Pieza " + tablero[i, xIndex]);
                    if (!tablero[i, xIndex].ToString().Equals(null))
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
                int inicio = Math.Min(xIndex, x2Index);
                int fin = Math.Max(xIndex, x2Index);
                for (int i = inicio + 1; i < fin; i++)
                {
                    MessageBox.Show("Pieza " + tablero[i, yIndex]);
                    if (!string.IsNullOrWhiteSpace(tablero[i, yIndex]))
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

            return true;

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
