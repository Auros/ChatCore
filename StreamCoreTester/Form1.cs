﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StreamCore;

namespace StreamCoreTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            var streamCore = StreamCoreInstance.Create();
            var streamServiceProvider = streamCore.RunAllServices();

            Console.WriteLine($"StreamService is of type {streamServiceProvider.ServiceType.Name}");
        }
    }
}
