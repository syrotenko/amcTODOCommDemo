﻿using Autodesk.Revit.DB;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace TODOComm {
    public static class Helper {
        public static BitmapImage getBitmapImage(string path) {
            return new BitmapImage(new Uri(getFullPath(path)));
        }

        public static string getFullPath(string path) {
            return Directory.GetCurrentDirectory() + path;
        }

        public static XYZ GetElementPosition(Element elem) {
            Location loc = elem.Location;

            if (loc is LocationPoint lp) {
                return lp.Point;
            }
            else if (loc is LocationCurve lc) {
                return lc.Curve.GetEndPoint(0);
            }
            else {
                // TODO: implement own exeption type
                throw new Exception("Element should has either Point or Curve location");
            }
        }
    }

    static class Prompts {
        public const string SELECT_OBJ = "Select object";
        public const string SELECT_OBJS = "Select several objects";
        public const string PLAC_NOTE = "Place comment here";
    }

    static class TransactionNames {
        public const string EDIT_TEXT = "Edit Text";
        public const string DRAG = "Drag";
        public const string EDIT_TEXT_CUSTOM = "Edit Text_TODOComm";
        public const string CREATE_TEXTNOTE_CUSTOM = "Create TextNote_TODOComm";
        public const string SHOW_ELEMENTS_CUSTOM = "ShowElements_TODOComm";
        public const string HIDE_ELEMENTS_CUSTOM = "HideElements_TODOComm";
        public const string CREATE_LEADERS_CUSTOM = "CreateLeaders_TODOComm";
        public const string REMOVE_LEADERS_CUSTOM = "RemoveLeaders_TODOComm";
        public const string UPDATE_LEADERS_CUSTOM = "UpdateLeaders_TODOComm";
    }
}
