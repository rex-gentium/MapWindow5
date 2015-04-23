﻿using System;
using System.Data;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Legacy;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for deleting a field
    /// </summary>
    public partial class DeleteFieldForm : MapWindowForm
    {
        /// <summary>The datatable</summary>
        private readonly DataTable _dataTable;

        /// <summary>Initializes a new instance of the frmDeleteField class</summary>
        /// <param name = "dt">The datatable.</param>
        public DeleteFieldForm(DataTable dt)
        {
            InitializeComponent();

            _dataTable = dt;

            var names = ShapeData.GetVisibleFieldNames(dt);
            clb.Items.AddRange(names);
        }

        /// <summary>Set status of field to deleted</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clb.Items.Count; i++)
            {
                if (clb.GetItemChecked(i))
                {
                    _dataTable.Columns[i + 1].ExtendedProperties["removed"] = true;
                }
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>Enable btnOk if fields are checked for deleting</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnOK.Enabled = clb.SelectedItems.Count > 0;
        }
    }
}