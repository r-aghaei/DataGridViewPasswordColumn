﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewPasswordColumnExample
{
    using System.Drawing;
    using System.Windows.Forms;
    public class DataGridViewPasswordColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewPasswordColumn()
        {
            this.CellTemplate = new DataGriViewPasswordCell();
        }
        private DataGriViewPasswordCell PasswordCellTemplate
        {
            get { return (DataGriViewPasswordCell)this.CellTemplate; }
        }

        public bool UsePasswordCharWhenEditing
        {
            get
            {
                return PasswordCellTemplate.UsePasswordCharWhenEditing;
            }
            set
            {
                if (PasswordCellTemplate != null)
                    PasswordCellTemplate.UsePasswordCharWhenEditing = value;
                if (this.DataGridView != null)
                {
                    var dataGridViewRows = this.DataGridView.Rows;
                    var rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        var dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        var dataGridViewCell = dataGridViewRow.Cells[this.Index]
                            as DataGriViewPasswordCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.UsePasswordCharWhenEditing = value;
                        }
                    }
                }
            }
        }
        public class DataGriViewPasswordCell : DataGridViewTextBoxCell
        {
            public DataGriViewPasswordCell()
            {
                this.UsePasswordCharWhenEditing = true;
            }
            public bool UsePasswordCharWhenEditing { get; set; }
            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue,
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                ((TextBox)this.DataGridView.EditingControl).UseSystemPasswordChar = UsePasswordCharWhenEditing;
            }
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
                int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
                string errorText, DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                formattedValue = new string('●', $"{formattedValue}".Length);
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue,
                    errorText, cellStyle, advancedBorderStyle, paintParts);
            }
            public override object Clone()
            {
                var c = (DataGriViewPasswordCell)base.Clone();
                c.UsePasswordCharWhenEditing = this.UsePasswordCharWhenEditing;
                return c;
            }
        }
    }
}
