﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Библиотечной_информационная_система.DataBase;

namespace Библиотечной_информационная_система
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static libraryEntities1 Connetction = new libraryEntities1();
    }
}
