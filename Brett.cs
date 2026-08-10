using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win4Gewinnt
{
    public static class Brett
    {
        public enum Farbe
        {
            Rot,
            Gelb
        }

        private static readonly int MaxX = 7;
        private static readonly int MaxY = 6;

        private static int[,] feld = new int[MaxX + 1, MaxY + 1];     // Brett : X= 1..7 ,  Y= 1..6

        //public static List<Zug> Zuege = new List<Zug>();
        //public static string path = @"C:\Temp\4Gewinnt\Stellung1.txt";

        public static Farbe Spieler;
        public static int step = 0;
        public static bool gewonnen = false;


        public static int GetValue(int pX, int pY)   
        {
            return feld[pX, pY];
        }//END


        //---------------------------------
        // pValue:
        //    1  -> Rot
        //   -1  -> Gelb
        //---------------------------------
        public static void SetValue(Zug pZug, Farbe pValue)   
        {
            if (pValue == Farbe.Rot)
                feld[pZug.X, pZug.Y] = 1;
            if (pValue == Farbe.Gelb)
                feld[pZug.X, pZug.Y] = -1;
        }//END


        //---------------------------------
        // pValue:
        //    1  -> Rot
        //   -1  -> Gelb
        //---------------------------------
        public static void SetValue(int pX, int pY, Farbe pValue)
        {
            if (pValue == Farbe.Rot)
                feld[pX, pY] = 1;
            if (pValue == Farbe.Gelb)
                feld[pX, pY] = -1;
        }//END


        //---------------------------------
        // pValue: Den Stein wieder entfernen
        //    1  -> Rot
        //   -1  -> Gelb
        //---------------------------------
        public static void RemoveValue(Zug pZug, Farbe pValue)
        {
            if (pValue == Farbe.Rot)
                feld[pZug.X, pZug.Y] = 0;
            if (pValue == Farbe.Gelb)
                feld[pZug.X, pZug.Y] = 0;
        }//END


        //public static int Spieler { get; set; }


        public static void Init()
        {
            for (int x = 1; x <= MaxX; x++)
            {
                for (int y = 1; y <= MaxY; y++)
                {
                    feld[x, y] = 0;                         // 0 -> Leer
                }
            }

            // Spieler: Rot beginnt
            // Spieler = 1;
            Spieler = Farbe.Rot;
        }//END


        //---------------------------------------------------
        // Loading File
        //---------------------------------------------------
        public static void LoadingFile(string pFilename)
        {             
            // This text is added only once to the file.
            foreach (string line in File.ReadLines(pFilename))
            {
                Console.WriteLine(line);
                string[] txt = line.Split(',');
                int x = Convert.ToInt32(txt[0]);
                int y = Convert.ToInt32(txt[1]);
                
                int step = txt[2].IndexOf("#");
                if (step != -1)
                    txt[2] = txt[2].Substring(0, step);                
                int spieler = Convert.ToInt32(txt[2]);

                if (spieler == 1)
                    SetValue(x, y, Farbe.Rot);

                if (spieler == -1)
                    SetValue(x, y, Farbe.Gelb);
            }

        }//END


        //---------------------------------------------------
        // Save File
        //---------------------------------------------------
        public static void SaveMove(string pFilename, bool pDeleteFile, List<Zug> pListe)
        {
            if (pListe.Count == 0)
                return;
                        
            if (pDeleteFile)
            {
                if (File.Exists(pFilename))
                    File.Delete(pFilename);              
            }

            using (StreamWriter ws = File.AppendText(pFilename))
            {
                ws.WriteLine("-----------------------------------------" + Environment.NewLine);                
                foreach (Zug obj in pListe)
                {
                    string txt = obj.GetValueAsString();
                    ws.WriteLine(txt);
                }
            }
        }//END



        //---------------------------------------------------
        // Save File
        //---------------------------------------------------
        public static void SaveBrett(string pFilename, bool pDeleteFile, Zug pZug, string pKommentar)
        {
            if (pDeleteFile)
            {
                if (File.Exists(pFilename))
                    File.Delete(pFilename);
            }

            using (StreamWriter ws = File.AppendText(pFilename))
            {
                ws.WriteLine("-----------------------------------------" + Environment.NewLine);
                ws.WriteLine(pKommentar);
                ws.WriteLine(GetBrettAsString());
                ws.WriteLine("Zug   X/Y : " + pZug.X.ToString() + "/" + pZug.Y.ToString());                
                ws.WriteLine("-----------------------------------------" + Environment.NewLine);
            }
        }//END


        private static int GetEigenenStein(Farbe pSpieler)
        {
            int count = 0;

            // Den ersten Stein im Feld finden
            for (int y = 1; y <= MaxY; y++)
            {
                for (int x = 1; x <= MaxX; x++)
                {
                    if (pSpieler == Farbe.Rot)
                    {
                        if (feld[x, y] == 1)
                        {
                            count++;
                        }
                    }

                    if (pSpieler == Farbe.Gelb)
                    {
                        if (feld[x, y] == -1)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }//END


        private static int GetGegnerStein(Farbe pSpieler)
        {
            int count = 0;

            // Den ersten Stein im Feld finden
            for (int y = 1; y <= MaxY; y++)
            {
                for (int x = 1; x <= MaxX; x++)
                {
                    if (pSpieler == Farbe.Rot)
                    {
                        if (feld[x, y] == 1)
                        {
                            count++;
                        }
                    }

                    if (pSpieler == Farbe.Gelb)
                    {
                        if (feld[x, y] == -1)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }//END


        private static int SearchRechts(Farbe pSpieler, int pX, int pY)
        {
            int anzahl = 0;
            

            for (int x = pX+1; x <= MaxX; x++)
            {
                switch (pSpieler)
                {
                    // Rot = 1
                    case Farbe.Rot:
                        if (feld[x, pY] == 1)
                        {
                            anzahl++;
                            continue;
                        }              
                        else
                        {
                            return anzahl;
                        }; 

                    // Gelb = -1
                    case Farbe.Gelb:
                        if (feld[x, pY] == -1)
                        {
                            anzahl++;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        };                 }
               

                // Ist das Nachbar-Feld LEER ?
                if (feld[x, pY] == 0)
                {
                    break;
                }
            }

            return anzahl;
        }//END


        //----------------------------------------
        // Diagonal Rechts hoch suchen
        //----------------------------------------
        private static int SearchDiagRechtsHoch(Farbe pSpieler, int pX, int pY)
        {        
            int dx = pX + 1;
            int dy = pY + 1;
            int anzahl = 0;

            do
            {
                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx > MaxX) || (dy > MaxY))
                    break;

                switch (pSpieler)
                {
                    // Rot = 1
                    case Farbe.Rot:
                        if (feld[dx, dy] == 1)                          
                        {
                            anzahl++;
                            dx++; dy++;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        }; break;



                    // Gelb = -1
                    case Farbe.Gelb:
                        if (feld[dx, dy] == -1)
                        {
                            anzahl++;
                            dx++; dy++;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        }; break;
                }
               

                // Ist das Nachbar-Feld LEER ?
                if (feld[dx, dy] == 0)
                {
                    break;
                }

                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx > MaxX) || (dy > MaxY))
                    break;

            } while (true);            

            return anzahl;
        }//END


       


        //----------------------------------------
        // Diagonal Rechts runter suchen
        //----------------------------------------
        private static int SearchDiagRechtsRunter(Farbe pSpieler, int pX, int pY)
        {            
            int dx = pX + 1;
            int dy = pY - 1;
            int anzahl = 0;

            do
            {
                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx > MaxX) || (dy < 1))
                    break;

                switch (pSpieler)
                {
                    // Rot = 1
                    case Farbe.Rot:
                        if (feld[dx, dy] == 1)
                        {
                            anzahl++;
                            dx++; dy--;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        };break;


                    // Gelb = -1
                    case Farbe.Gelb:
                        if (feld[dx, dy] == -1)
                        {
                            anzahl++;
                            dx++; dy--;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        }; break;
                }                
                

                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx > MaxX) || (dy < 1))
                    break;

            } while (true);

            return anzahl;
        }//END


        //----------------------------------------
        // Nach Runter suchen
        //----------------------------------------
        private static int SearchRunter(Farbe pSpieler, int pX, int pY)
        {            
            int dx = pX;
            int dy = pY - 1;
            int anzahl = 0;

            do
            {
                // Wenn Rand erreicht -> Schleife verlassen
                if (dy < 1)
                    break;

                switch (pSpieler)
                {
                    // Rot = 1
                    case Farbe.Rot:
                        if (feld[dx, dy] == 1)
                        {
                            anzahl++;
                            dy--;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        };break;

                    // Gelb = -1
                    case Farbe.Gelb:
                        if (feld[dx, dy] == -1)
                        {
                            anzahl++;
                            dy--;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        }; break;
                }


                // Ist das Nachbar-Feld LEER ?
                if (feld[dx, dy] == 0)
                {
                    break;
                }

                // Wenn Rand erreicht -> Schleife verlassen
                if (dy < 1)
                    break;

            } while (true);

            return anzahl;
        }//END


        //----------------------------------------
        // Diagonal Links runter suchen
        //----------------------------------------
        private static int SearchDiagLinksRunter(Farbe pSpieler, int pX, int pY)
        {
            int dx = pX - 1;
            int dy = pY - 1;
            int anzahl = 0;

            do
            {
                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx < 1) || (dy < 1))
                    break;

                switch (pSpieler)
                {
                    // Rot = 1
                    case Farbe.Rot:
                        if (feld[dx, dy] == 1)
                        {
                            anzahl++;
                            dx--; dy--;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        };break;


                    // Gelb = -1
                    case Farbe.Gelb:
                        if (feld[dx, dy] == -1)
                        {
                            anzahl++;
                            dx--; dy--;
                            continue;
                        }
                        else
                        {
                            return anzahl;
                        }; break;
                }


                // Ist das Nachbar-Feld LEER ?
                if (feld[dx, dy] == 0)
                {
                    break;
                }

                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx < 1) || (dy < 1))
                    break;

            } while (true);

            return anzahl;
        }//END


        //----------------------------------------
        // Diagonal Links suchen
        //----------------------------------------
        private static int SearchLinks(Farbe pSpieler, int pX, int pY)
        {
            int anzahl = 0;


            for (int x = pX - 1; x >= 1; x--)
            {

                switch (pSpieler)
                {
                    // Rot = 1
                    case Farbe.Rot:
                        if (feld[x, pY] == 1)
                        {
                            anzahl++;                           
                            continue;
                        }
                        else
                        if (feld[x, pY] == -1)
                        {
                            return anzahl;
                        }; break;


                    // Gelb = -1
                    case Farbe.Gelb:
                        if (feld[x, pY] == -1)
                        {
                            anzahl++;
                            continue;
                        }
                        else
                        if (feld[x, pY] == 1)
                        {
                            return anzahl;
                        }; break;
                }                


                // Ist das Nachbar-Feld LEER ?
                if (feld[x, pY] == 0)
                {
                    break;
                }
            }

            return anzahl;
        }//END



        //----------------------------------------
        // Diagonal Links hoch suchen
        //----------------------------------------
        private static int SearchDiagLinksHoch(Farbe pSpieler, int pX, int pY)
        {
            int dx = pX - 1;
            int dy = pY + 1;
            int anzahl = 0;

            do
            {
                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx < 1) || (dy > MaxY))
                    break;

                switch (pSpieler)
                {
                    // Rot = 1
                    case Farbe.Rot:
                        if (feld[dx, dy] == 1)
                        {
                            anzahl++;
                            dx--; dy++;
                            continue;
                        }; break;


                    // Gelb = -1
                    case Farbe.Gelb:
                        if (feld[dx, dy] == -1)
                        {
                            anzahl++;
                            dx--; dy++;
                            continue;
                        }; break;
                }


                // Gehört der Nachbar-Stein NICHT mir ?
                switch (pSpieler)
                {
                    case Farbe.Rot:
                        if (feld[dx, dy] != 1)
                        {
                            return anzahl;
                        }; break;

                    case Farbe.Gelb:
                        if (feld[dx, dy] != -1)
                        {
                            return anzahl;
                        }; break;
                }

               
                // Ist das Nachbar-Feld LEER ?
                if (feld[dx, dy] == 0)
                {
                    break;
                }

                // Wenn Rand erreicht -> Schleife verlassen
                if ((dx < 1) || (dy > MaxY))
                    break;

            } while (true);

            return anzahl;
        }//END


        private static void SetFirstStein(Farbe pSpieler)
        {
            // Den ersten GegnerStein im Feld finden
            for (int x = 1; x <= MaxX; x++)
            {
                if (pSpieler == Farbe.Rot)
                {
                    if (feld[x, 1] == -1)                           // Gelb = -1
                    {
                        SetValue(x - 1, 1, pSpieler);
                        break;
                    }
                }


                if (pSpieler == Farbe.Gelb)
                {
                    if (feld[x, 1] == 1)                            // Rot = 1
                    {
                        SetValue(x - 1, 1, pSpieler);
                        break;
                    }
                }
            }
        }//END


        //------------------------------------------
        // ReturnValue:
        //    0  -> Alles in Ordnung
        //   <0  -> 4 Steine in einer Reihe !!!
        //------------------------------------------
        public static int Analysis(Farbe pSpieler)
        {
            if (GetFreeField() == 0)
                return -10;

            if (step > 10000)
                return -10;

            // Den ersten EIGENEN Stein auf dem Feld finden
            int CountEigeneSteine = GetEigenenStein(pSpieler);            
            

            // Wenn kein Stein auf dem Feld liegt -> so nah wie möglich beim Gegner platzieren
            if (CountEigeneSteine == 0)
            {
                // Den ersten Stein vom GEGNERs auf dem Feld finden
                Farbe gegner;
                if (pSpieler == Farbe.Rot)                                      // Rot = 1
                    gegner = Farbe.Gelb;                                        // Gelb = -1
                else
                    gegner = Farbe.Rot;

                int CountGegnerSteine = GetGegnerStein(gegner);

                if (CountGegnerSteine == 0)
                {
                    // Kein Stein vom Gegner vorhanden.
                    // Eigenes Stein mittig platzieren und Proz. verlassen
                    SetValue(4, 1, pSpieler);                 
                }
                else
                {
                    // So nah wie möglich am Stein vom Gegner platzieren
                    // Links vom Gegner-Stein platzieren
                    SetFirstStein(pSpieler);
                }

                return 0;
            }


            List<Zug> Zuege = new List<Zug>();


            // Wir haben auf dem Feld Steine und suchen jetzt nach einem freien Feld.
            // Wir gehen Feld für Feld durch und schauen, ob es zusammenhängende Steine gibt.
            // Wenn JA -> wird geschaut, wie viele Steine zusammenhängend ist.
            //            Z.B.:  2 Steine sind zusammenhängend und mit dem freie Feld ergibt es = 3
            //    NEIN -> Wenn immer nur einzelne Steine existieren, die nicht zusammenhängend ist, 
            //            wird dieses Feld in die Liste hinzugefügt.
            // Zum Schluss wird das Gesamtergebnis ermittelt.
            // Also, welches freie Feld hat die meisten zusammenhängende Steine
            for (int y = 1; y <= MaxY; y++)
            {
                for (int x = 1; x <= MaxX; x++)
                {
                    int searchDiagRechtsHoch = 0;
                    int searchRechts = 0;
                    int searchDiagRechtsRunter = 0;
                    int searchRunter = 0;
                    int searchDiagLinksRunter = 0;
                    int searchLinks = 0;
                    int searchDiagLinksHoch = 0;
                    int gesamt = 0;
                    bool ZugMoglich = false;

                    // Grundlinie 
                    if (y == 1)
                    {                        
                        if (GetValue(x, y) == 0)
                        {
                            ZugMoglich = true;
                            searchDiagLinksRunter = 0;
                            searchRunter = 0;
                            searchDiagRechtsRunter = 0;
                            searchDiagRechtsHoch = SearchDiagRechtsHoch(pSpieler, x, y);
                            searchRechts = SearchRechts(pSpieler, x, y);
                            searchLinks = SearchLinks(pSpieler, x, y);
                            searchDiagLinksHoch = SearchDiagLinksHoch(pSpieler, x, y);
                            gesamt = searchDiagRechtsHoch + searchRechts + searchLinks + searchDiagLinksHoch;                            
                        }
                    }


                    // Über der Grundlinie 
                    if ((y > 1) && (Math.Abs(GetValue(x,y-1)) > 0))
                    {
                        if (GetValue(x, y) == 0)
                        {
                            ZugMoglich = true;
                            searchDiagRechtsHoch = SearchDiagRechtsHoch(pSpieler, x, y);
                            searchRechts = SearchRechts(pSpieler, x, y);
                            searchDiagRechtsRunter = SearchDiagRechtsRunter(pSpieler, x, y);
                            searchRunter = SearchRunter(pSpieler, x, y);
                            searchDiagLinksRunter = SearchDiagLinksRunter(pSpieler, x, y);
                            searchLinks = SearchLinks(pSpieler, x, y);
                            searchDiagLinksHoch = SearchDiagLinksHoch(pSpieler, x, y);
                            gesamt = searchDiagRechtsHoch + searchRechts + searchDiagRechtsRunter + searchRunter + searchDiagLinksRunter + searchLinks + searchDiagLinksHoch;                            
                        }
                    }


                    // Zug in die Liste hinzufügen
                    if (ZugMoglich)
                    {
                        Zug zug = new Zug
                        {
                            Farbe = ((pSpieler == Farbe.Rot) ? 1 : -1),
                            X = x,
                            Y = y,
                            DiagRechtsHoch = searchDiagRechtsHoch,
                            Rechts = searchRechts,
                            DiagRechtsRunter = searchDiagRechtsRunter,
                            Runter = searchRunter,
                            DiagLinksRunter = searchDiagLinksRunter,
                            Links = searchLinks,
                            DiagLinksHoch = searchDiagLinksHoch,
                            Gesamt = gesamt
                        };

                        Zuege.Add(zug);
                    }
                }//for x
            }//for y


            
            int result;
            string FileNameBrett = @"c:\temp\4Gewinnt\Analyse_BRETT.Txt";            
            string FileNameZug = @"c:\temp\4Gewinnt\Analyse_ZUG.Txt";
            
            if (pSpieler == Farbe.Rot)
            {
                // Ergebnisse in einer Datei speichern                
                //SaveMove(FileNameZugRot, false, Zuege); ;

                foreach (Zug item in Zuege)
                {
                    // Wenn eine Himmelsrichtung eine4 Reihe ergibt 
                    if (((item.Links + item.Rechts) >= 3) ||
                        (item.Runter >= 3) ||
                        ((item.DiagLinksHoch + item.DiagRechtsRunter) >= 3) ||
                        ((item.DiagLinksRunter + item.DiagRechtsHoch) >= 3))
                    {
                        // Rot hat gewonen
                        gewonnen = true;
                        SetValue(item, Farbe.Rot);
                        SaveBrett(FileNameBrett, false, item, "ROT hat mit dem Zug gewonnen");
                        RemoveValue(item, Farbe.Rot);                                           // Zug wieder entfernen
                        SaveMove(FileNameZug, false, Zuege);
                        step++;
                        return -10;                                                             // Irgendwie die Routine beenden
                    }


                    // Zug ausführen und schauen, was er bringt
                    SetValue(item, Farbe.Rot);
                    //SaveBrett(FileNameBrett, false, item, "Zug ROT");
                    result = Analysis(Farbe.Gelb);                                          // Gelb = -1
                    RemoveValue(item, Farbe.Rot);                                           // Zug wieder entfernen                        

                    if (gewonnen)
                    {
                        SaveBrett(FileNameBrett, false, item, "ROT  ");
                        return -10;
                    }

                    if (result > 0)
                    {
                        // Den Zug auf keinem Fall ausführen, weil der GEGNER sofort einen 4 Reiher macht                            
                        continue;
                    }

                    // Kein freies Feld mehr vorhanden
                    if (result == -1)
                    {
                        continue; 
                    }

                    // Tiefe ist erreicht -> Züge ausgeben
                    if (result == -10)
                    {
                        SaveBrett(FileNameBrett, false, item, "ROT  ... Max. Tiefe ist erreicht ...");
                        SaveMove(FileNameZug, false, Zuege);
                        return result; 
                    }

                }//foreach
            }//if





            if (pSpieler == Farbe.Gelb)
            {
                // Ergebnisse in einer Datei speichern
                //SaveMove(FileNameZugGelb, false, Zuege);

                foreach (Zug item in Zuege)
                {
                    // Wenn eine Himmelsrichtung eine4 Reihe ergibt 
                    if (((item.Links + item.Rechts) >= 3) ||
                        (item.Runter >= 3) ||
                        ((item.DiagLinksHoch + item.DiagRechtsRunter) >= 3) ||
                        ((item.DiagLinksRunter + item.DiagRechtsHoch) >= 3))
                    {
                        // Gelb hat gewonen
                        //SetValue(item, Farbe.Gelb);
                        //SaveBrett(FileNameBrett, false, item, "GELB hat mit dem Zug gewonnen");
                        //RemoveValue(item, Farbe.Gelb);                                          // Zug wieder entfernen
                        //step++;
                        return 1;
                    }


                    // Zug ausführen und schauen, was er bringt
                    SetValue(item, Farbe.Gelb);
                    //SaveBrett(FileNameBrett, false, item, "Zug GELB");
                    result = Analysis(Farbe.Rot);                                           // Gelb = -1
                    RemoveValue(item, Farbe.Gelb);                                          // Zug wieder entfernen

                    if (gewonnen)
                    {
                        SaveBrett(FileNameBrett, false, item, "GELB  ");
                        return -10;
                    }

                    if (result > 0)
                    {
                        // Den Zug auf keinem Fall ausführen, weil der GEGNER sofort einen 4 Reiher macht
                        continue;
                    }

                    // Kein freies Feld mehr vorhanden
                    if (result == -1)
                    {
                        continue; 
                    }


                    // Tiefe ist erreicht -> Züge ausgeben
                    if (result == -10)
                    {
                        SaveBrett(FileNameBrett, false, item, "GELB  ... Max. Tiefe ist erreicht ...");
                        SaveMove(FileNameZug, false, Zuege);
                        return result;
                    }

                }//foreach
            }//if

            return 0;

        }//END


        public static int GetFreeField()
        {
            int result = 0;

            for (int y = 1; y <= MaxY; y++)
            {
                for (int x = 1; x <= MaxX; x++)
                {
                    if (feld[x, y] == 0)
                        result++;
                }
            }

            return result;
        }//END



        public static string GetBrettAsString()
        {
            string result = "6| ";
            for (int y = 1; y <= MaxY; y++)
            {
                for (int x = 1; x <= MaxX; x++)
                {
                    if (feld[x, 7-y] == 0)
                        result += "  ";
                    if (feld[x, 7-y] == 1)
                        result += "R ";
                    if (feld[x, 7-y] == -1)
                        result += "G ";
                }

                result += Environment.NewLine;
                if (y < MaxY)
                   result += (6-y).ToString() + "| ";
            }

            result += Environment.NewLine;
            return result;
        }//END

    }//end
}
