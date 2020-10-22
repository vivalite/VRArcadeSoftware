// This is a part of the Microsoft POS for .NET SDK
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This sample source code is only intended as a 
// supplement to the POS for .NET SDK and related 
// electronic documentation provided with the library.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;
using System.Reflection;
using System.Globalization;

namespace TestApplication
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
        }

        public PropertiesForm(PosCommon posCommon) : this()
        {
            propertyGrid1.SelectedObject = posCommon;
        }

        private void btn_PropOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}