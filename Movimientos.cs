using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezVisual
{
    public class Movimientos
    {
        int yIndex;
        int y2Index;

        public Movimientos()
        {

        }

        public void Info()
        {
            MessageBox.Show("1. Elegir la pieza a mover dando un clic sobre ella y que corresponda al color del turno.\r\n\n" +
                "2. Para mover la pieza dar doble clic a la dirección de destino.\r\n\n" +
                "3. Si se desea cambiar a la pieza a mover presionar la imagen que se muestra a la derecha para poder seleccionar la nueva pieza.",
                "Como jugar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public int cambio(int y, int y2)
        {
            y2Index = y2;
            yIndex = y;

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
            return 0;
        }

        public bool MovimientoPeon(string[,] tablero, int x, int y, int x2, int y2, int alto, int ancho)
        {
            int xIndex = x / ancho;
            yIndex = y / alto;
            int x2Index = x2 / ancho;
            y2Index = y2 / alto;

            cambio(yIndex, y2Index);

            if (tablero[yIndex, xIndex] == "White_Pawn")
            {
                if(xIndex == x2Index)
                {
                    if(yIndex == 1)
                    {
                           if (y2Index - yIndex == 1)
                        {
                            return true;
                        }
                        else if (y2Index - yIndex == 2)
                        {
                            return true;
                        }
                    }
                    else if (y2Index - yIndex == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return false;
            }
            else if (tablero[yIndex, xIndex] == "Black_Pawn")
            {
                if (xIndex == x2Index)
                {
                    if (yIndex == 6)
                    {
                        if (yIndex - y2Index == 1)
                        {
                            return true;
                        }
                        else if (yIndex - y2Index == 2)
                        {
                            return true;
                        }
                    }
                    else if (yIndex - y2Index == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return false;
            }
            return false;
        }

        public bool MovimientoTorre(int x, int y, int x2, int y2, string[,] tablero, int alto, int ancho)
        {
            int xIndex = x / ancho;
            yIndex = y / alto;
            int x2Index = x2 / ancho;
            y2Index = y2 / alto;
            bool continuar = false;
            cambio(yIndex, y2Index);

            
            if (x2Index == xIndex)
            {
                int inicio = Math.Min(yIndex, y2Index); // 7, 5 -> 5
                int fin = Math.Max(yIndex, y2Index); // 7, 5 -> 7

                for (int i = inicio + 1; i < fin; i++)
                {
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

                return true;
            }
            else if (y2Index == yIndex)
            {
                int inicio = Math.Min(xIndex, x2Index); // 0, 3 -> 0
                int fin = Math.Max(xIndex, x2Index); // 0, 3 -> 3
                for (int i = inicio + 1; i < fin; i++)
                {
                    if (!string.IsNullOrWhiteSpace(tablero[yIndex, i]))
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

                return true;
            }

            return false;

        }

        public bool MovimientoCaballo(string[,] tablero, int x, int y, int x2, int y2, int alto, int ancho)
        {

            int xIndex = x / ancho;
            yIndex = y / alto;
            int x2Index = x2 / ancho;
            y2Index = y2 / alto;

            cambio(yIndex, y2Index);

            if (tablero[yIndex, xIndex] == "White_Knight" || tablero[yIndex, xIndex] == "Black_Knight")
            {
                int difFil = Math.Abs(yIndex - y2Index);
                int difCol = Math.Abs(xIndex - x2Index);
                return (difFil == 2 && difCol == 1) || (difFil == 1 && difCol == 2);
            }
            return false;
        }

        public bool MovimientoAlfil(string[,] tablero, int x, int y, int x2, int y2, int alto, int ancho)
        {
            int xIndex = x / ancho;
            yIndex = y / alto;
            int x2Index = x2 / ancho;
            y2Index = y2 / alto;
            cambio(yIndex, y2Index);
            bool continuar = false;

            int diffX = Math.Abs(xIndex - x2Index);
            int diffY = Math.Abs(yIndex - y2Index);

            if(diffX != diffY)
            {
                return false;
            }

            int dirX = (x2Index - xIndex) / diffX;
            int dirY = (y2Index - yIndex) / diffY;

            for (int i = 1; i <= diffX; i++)
            {
                int v = xIndex + i * dirX;
                int z = yIndex + i * dirY;
                if (!string.IsNullOrWhiteSpace(tablero[z, v]))
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
            return true;
        }   

        public bool MovimientoReina(string[,] tablero, int x, int y, int x2, int y2, int alto, int ancho)
        {
            yIndex = y / alto;
            y2Index = y2 / alto;
            cambio(yIndex, y2Index);

            if (MovimientoTorre(x, y, x2, y2, tablero, alto, ancho) || MovimientoAlfil(tablero, x, y, x2, y2, alto, ancho))
            {
                return true;
            }
            return false;
        }

        public bool MovimientoRey(int x, int y, int x2, int y2, int alto, int ancho)
        {
            int xIndex = x / ancho;
            yIndex = y / alto;
            int x2Index = x2 / ancho;
            y2Index = y2 / alto;
            cambio(yIndex, y2Index);

            int diffX = Math.Abs(xIndex - x2Index);
            int diffY = Math.Abs(yIndex - y2Index);

            return diffX <= 1 && diffY <= 1;
        }
    }
}
