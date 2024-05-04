#Posibles soluciones

            //foreach (PictureBox picture in panel1.Controls.OfType<PictureBox>().Reverse<PictureBox>())
            //{
            //    switch (picture.Name)
            //    {
            //        case "pictureBox1":
            //            picture.Image = Resource1.White_Rook;
            //            break;
            //        case "pictureBox2":
            //            picture.Image = Resource1.White_Knight;
            //            break;    
            //        case "pictureBox3":
            //                picture.Image = Resource1.White_Bishop;
            //            break;
            //        case "pictureBox4":
            //                picture.Image = Resource1.White_Queen;
            //            break;
            //        case "pictureBox5":
            //                picture.Image = Resource1.White_King;
            //            break;
            //        case "pictureBox6":
            //                picture.Image = Resource1.White_Bishop;
            //            break;
            //        case "pictureBox7":
            //                picture.Image = Resource1.White_Knight;
            //            break;
            //            case "pictureBox8":
            //                picture.Image = Resource1.White_Rook;
            //            break;
            //            case "pictureBox9":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //            case "pictureBox10":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //            case "pictureBox11":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //            case "pictureBox12":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //            case "pictureBox13":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //            case "pictureBox14":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //            case "pictureBox15":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //            case "pictureBox16":
            //                picture.Image = Resource1.White_Pawn;
            //            break;
            //        default:
            //            picture.Image = null;
            //            break;
            //    }
            //}

if(pbPieza.Tag.ToString().Contains("_Pawn"))
                {
                    if (!Turno)
                    {
                        if (posicionFinal.Y < posicionInicial.Y)
                        {
                            MessageBox.Show("No puedes mover la pieza hacia atrás");
                            return;
                        }
                    }
                    else
                    {
                        if (posicionFinal.Y > posicionInicial.Y)
                        {
                            MessageBox.Show("No puedes mover la pieza hacia atrás");
                            return;
                        }
                    }
                }