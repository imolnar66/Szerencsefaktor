using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szerencsefaktor.Other_classes
{
    enum UploadMethod   //feltöltés módja
    {
        WritingNewTable,   //új tábla írása
        TableExpansion      //tábla bővítése
    }
    enum SkandiDraws
    {
        HandDraws,      //kézi húzás
        MachineDraws    //gépi húzás
    }
    enum NumberType
    {
        Tinyint,
        Integer,
        Smallint,
        Bigint,
        Float,
        Real
    }

    enum ColumnType
    {
        Integer,
        Double,
        String
    }

    enum KindOfGame
    {
        Ötöslottó,
        Hatoslottó,
        Kenó,
        Skandináv_lottó
    }
    enum Messages
    {
        Hiba,
        Információ,
        Figyelmeztetés,
        Kérdés
    }

    enum TypeOfAnalysis
    {
        Simple,
        Complex
    }

    enum LogLevel
    {
        Information,
        Warning,
        Error
    }
    enum NaploSzint
    {
        Infó,
        Figyelmeztetés,
        Hiba
    }
    enum FeltolteModja
    {
        UjTáblaÍrása,
        MeglévőTáblaBővítése
    }

    enum Uzenetek
    {
        hiba,
        informació,
        figyelmeztetés,
        kérdés
    }
    class Enums
    {
    }
}
